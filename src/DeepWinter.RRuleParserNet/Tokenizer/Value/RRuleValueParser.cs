using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DeepWinter.RRuleParserNet.Tokenizer.Exception;
using DeepWinter.RRuleParserNet.Tokenizer.Token;

namespace DeepWinter.RRuleParserNet.Tokenizer.Value
{
  public class RRuleValueParser : IValueParser
  {
    public RRuleValueParser()
    {
    }

    public object ParseValue(ERRuleToken rRuleToken, string value)
    {
      try
      {
        if (rRuleToken == ERRuleToken.Freq)
          return GetFreqValue(value);

        if (rRuleToken == ERRuleToken.Until)
          return GetUntilValue(value);

        if (rRuleToken == ERRuleToken.Count)
          return ParseInteger(value);

        if (rRuleToken == ERRuleToken.Interval)
          return ParseInteger(value);

        if (rRuleToken == ERRuleToken.ByDay)
          return GetByDay(value);

        if (rRuleToken == ERRuleToken.ByMonth)
          return ParseInteger(value);

        if (rRuleToken == ERRuleToken.ByMonthDay)
          return ParseInteger(value);

        if (rRuleToken == ERRuleToken.BySetPos)
          return ParseInteger(value);

        throw new System.Exception($"Unknown token {rRuleToken.Name.ToUpperInvariant()}");
      }
      catch(RRuleTokenizeException error)
      {
        throw new RRuleTokenizeException($"Value {value} is invalid for key {rRuleToken.Name.ToUpperInvariant()}: {error.Message}");
      }
      catch (System.Exception error)
      {
        throw new RRuleTokenizeException($"Value {value} is invalid for key {rRuleToken.Name.ToUpperInvariant()}: {error.Message}");
      }
    }

    private FreqToken.FreqValue GetFreqValue(string value)
    {
      switch (value)
      {
        case "SECONDLY":
          return FreqToken.FreqValue.SECONDLY;
        case "MINUTELY":
          return FreqToken.FreqValue.MINUTELY;
        case "HOURLY":
          return FreqToken.FreqValue.HOURLY;
        case "DAILY":
          return FreqToken.FreqValue.DAILY;
        case "WEEKLY":
          return FreqToken.FreqValue.WEEKLY;
        case "MONTHLY":
          return FreqToken.FreqValue.MONTHLY;
        case "YEARLY":
          return FreqToken.FreqValue.YEARLY;
        default:
          throw new RRuleTokenizeException($"Unkown FREQ value: {value}.");
      }
    }

    private UntilToken.ValueWrapper GetUntilValue(string value)
    {
      try
      {
        return new UntilToken.ValueWrapper(DateTime.ParseExact(value, UntilToken.DATE_FORMAT, CultureInfo.InvariantCulture));
      }
      catch (System.Exception error)
      {
        throw new RRuleTokenizeException($"Cannot parse UNTIL value: {error.Message}.");
      }
    }

    private int ParseInteger(string value)
    {
      try
      {
        return int.Parse(value);
      }
      catch (System.Exception error)
      {
        throw new RRuleTokenizeException($"Cannot parse {value} as int: {error.Message}.");
      }
    }

    private ByDayToken.DayList GetByDay(string value)
    {
      string[] parts = value.Split(',').Select(str => str.Trim().ToUpperInvariant()).ToArray();

      var days = new List<DayOfWeek>(7);

      foreach(var part in parts)
      {
        switch (part)
        {
          case "MO":
            days.Add(DayOfWeek.Monday);
            break;
          case "TU":
            days.Add(DayOfWeek.Tuesday);
            break;
          case "WE":
            days.Add(DayOfWeek.Wednesday);
            break;
          case "TH":
            days.Add(DayOfWeek.Thursday);
            break;
          case "FR":
            days.Add(DayOfWeek.Friday);
            break;
          case "SA":
            days.Add(DayOfWeek.Saturday);
            break;
          case "SU":
            days.Add(DayOfWeek.Sunday);
            break;
        }
      }

      if (parts.Length != days.Count())
        throw new RRuleTokenizeException($"Cannot parse BYDAY value {value}.");

      return new ByDayToken.DayList(days);
    }
  }
}
