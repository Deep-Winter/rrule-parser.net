using System;
namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class IntervalToken : RRuleToken<int>
  {
    public const string NAME = "INTERVAL";

    public IntervalToken(int value) : base(value)
    {
    }

    public override string GetName() => NAME;
  }
}
