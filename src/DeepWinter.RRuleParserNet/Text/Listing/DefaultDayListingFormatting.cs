using System;
using System.Collections.Generic;
using System.Linq;
using DeepWinter.RRuleParserNet.Text.Formatting;

namespace DeepWinter.RRuleParserNet.Text.Listing
{
  /// <summary>
  /// Implements the default behavior for a listing of multiple days.
  /// Detects if the given list of days contains chains (e.g. Monday - Friday)
  /// and represents just the start end end day.
  ///
  /// The first day of week can be customized with
  /// <see cref="OrderDayOfWeek(List{DayOfWeek})" /> (Orders the days) and
  /// <see cref="GetFilledDayOfWeek"/> Returns a full list of days in the given week
  /// </summary>
  public class DefaultDayListingFormatting : IDayListingFormatting
  {
    readonly IDateFormatting _dateFormatting;
    public DefaultDayListingFormatting(IDateFormatting dateFormatting)
    {
      _dateFormatting = dateFormatting;
    }

    public string FormatDayListing(ICollection<DayOfWeek> dayOfWeeks)
    {
      var orderedDayOfWeeks = OrderDayOfWeek(dayOfWeeks.ToList());

      var chains = DetectChain(orderedDayOfWeeks);

      if (chains.Count == 1
          && chains[0].Count > 2
          && chains[0].Count == orderedDayOfWeeks.Count)
      {
        var chainContent = chains[0];
        return BuildChainRepresentation(chainContent[0], chainContent[chainContent.Count - 1]);
      }

      // Just list them
      if (orderedDayOfWeeks.Count > 2)
        return BuildMonthsShortString(orderedDayOfWeeks);

      return BuildMonthsString(orderedDayOfWeeks);

    }

    /// <summary>
    /// Is able to detect chains from the given list of days.
    /// Warning: Detects a list of Monday, Tuesday as a chain
    /// </summary>
    /// <param name="dayOfWeeks">Days to detect from</param>
    /// <returns>List of chains of days.</returns>
    private List<List<DayOfWeek>> DetectChain(List<DayOfWeek> dayOfWeeks)
    {
      var fullDays = GetFilledDayOfWeek().ToList();
      var chains = new List<List<DayOfWeek>>();

      int currentChainlength = 0;
      int? lastChainOrdinal = null;
      var currentChain = new List<DayOfWeek>();

      for (int i = 0; i < dayOfWeeks.Count; i++)
      {
        var currentDayOfWeek = dayOfWeeks[i];
        int ordinalOfDay = fullDays.IndexOf(currentDayOfWeek);

        // Chain is broken
        if (lastChainOrdinal.HasValue && lastChainOrdinal.Value != (ordinalOfDay - 1))
        {
          chains.Add(currentChain);
          currentChain = null;
          currentChainlength = 0;
          lastChainOrdinal = null;
        }

        // Chain has not started yet
        if (!lastChainOrdinal.HasValue)
        {
          currentChain = new List<DayOfWeek>();
          lastChainOrdinal = ordinalOfDay;
          currentChainlength++;
          currentChain.Add(currentDayOfWeek);
        }
        else if (lastChainOrdinal.Value == ordinalOfDay - 1)
        {
          lastChainOrdinal = ordinalOfDay;
          currentChainlength++;
          currentChain.Add(currentDayOfWeek);

          // Entire input list is a chain
          if (i == (dayOfWeeks.Count - 1))
            chains.Add(currentChain);
        }
      }

      return chains;
    }

    private string BuildMonthsShortString(List<DayOfWeek> dayOfWeeks)
    {
      return string.Join(", ", dayOfWeeks.Select(dayOfWeek => _dateFormatting.FormatDayShort(dayOfWeek)).ToArray());
    }

    private string BuildMonthsString(List<DayOfWeek> dayOfWeeks)
    {
      return string.Join(", ", dayOfWeeks.Select(dayOfWeek => _dateFormatting.FormatDay(dayOfWeek)).ToArray());
    }

    private string BuildChainRepresentation(DayOfWeek start, DayOfWeek end)
    {
      return _dateFormatting.FormatDay(start) + " - " + _dateFormatting.FormatDay(end);
    }

    /// <summary>
    /// Orders the given DayOfWeeks by the implemented algorithm.
    /// FirstDay of week will be set by locale of <see cref="IDateFormatting.GetFragmentTranslator"/>
    /// </summary>
    /// <param name="daysOfWeek">List to order.</param>
    /// <returns>New ordered list.</returns>
    protected List<DayOfWeek> OrderDayOfWeek(List<DayOfWeek> daysOfWeek)
    {
      // get first day of week from current culture
      var firstDayOfWeek =
        _dateFormatting.GetFragmentTranslator()
        .GetCompatibleLocale()
        .DateTimeFormat.FirstDayOfWeek;

      // all days of week ordered from first day of week
      var daysOfWeekOrdered = daysOfWeek.OrderBy(x => (x - firstDayOfWeek + 7) % 7).ToList();

      return daysOfWeekOrdered;
    }

    /// <summary>
    /// Returns a list with all possible day of weeks in the required order.
    /// This method is protected to modify the first day of week.
    /// </summary>
    /// <returns>List of days</returns>
    protected List<DayOfWeek> GetFilledDayOfWeek()
    {
      return OrderDayOfWeek(Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList());
    }
  }
}
