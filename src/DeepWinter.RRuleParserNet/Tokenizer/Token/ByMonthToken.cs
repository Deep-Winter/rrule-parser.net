namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class ByMonthToken : RRuleToken<int>
    {
        public const string NAME = "BYMONTH";

        public ByMonthToken(int value) : base(value)
        {
        }

        public override string GetName()
        {
            return NAME;
        }
    }
}