using System;
namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class CountToken : RRuleToken<int>
  {
    public const string NAME = "COUNT";

    public CountToken(int value) : base(value)
    {
    }

    public override string GetName() => NAME;
  }
}
