using System;
using System.Linq;
using DeepWinter.RRuleParserNet.Text.Formatting;
using DeepWinter.RRuleParserNet.Text.Listing;
using DeepWinter.RRuleParserNet.Tokenizer;
using DeepWinter.RRuleParserNet.Tokenizer.Token;
using DeepWinter.RRuleParserNet.Translation;

namespace DeepWinter.RRuleParserNet.Text
{
    public class TextBuilder : ITextBuilder
    {
        private readonly IDateFormatting _dateFormatting;
        private readonly IDayListingFormatting _dayListingFormatting;
        private readonly IFragmentTranslator _fragmentTranslator;


        public TextBuilder(IFragmentTranslator fragmentTranslator) :
            this(fragmentTranslator, new DefaultDateFormatting(fragmentTranslator))
        {
        }

        public TextBuilder(IFragmentTranslator fragmentTranslator, IDayListingFormatting dayListingFormatting) :
            this(fragmentTranslator, new DefaultDateFormatting(fragmentTranslator), dayListingFormatting)
        {
        }

        public TextBuilder(IFragmentTranslator fragmentTranslator, IDateFormatting dateFormatting) :
            this(fragmentTranslator, dateFormatting, new DefaultDayListingFormatting(dateFormatting))
        {
        }

        public TextBuilder(IFragmentTranslator fragmentTranslator, IDateFormatting dateFormatting,
            IDayListingFormatting dayListingFormatting)
        {
            _fragmentTranslator = fragmentTranslator;
            _dateFormatting = dateFormatting;
            _dayListingFormatting = dayListingFormatting;
        }

        public string BuildText(IRRuleTokenContainer tokenContainer)
        {
            var resultString = BuildFrequency(tokenContainer);


            var freqValue = (FreqToken.FreqValue) tokenContainer.GetFreq().GetValue();
            if (freqValue == FreqToken.FreqValue.WEEKLY)
                resultString += " " + BuildWeeklyDays(tokenContainer);
            else if (freqValue == FreqToken.FreqValue.MONTHLY && tokenContainer.GetByMontDay() != null)
                resultString += " " + BuildMonthlyOnDay(tokenContainer);
            else if (freqValue == FreqToken.FreqValue.MONTHLY && tokenContainer.GetBySetPos() != null
                                                              && tokenContainer.GetByDay() != null)
                resultString += " " + BuildMonthlyOnNumberedDay(tokenContainer);
            else if (freqValue == FreqToken.FreqValue.YEARLY && tokenContainer.GetByMonth() != null
                                                             && tokenContainer.GetByMontDay() != null)
                resultString += " " + BuildYearlyOnDay(tokenContainer);
            else if (freqValue == FreqToken.FreqValue.YEARLY && tokenContainer.GetByDay() != null
                                                             && tokenContainer.GetBySetPos() != null &&
                                                             tokenContainer.GetByMonth() != null)
                resultString += " " + BuildYearlyOnNumbered(tokenContainer);
            if (tokenContainer.GetStart() != null)
            {
                var ending = _buildStartDate(tokenContainer);
                if (ending != null)
                    resultString += ", " + ending;
            }

            // Endings
            if (tokenContainer.GetUntil() != null)
            {
                var ending = _buildUntilDateEnding(tokenContainer);
                if (ending != null)
                    resultString += ", " + ending;
            }
            else if (tokenContainer.GetCount() != null)
            {
                var ending = BuildCountEnding(tokenContainer);
                if (ending != null)
                    resultString += ", " + ending;
            }

            return CapitalizeFirstLetter(resultString.Trim());
        }


        private string CapitalizeFirstLetter(string result)
        {
            var firstLetter = result.Substring(0, 1);

            return firstLetter.ToUpperInvariant() + result.Substring(1);
        }

        /* ---- FREQUENCY ---- */

