using System;
namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class ByMonthDayToken : RRuleToken<int>
  {
    public const string NAME = "BYMONTHDAY";

    public ByMonthDayToken(int monthDay) : base(monthDay)
    {

    }

    public override string GetName() => NAME;
  }
}
