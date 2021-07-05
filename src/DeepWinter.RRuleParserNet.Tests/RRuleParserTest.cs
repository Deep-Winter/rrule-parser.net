using System;
using DeepWinter.RRuleParserNet.Translation.Language;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;

namespace DeepWinter.RRuleParserNet.Tests
{
  public class RRuleParserTest
  {

    [SetUp]
    public void Setup()
    {

    }
    [Test]
    public void TestWithDtSTart()
    {
        var rRuleParser = new RRuleParser( new DutchTranslation());
        var parseResult = rRuleParser.ParseRRule("FREQ=DAILY;DtSTART=20201213T000000;UNTIL=20201214T000000");
        Assert.AreEqual("Dagelijks, vanaf zondag 13 december 2020, tot maandag 14 december 2020", parseResult);

    }
    [Test]
    public void TestGeneralFunctionality()
    {

      // Creates a rrule parser with english translation
      RRuleParser ruleParser = new RRuleParser();

      string parseResult = ruleParser.ParseRRule("FREQ=MONTHLY;BYSETPOS=4;BYDAY=SU;INTERVAL=5");

      // Every 5 months on fourth Sun
      Assert.AreEqual(parseResult, "Every 5 months on fourth Sunday");

      // assert
      Console.WriteLine($"Created result {parseResult}");
    }

    [Test]
    public void TestUntilAlt()
    {

      // Creates a rrule parser with english translation
      RRuleParser ruleParser = new RRuleParser();

      string parseResult = ruleParser.ParseRRule("FREQ=MONTHLY;BYSETPOS=4;BYDAY=SU;INTERVAL=5;UNTIL=20200427T165449");

      // Every 5 months on fourth Sun
      Assert.AreEqual(parseResult, "Every 5 months on fourth Sunday, until Monday, April 27, 2020");

      // assert
      Console.WriteLine($"Created result {parseResult}");
    }

    [Test]
    public void TestUntil()
    {

      // Creates a rrule parser with english translation
      RRuleParser ruleParser = new RRuleParser();

      string parseResult = ruleParser.ParseRRule("FREQ=MONTHLY;BYSETPOS=4;BYDAY=SU;INTERVAL=5;UNTIL=20200427T165449Z");

      // Every 5 months on fourth Sun
      Assert.AreEqual(parseResult, "Every 5 months on fourth Sunday, until Monday, April 27, 2020");

      // assert
      Console.WriteLine($"Created result {parseResult}");
    }
    
    [Test]
    public void TestTryParseFail()
    {
      // Creates a rrule parser with english translation
      RRuleParser ruleParser = new RRuleParser();
      string humanReadable;
      var result = ruleParser.TryParseRRule("FREQ=MONTHLY;BYSETPOS=4;BYDAY=;INTERVAL=5;UNTIL=20200427T165449Z", out humanReadable);
     
      Assert.IsFalse(result);
    }
  }
}
