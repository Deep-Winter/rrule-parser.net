using System;
using DeepWinter.RRuleParserNet.Tokenizer;
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
  }
}
