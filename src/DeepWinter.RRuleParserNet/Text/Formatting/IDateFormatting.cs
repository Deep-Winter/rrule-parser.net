using System;
using DeepWinter.RRuleParserNet.Translation;

namespace DeepWinter.RRuleParserNet.Text.Formatting
{
    public interface IDateFormatting
    {
        /// <summary>
        /// Formats a full date, which contains year, month and day into
        /// a readable text depending on the implementation.
        /// </summary>
        /// <param name="localDate">The date to format.</param>
        /// <returns>Date in the desired format.</returns>
        string FormatFullDate(DateTime localDate);

        /// <summary>
        /// Formats a date which just contains month and day into
        /// </summary>
        /// <param name="monthDay">The MonthDay to format.</param>
        /// <returns>in the desired format.</returns>
        string FormatMonthDay(DateTime monthDay);

        /// <summary>
        /// Formats a date which just contains the month into
        /// a readable text depending on the implementation.
        /// </summary>
        /// <param name="month">The month to format.</param>
        /// <returns>in the desired format.</returns>
        string FormatMonth(int month);

        /// <summary>
        /// Formats a date which just contains the day into
        /// a readable text depending on the implementation.
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        string FormatDay(DayOfWeek dayOfWeek);

        /// <summary>
        /// Formats a date which just contains the day into
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        string FormatDayShort(DayOfWeek dayOfWeek);

        /// <summary>
        /// Gets the used fragment translator
        /// </summary>
        /// <returns></returns>
        IFragmentTranslator GetFragmentTranslator();
    }
}