        private string BuildFrequency(IRRuleTokenContainer tokenContainer)
        {
            var freqValue = (FreqToken.FreqValue) tokenContainer.GetFreq().GetValue();

            var interval = 1;

            if (tokenContainer.GetInterval() != null)
                interval = (int) tokenContainer.GetInterval().GetValue();

            string value = null;
            if (interval == 1)
            {
                switch (freqValue)
                {
                    case FreqToken.FreqValue.DAILY:
                        value = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.DAILY);
                        break;
                    case FreqToken.FreqValue.WEEKLY:
                        value = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.WEEKLY);
                        break;
                    case FreqToken.FreqValue.MONTHLY:
                        value = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.MONTHLY);
                        break;
                    case FreqToken.FreqValue.YEARLY:
                        value = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.YEARLY);
                        break;
                }
            }
            else
            {
                value = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.EVERY) + " " + interval + " ";
                switch (freqValue)
                {
                    case FreqToken.FreqValue.DAILY:
                        value += _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.DAYS);
                        break;
                    case FreqToken.FreqValue.WEEKLY:
                        value += _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.WEEKS);
                        break;
                    case FreqToken.FreqValue.MONTHLY:
                        value += _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.MONTHS);
                        break;
                    case FreqToken.FreqValue.YEARLY:
                        value += _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.YEARS);
                        break;
                }
            }

            if (value == null)
                return "";

            return value;
        }

        /* ---- WEEKLY ---- */

        private string BuildWeeklyDays(IRRuleTokenContainer tokenContainer)
        {
            var byDay = tokenContainer.GetByDay();
            if (byDay == null)
                return "";

            var result = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.ON) + " ";
            result += _dayListingFormatting.FormatDayListing(((ByDayToken.DayList) byDay.GetValue()).GetDayList()
                .ToList());

            return result;
        }

        /* ---- MONTHLY ---- */

        private string BuildMonthlyOnDay(IRRuleTokenContainer tokenContainer)
        {
            var byMonthDay = tokenContainer.GetByMontDay();
            if (byMonthDay == null)
                return "";

            return _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.ON)
                   + " " + _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.DAY) + " " +
                   byMonthDay.GetValue();
        }

        private string BuildMonthlyOnNumberedDay(IRRuleTokenContainer tokenContainer)
        {
            var byDayToken = tokenContainer.GetByDay();
            var bySetPosToken = tokenContainer.GetBySetPos();
            if (byDayToken == null || bySetPosToken == null)
                return "";

            var result = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.ON);
            result += " " + TranslateSetPosNumber((int) bySetPosToken.GetValue());
            result += " " + _dateFormatting.FormatDay(((ByDayToken.DayList) byDayToken.GetValue()).GetDayList()[0]);

            return result;
        }

        /* ---- YEARLY ---- */
        private string BuildYearlyOnDay(IRRuleTokenContainer tokenContainer)
        {
            var byMonthToken = tokenContainer.GetByMonth();
            var byMonthDayToken = tokenContainer.GetByMontDay();
            if (byMonthDayToken == null || byMonthToken == null)
                return "";

            var result = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.ON);
            result += " " + _dateFormatting.FormatMonthDay(new DateTime(DateTime.Now.Year,
                (int) byMonthToken.GetValue(), (int) byMonthDayToken.GetValue()));

            return result;
        }

        private string BuildYearlyOnNumbered(IRRuleTokenContainer tokenContainer)
        {
            var byDayToken = tokenContainer.GetByDay();
            var bySetPosToken = tokenContainer.GetBySetPos();
            var byMonthToken = tokenContainer.GetByMonth();
            if (byDayToken == null || bySetPosToken == null || byMonthToken == null)
                return "";

            var result = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.ON) + " " +
                         TranslateSetPosNumber((int) bySetPosToken.GetValue());
            result += " " + _dateFormatting.FormatDay(((ByDayToken.DayList) byDayToken.GetValue()).GetDayList()[0]);
            result += " " + _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.OF);
            result += " " + _dateFormatting.FormatMonth((int) byMonthToken.GetValue());

            return result;
        }

        private string _buildStartDate(IRRuleTokenContainer pTokenContainer)
        {
            var startToken = pTokenContainer.GetStart();
            if (startToken == null) return null;
            var result = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.DTSTART);
            result += $" {_dateFormatting.FormatFullDate(((ValueWrapper) startToken.GetValue()).getLocalDateTime())}";
            return result;
        }
        /* ---- ENDINGS ---- */

        private string _buildUntilDateEnding(IRRuleTokenContainer pTokenContainer)
        {
            var untilToken = pTokenContainer.GetUntil();
            if (untilToken == null)
                return null;

            var result = _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.UNTIL);
            result += $" {_dateFormatting.FormatFullDate(((ValueWrapper) untilToken.GetValue()).getLocalDateTime())}";

            return result;
        }

        private string BuildCountEnding(IRRuleTokenContainer pTokenContainer)
        {
            var countToken = pTokenContainer.GetCount();
            if (countToken == null)
                return null;

            if ((int) countToken.GetValue() == 1)
                return null;

            return $"{countToken.GetValue()} {_fragmentTranslator.GetTranslatedFragment(ETranslationFragment.TIMES)}";
        }

        /* ---- TRANSLATE UTILS ---- */
        private string TranslateSetPosNumber(int number)
        {
            if (number == -1)
                return _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.LAST);
            if (number == 1)
                return _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.FIRST);
            if (number == 2)
                return _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.SECOND);
            if (number == 3)
                return _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.THIRD);
            if (number == 4)
                return _fragmentTranslator.GetTranslatedFragment(ETranslationFragment.FOURTH);
            return "";
        }
    }
}