using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation.Language
{
    /// <summary>
    ///  Implements the english translation.
    /// </summary>
    public class DutchTranslation : ILanguagePackage
    {
        public CultureInfo GetCompatibleLocale()
        {
            return CultureInfo.GetCultureInfo("nl");
        }

        public string GetFragment(ETranslationFragment translationFragment)
        {
            switch (translationFragment)
            {
                case ETranslationFragment.DAILY:
                    return "dagelijks";
                case ETranslationFragment.WEEKLY:
                    return "wekelijks";
                case ETranslationFragment.MONTHLY:
                    return "maandelijks";
                case ETranslationFragment.YEARLY:
                    return "jaarlijks";
                case ETranslationFragment.DAYS:
                    return "dagen";
                case ETranslationFragment.WEEKS:
                    return "weken";
                case ETranslationFragment.MONTHS:
                    return "maanden";
                case ETranslationFragment.YEARS:
                    return "jaren";
                case ETranslationFragment.DAY:
                    return "dag";
                case ETranslationFragment.FIRST:
                    return "eerste";
                case ETranslationFragment.SECOND:
                    return "tweede";
                case ETranslationFragment.THIRD:
                    return "derde";
                case ETranslationFragment.FOURTH:
                    return "vierde";
                case ETranslationFragment.LAST:
                    return "laatste";
                case ETranslationFragment.UNTIL:
                    return "tot";
                case ETranslationFragment.TIMES:
                    return "maal";
                case ETranslationFragment.ON:
                    return "op";
                case ETranslationFragment.EVERY:
                    return "elke";
                case ETranslationFragment.OF:
                    return "van";
                case ETranslationFragment.DTSTART:
                    return "vanaf";
                default:
                    return "";
            }
        }
    }
}