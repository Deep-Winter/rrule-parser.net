using System;
namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class BySetPosToken : RRuleToken<int>
  {
    public const string NAME = "BYSETPOS";

    public BySetPosToken(int value) : base(value)
    {
    }

    public override string GetName() => NAME;
  }
}
