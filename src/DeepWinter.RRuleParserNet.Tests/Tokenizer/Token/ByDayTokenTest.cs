using System;
using DeepWinter.RRuleParserNet.Tokenizer.Token;
using NUnit.Framework;

namespace DeepWinter.RRuleParserNet.Tests.Tokenizer.Token
{
  public class ByDayTokenTest
  {
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestGetByDayOfWeekSingle()
    {

      Assert.AreEqual("MO", ByDayToken.GetByDayOfWeek(DayOfWeek.Monday));
      Assert.AreEqual("FR", ByDayToken.GetByDayOfWeek(DayOfWeek.Friday));
    }
  }
}

