using System;
using System.Collections.Generic;

namespace DeepWinter.RRuleParserNet.Text.Listing
{
  /// <summary>
  ///  Describes an interface which is able to format a given list of
  /// <see cref="DayOfWeek" /> into any format.
  /// </summary>
  public interface IDayListingFormatting
    {
        /// <summary>
        /// Formats the given list of DayOfWeek into a specific format.
        /// </summary>
        /// <param name="dayOfWeeks">List of DayOfWeek to format.</param>
        /// <returns>Formatted list.</returns>
        string FormatDayListing(ICollection<DayOfWeek> dayOfWeeks);
    }
}