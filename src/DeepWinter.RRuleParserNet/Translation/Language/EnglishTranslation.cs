using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation.Language
{
    /// <summary>
    ///  Implements the english translation.
    /// </summary>
    public class EnglishTranslation : ILanguagePackage
    {
        public CultureInfo GetCompatibleLocale()
        {
            return CultureInfo.GetCultureInfo("en");
        }

        public string GetFragment(ETranslationFragment translationFragment)
        {
            switch (translationFragment)
            {
                case ETranslationFragment.DAILY:
                    return "daily";
                case ETranslationFragment.WEEKLY:
                    return "weekly";
                case ETranslationFragment.MONTHLY:
                    return "monthly";
                case ETranslationFragment.YEARLY:
                    return "annually";
                case ETranslationFragment.DAYS:
                    return "days";
                case ETranslationFragment.WEEKS:
                    return "weeks";
                case ETranslationFragment.MONTHS:
                    return "months";
                case ETranslationFragment.YEARS:
                    return "years";
                case ETranslationFragment.DAY:
                    return "day";
                case ETranslationFragment.FIRST:
                    return "first";
                case ETranslationFragment.SECOND:
                    return "second";
                case ETranslationFragment.THIRD:
                    return "third";
                case ETranslationFragment.FOURTH:
                    return "fourth";
                case ETranslationFragment.LAST:
                    return "last";
                case ETranslationFragment.UNTIL:
                    return "until";
                case ETranslationFragment.TIMES:
                    return "times";
                case ETranslationFragment.ON:
                    return "on";
                case ETranslationFragment.EVERY:
                    return "every";
                case ETranslationFragment.OF:
                    return "of";
                case ETranslationFragment.DTSTART:
                    return "from";
                default:
                    return "";
            }
        }
    }
}