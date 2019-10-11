using System;
using DeepWinter.RRuleParserNet.Text;
using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;
using DeepWinter.RRuleParserNet.Tokenizer;
using DeepWinter.RRuleParserNet.Translation.Language;
using DeepWinter.RRuleParserNet.Translation;
using NUnit.Framework;

namespace DeepWinter.RRuleParserNet.Tests.Text
{
  [TestFixture]
  public class TextBuilderTest
  {
    private static IValueParser valueParser = new RRuleValueParser();
    private static IRRuleTokenizer tokenizer = new RRuleTokenizer(valueParser, new RRuleValidator());
    private static TextBuilder textBuilder = new TextBuilder(new LanguagePackageFragmentTranslator(new EnglishTranslation()));


    [Test(Description = "Test some cases for the translation process"), Sequential]
    public void TestCases(
      [Values(
      "FREQ=DAILY;INTERVAL=5",
      "FREQ=WEEKLY;INTERVAL=5",
      "FREQ=MONTHLY;INTERVAL=5",
      "FREQ=YEARLY;INTERVAL=5",
      "FREQ=DAILY;INTERVAL=1",
      "FREQ=WEEKLY;INTERVAL=1",
      "FREQ=MONTHLY;INTERVAL=1",
      "FREQ=YEARLY;INTERVAL=1",
      "FREQ=WEEKLY;INTERVAL=1;BYDAY=MO,TU",
      "FREQ=WEEKLY;INTERVAL=2;BYDAY=MO,TU",
      "FREQ=WEEKLY;INTERVAL=2;BYDAY=MO,TU,WE,SA",
      "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=5",
      "FREQ=MONTHLY;INTERVAL=1;BYMONTHDAY=15",
      "FREQ=MONTHLY;INTERVAL=2;BYMONTHDAY=15",
      "FREQ=MONTHLY;INTERVAL=2;BYDAY=MO;BYSETPOS=-1",
      "FREQ=MONTHLY;INTERVAL=2;BYDAY=MO;BYSETPOS=1",
      "FREQ=MONTHLY;INTERVAL=2;BYDAY=SA;BYSETPOS=3",
      "FREQ=YEARLY;BYMONTH=1;BYMONTHDAY=1",
      "FREQ=YEARLY;BYMONTH=4;BYMONTHDAY=5",
      "FREQ=YEARLY;BYDAY=SU;BYSETPOS=1;BYMONTH=1",
      "FREQ=YEARLY;BYDAY=WE;BYSETPOS=-1;BYMONTH=4",
      "FREQ=DAILY;INTERVAL=1;COUNT=2",
      "FREQ=WEEKLY;INTERVAL=1;COUNT=1",
      "FREQ=MONTHLY;INTERVAL=1;UNTIL=20181023T220000Z"

      )]
      string rrule,

      [Values(
        "Every 5 days",
        "Every 5 weeks",
        "Every 5 months",
        "Every 5 years",
        "Daily",
        "Weekly",
        "Monthly",
        "Annually",
        "Weekly on Monday, Tuesday",
        "Every 2 weeks on Monday, Tuesday",
        "Every 2 weeks on Mon, Tue, Wed, Sat",
         "Monthly on day 5",
        "Monthly on day 15",
        "Every 2 months on day 15",
        "Every 2 months on last Monday",
        "Every 2 months on first Monday",
        "Every 2 months on third Saturday",
        "Annually on January 1",
        "Annually on April 5",
        "Annually on first Sunday of January",
        "Annually on last Wednesday of April",
        "Daily, 2 times",
        "Weekly",
        "Monthly, until 10/23/2018"

      )]
      string expectedResult)
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize(rrule);
      Assert.AreEqual(expectedResult, textBuilder.BuildText(tokenContainer));
    }
  }
}
