using System;
using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation.Language
{
  public class GermanTranslation : ILanguagePackage
  {
  
    public CultureInfo GetCompatibleLocale()
    {
      return CultureInfo.GetCultureInfo("de");
    }

    public string GetFragment(ETranslationFragment translationFragment)
    {
      switch (translationFragment)
      {
        case ETranslationFragment.DAILY:
          return "täglich";
        case ETranslationFragment.WEEKLY:
          return "wöchentlich";
        case ETranslationFragment.MONTHLY:
          return "monatlich";
        case ETranslationFragment.YEARLY:
          return "jährlich";
        case ETranslationFragment.DAYS:
          return "Tage";
        case ETranslationFragment.WEEKS:
          return "Wochen";
        case ETranslationFragment.MONTHS:
          return "Monate";
        case ETranslationFragment.YEARS:
          return "Jahre";
        case ETranslationFragment.DAY:
          return "Tag";
        case ETranslationFragment.FIRST:
          return "ersten";
        case ETranslationFragment.SECOND:
          return "zweiten";
        case ETranslationFragment.THIRD:
          return "dritten";
        case ETranslationFragment.FOURTH:
          return "vierten";
        case ETranslationFragment.LAST:
          return "letzten";
        case ETranslationFragment.UNTIL:
          return "bis";
        case ETranslationFragment.TIMES:
          return "mal";
        case ETranslationFragment.ON:
          return "am";
        case ETranslationFragment.EVERY:
          return "jedem";
        case ETranslationFragment.OF:
          return "der";
        case ETranslationFragment.DTSTART:
            return "vom";
                default:
          return "";
      }
    }
  }
}
