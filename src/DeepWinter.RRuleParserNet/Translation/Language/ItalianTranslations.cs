using System;
using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation.Language
{
  /// <summary>
  ///  Implements the italian translation.
  /// </summary>
  public class ItalianTranslation : ILanguagePackage
  {
    public CultureInfo GetCompatibleLocale()
    {
      return CultureInfo.GetCultureInfo("it");
    }

    public string GetFragment(ETranslationFragment translationFragment)
    {
      switch (translationFragment)
      {
        case ETranslationFragment.DAILY:
          return "ogni giorno";
        case ETranslationFragment.WEEKLY:
          return "ogni settimana";
        case ETranslationFragment.MONTHLY:
          return "ogni mese";
        case ETranslationFragment.YEARLY:
          return "ogni anno";
        case ETranslationFragment.DAYS:
          return "giorni";
        case ETranslationFragment.WEEKS:
          return "settimane";
        case ETranslationFragment.MONTHS:
          return "mesi";
        case ETranslationFragment.YEARS:
          return "anni";
        case ETranslationFragment.DAY:
          return "giorno";
        case ETranslationFragment.FIRST:
          return "primo/a";
        case ETranslationFragment.SECOND:
          return "secondo/a";
        case ETranslationFragment.THIRD:
          return "terzo/a";
        case ETranslationFragment.FOURTH:
          return "quarto/a";
        case ETranslationFragment.LAST:
          return "ultimo";
        case ETranslationFragment.UNTIL:
          return "fino a";
        case ETranslationFragment.TIMES:
          return "volte";
        case ETranslationFragment.ON:
          return "il/la";
        case ETranslationFragment.EVERY:
          return "ogni";
        case ETranslationFragment.OF:
          return "di";
        case ETranslationFragment.DTSTART:
            return "dal";
                default:
          return "";
      }
    }
  }
}