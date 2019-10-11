using System;
using DeepWinter.RRuleParserNet.Tokenizer;
using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;
using NUnit.Framework;

namespace DeepWinter.RRuleParserNet.Tests.Tokenizer
{
  public class RRuleTokenContainerTest
  {
    private static IValueParser valueParser = new RRuleValueParser();
    private static IRRuleTokenizer tokenizer = new RRuleTokenizer(valueParser, new RRuleValidator());

    [SetUp]
    public void Setup()
    {

    }

    [Test(Description = "Test a simple example")]
    public void TestSimpleContainer()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=DAILY;INTERVAL=1");

      Assert.AreEqual(2, tokenContainer.RuleCount());
    }

    [Test(Description = "Test a complex example")]
    public void TestComplexContainer()
    {
      IRRuleTokenContainer tokenContainer = tokenizer.Tokenize("FREQ=YEARLY;BYDAY=TU;BYSETPOS=1;BYMONTH=4;UNTIL=20181023T220000Z");

      Assert.AreEqual(5, tokenContainer.RuleCount());
    }

    [Test(Description = "Test equals method with same container")]
    public void TestEqualsMethodSameContainer()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("FREQ=DAILY;INTERVAL=1");
      Assert.AreEqual(firstPart, firstPart);
    }

    [Test(Description = "Test equals method with swapped container")]
    public void TestEqualsMethodSwapped()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("FREQ=DAILY;INTERVAL=1");
      IRRuleTokenContainer secondPart = tokenizer.Tokenize("INTERVAL=1;FREQ=DAILY");

      Assert.AreEqual(firstPart, secondPart);
    }

    [Test(Description = "Test equals method with different sized container")]
    public void TestEqualsMethodComplex()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("FREQ=DAILY;INTERVAL=1");
      IRRuleTokenContainer secondPart = tokenizer.Tokenize("INTERVAL=1;FREQ=DAILY;BYSETPOS=1");

      Assert.AreNotEqual(firstPart, secondPart);
    }

    [Test(Description = "Test equals method with large swapped container")]
    public void TestEqualsMethodLargeSwapped()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("BYSETPOS=1;FREQ=DAILY;INTERVAL=1;BYMONTHDAY=1");
      IRRuleTokenContainer secondPart = tokenizer.Tokenize("INTERVAL=1;BYMONTHDAY=1;FREQ=DAILY;BYSETPOS=1");

      Assert.AreEqual(firstPart, secondPart);
    }

    [Test(Description = "Test equals method with different values")]
    public void TestEqualsMethodDifferentValues()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("BYSETPOS=1;FREQ=WEEKLY;INTERVAL=1;BYMONTHDAY=1");
      IRRuleTokenContainer secondPart = tokenizer.Tokenize("INTERVAL=1;BYMONTHDAY=1;FREQ=YEARLY;BYSETPOS=1");

      Assert.AreNotEqual(firstPart, secondPart);
    }

    [Test(Description = "Test toString method")]
    public void TestToStringMethod(
      [Values(
      "FREQ=WEEKLY;BYDAY=MO,TU",
      "FREQ=YEARLY;BYMONTHDAY=1",
      "FREQ=YEARLY;BYSETPOS=1",
      "FREQ=YEARLY;COUNT=1",
      "FREQ=YEARLY;INTERVAL=1",
      "FREQ=YEARLY;UNTIL=20181023T220000Z")]
      string input)
    {
      IRRuleTokenContainer container = tokenizer.Tokenize(input);
      Assert.AreEqual(input, container.ToString());
    }

    [Test]
    public void TestMergeSimple()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("FREQ=WEEKLY;INTERVAL=1");
      IRRuleTokenContainer secondPart = tokenizer.Tokenize("FREQ=YEARLY;INTERVAL=1;BYMONTHDAY=1;BYSETPOS=1");

      // Merge secondPart into firstPart
      firstPart.Merge(secondPart);

      Assert.NotNull(firstPart.GetFreq());
      Assert.NotNull(firstPart.GetByMontDay());
      Assert.NotNull(firstPart.GetBySetPos());
      Assert.NotNull(firstPart.GetByMontDay());

      Assert.AreEqual(secondPart.GetByMontDay(), firstPart.GetByMontDay());
      Assert.AreEqual(secondPart.GetBySetPos(), firstPart.GetBySetPos());
    }

    [Test]
    public void TestMergeDoNotOverride()
    {
      IRRuleTokenContainer firstPart = tokenizer.Tokenize("FREQ=WEEKLY;INTERVAL=1");
      IRRuleTokenContainer secondPart = tokenizer.Tokenize("FREQ=YEARLY;INTERVAL=1;BYMONTHDAY=1;BYSETPOS=1");

      // Merge secondPart into firstPart
      firstPart.Merge(secondPart);

      Assert.NotNull(firstPart.GetFreq());
      Assert.AreNotEqual(secondPart.GetFreq(), firstPart.GetFreq());
      Assert.AreNotEqual(secondPart.GetInterval(), firstPart.GetInterval());
    }
  }
}
