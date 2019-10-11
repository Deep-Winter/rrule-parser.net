using System;
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
  }
}
