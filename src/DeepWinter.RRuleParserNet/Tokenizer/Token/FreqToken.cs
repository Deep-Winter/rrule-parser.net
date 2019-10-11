using System;
namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class FreqToken : RRuleToken<FreqToken.FreqValue>
  {
    public const string NAME = "FREQ";

    public FreqToken(FreqValue value) : base(value)
    {
    }

    public override string GetName() => NAME;

    public enum FreqValue
    {
      SECONDLY, MINUTELY,
      HOURLY, DAILY,
      WEEKLY, MONTHLY,
      YEARLY
    }
  }
}
