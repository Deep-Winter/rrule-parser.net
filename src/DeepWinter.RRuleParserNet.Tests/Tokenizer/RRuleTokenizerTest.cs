using System;
using DeepWinter.RRuleParserNet.Tokenizer;
using DeepWinter.RRuleParserNet.Tokenizer.Exception;
using DeepWinter.RRuleParserNet.Tokenizer.Token;
using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;
using NUnit.Framework;

namespace DeepWinter.RRuleParserNet.Tests.Tokenizer
{
  public class RRuleTokenizerTest
  {
    private static IValueParser valueParser = new RRuleValueParser();
    private static IRRuleValidator rruleValidator = new RRuleValidator();
    private static IRRuleTokenizer tokenizer = new RRuleTokenizer(valueParser, rruleValidator);

    [Test]
    public void TestFreq()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY");

      Assert.AreEqual(1, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetFreq());
      Assert.AreEqual(FreqToken.FreqValue.DAILY, tokenContainer.GetFreq().GetValue());
    }

    [Test]
    public void TestUntil()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;UNTIL=20181023T220000Z");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetUntil());
      Assert.AreEqual(new DateTime(2018, 10, 23, 22, 0, 0),
        ((UntilToken.ValueWrapper)tokenContainer.GetUntil().GetValue()).getLocalDateTime());
    }

    [Test]
    public void TestCount()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;COUNT=1");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetCount());
      Assert.AreEqual(1, (int)tokenContainer.GetCount().GetValue());
    }

    [Test]
    public void TestInterval()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;INTERVAL=1");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetInterval());
      Assert.AreEqual(1, (int)tokenContainer.GetInterval().GetValue());
    }

    [Test]
    public void TestByDay()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;BYDAY=MO,TU,WE,SA");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetByDay());
      Assert.AreEqual(4, ((ByDayToken.DayList)tokenContainer.GetByDay().GetValue()).GetDayList().Count);
    }

    [Test]
    public void testByMonthDay()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;BYMONTHDAY=2");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetByMontDay());
      Assert.AreEqual(2, (int)tokenContainer.GetByMontDay().GetValue());
    }

    [Test]
    public void TestByMonth()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;BYMONTH=12");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetByMonth());
      Assert.AreEqual(12, tokenContainer.GetByMonth().GetValue());
    }

    [Test]
    public void TestBySetPos()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;BYSETPOS=10");

      Assert.AreEqual(2, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetBySetPos());
      Assert.AreEqual(10, (int)tokenContainer.GetBySetPos().GetValue());
    }

    [Test]
    public void TestComplex()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=YEARLY;BYDAY=TU;BYSETPOS=1;BYMONTH=4;UNTIL=20181023T220000Z");

      Assert.AreEqual(5, tokenContainer.RuleCount());
      Assert.NotNull(tokenContainer.GetFreq());
      Assert.NotNull(tokenContainer.GetByDay());
      Assert.NotNull(tokenContainer.GetBySetPos());
      Assert.NotNull(tokenContainer.GetByMonth());
      Assert.NotNull(tokenContainer.GetUntil());
      Assert.AreEqual(FreqToken.FreqValue.YEARLY, tokenContainer.GetFreq().GetValue());
    }

    [Test]
    public void TestSimpleInvalid()
    {
      Assert.Throws(typeof(RRuleTokenizeException), () =>
      {
        tokenizer.Tokenize("FREQ=NOFREQVALATALL");
      });
    }
  }
}
