namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class FreqToken : RRuleToken<FreqToken.FreqValue>
    {
        public enum FreqValue
        {
            SECONDLY,
            MINUTELY,
            HOURLY,
            DAILY,
            WEEKLY,
            MONTHLY,
            YEARLY
        }

        public const string NAME = "FREQ";

        public FreqToken(FreqValue value) : base(value)
        {
        }

        public override string GetName()
        {
            return NAME;
        }
    }
}