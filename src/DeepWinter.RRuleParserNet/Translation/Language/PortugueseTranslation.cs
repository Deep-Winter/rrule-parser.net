using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation.Language
{
    /// <summary>
    /// Implements the Brazilian Portuguese Translation
    /// </summary>
    public class PortugueseTranslation : ILanguagePackage
    {
        public CultureInfo GetCompatibleLocale()
        {
            return CultureInfo.GetCultureInfo("pt-BR");
        }

        public string GetFragment(ETranslationFragment translationFragment)
        {
            switch (translationFragment)
            {
                case ETranslationFragment.DAILY:
                    return "diariamente";
                case ETranslationFragment.WEEKLY:
                    return "semanalmente";
                case ETranslationFragment.MONTHLY:
                    return "mensalmente";
                case ETranslationFragment.YEARLY:
                    return "anualmente";
                case ETranslationFragment.DAYS:
                    return "dias";
                case ETranslationFragment.WEEKS:
                    return "semanas";
                case ETranslationFragment.MONTHS:
                    return "meses";
                case ETranslationFragment.YEARS:
                    return "anos";
                case ETranslationFragment.DAY:
                    return "dia";
                case ETranslationFragment.FIRST:
                    return "primeiro";
                case ETranslationFragment.SECOND:
                    return "segundo";
                case ETranslationFragment.THIRD:
                    return "terceiro";
                case ETranslationFragment.FOURTH:
                    return "quarto";
                case ETranslationFragment.LAST:
                    return "último";
                case ETranslationFragment.UNTIL:
                    return "até";
                case ETranslationFragment.TIMES:
                    return "vezes";
                case ETranslationFragment.ON:
                    return "no";
                case ETranslationFragment.EVERY:
                    return "a cada";
                case ETranslationFragment.OF:
                    return "de";
                default:
                    return "";
            }
        }
    }
}
