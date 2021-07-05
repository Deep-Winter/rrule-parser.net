namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class UntilToken : RRuleToken<ValueWrapper>
    {
        public const string NAME = "UNTIL";
        public const string DATE_FORMAT = "yyyyMMdd'T'HHmmss'Z'";
        public const string ALT_DATE_FORMAT = "yyyyMMdd'T'HHmmss";

        public UntilToken(ValueWrapper value) : base(value)
        {
        }

        public override string GetName()
        {
            return NAME;
        }
    }
}