namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class StartToken : RRuleToken<ValueWrapper>
    {
        public const string NAME = "DTSTART";
        public const string DATE_FORMAT = "yyyyMMdd'T'HHmmss'Z'";
        public const string ALT_DATE_FORMAT = "yyyyMMdd'T'HHmmss";

        public StartToken(ValueWrapper value) : base(value)
        {
        }

        public override string GetName()
        {
            return NAME;
        }
    }
}