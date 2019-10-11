using System;
using DeepWinter.RRuleParserNet.Text.Formatting;
using DeepWinter.RRuleParserNet.Text.Listing;
using DeepWinter.RRuleParserNet.Translation.Language;
using DeepWinter.RRuleParserNet.Translation;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DeepWinter.RRuleParserNet.Tests.Text.Listing
{
  public class DefaultDayListingFormattingTest
  {
    private static IDayListingFormatting dayListingFormatting = new DefaultDayListingFormatting(
      new DefaultDateFormatting(new LanguagePackageFragmentTranslator(new EnglishTranslation())));


    [Test, Sequential]
    public void TestChainDetecting(
      [Values(
        "Monday - Friday",
        "Monday, Tuesday",
        "Monday - Wednesday",
        "Sun, Mon, Tue, Wed, Fri, Sat",
        "Sun, Mon, Wed, Fri",
        "Sunday - Saturday",
        "Mon, Tue, Thu, Fri",
        "Mon, Tue, Wed, Sat"
      )]
      string expectingString,
      [Values(
        new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday },
      new[] { DayOfWeek.Monday, DayOfWeek.Tuesday  },
      new [] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday },
      new []{ DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday },
      new[] { DayOfWeek.Monday,  DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday },
      new [] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday },
      new[] { DayOfWeek.Monday, DayOfWeek.Tuesday,DayOfWeek.Thursday, DayOfWeek.Friday },
      new [] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Saturday }

      )]
      DayOfWeek[] pDayOfWeekInput)
    {
      Assert.AreEqual(expectingString, dayListingFormatting.FormatDayListing(pDayOfWeekInput.ToList()));
    }
  }
}
