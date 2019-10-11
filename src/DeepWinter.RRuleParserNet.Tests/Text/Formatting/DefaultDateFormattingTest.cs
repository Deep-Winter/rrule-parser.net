using System;
using DeepWinter.RRuleParserNet.Text.Formatting;
using DeepWinter.RRuleParserNet.Translation;
using DeepWinter.RRuleParserNet.Translation.Language;
using NUnit.Framework;

namespace DeepWinter.RRuleParserNet.Tests.Text.Formatting
{
  public class DefaultDateFormattingTest
  {
    [Test]
    public void TestFullDateFormatting()
    {
      IDateFormatting dateFormatting = new DefaultDateFormatting(new LanguagePackageFragmentTranslator(new EnglishTranslation()));

      var formatted = dateFormatting.FormatFullDate(new DateTime(2018, 1, 1));

      Assert.AreEqual("1/1/2018", formatted);
    }

    [Test]
    public void TestMonthDayFormatting()
    {
      IDateFormatting dateFormatting = new DefaultDateFormatting(new LanguagePackageFragmentTranslator(new EnglishTranslation()));

      var formatted = dateFormatting.FormatMonthDay(new DateTime(2018, 1, 1));

      Assert.AreEqual("January 1", formatted);
    }
  }
}
