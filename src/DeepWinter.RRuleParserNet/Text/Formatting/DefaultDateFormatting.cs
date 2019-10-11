using System;
using DeepWinter.RRuleParserNet.Translation;

namespace DeepWinter.RRuleParserNet.Text.Formatting
{
  public class DefaultDateFormatting : IDateFormatting
  {
    readonly IFragmentTranslator _fragmentTranslator;

    public DefaultDateFormatting(IFragmentTranslator fragmentTranslator)
    {
      _fragmentTranslator = fragmentTranslator;
    }

    public string FormatDay(DayOfWeek dayOfWeek)
    {
      return _fragmentTranslator.GetCompatibleLocale().DateTimeFormat.GetDayName(dayOfWeek);
    }

    public string FormatDayShort(DayOfWeek dayOfWeek)
    {
      return _fragmentTranslator.GetCompatibleLocale().DateTimeFormat.GetAbbreviatedDayName(dayOfWeek);
    }

    public string FormatFullDate(DateTime localDate)
    {
      return localDate.ToString("D", _fragmentTranslator.GetCompatibleLocale());
    }

    public string FormatMonth(int month)
    {
      return _fragmentTranslator.GetCompatibleLocale().DateTimeFormat.GetMonthName(month);
    }

    public string FormatMonthDay(DateTime monthDay)
    {
      return monthDay.ToString("M", _fragmentTranslator.GetCompatibleLocale());
    }

    public IFragmentTranslator GetFragmentTranslator() => _fragmentTranslator;
  }
}
