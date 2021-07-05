namespace DeepWinter.RRuleParserNet.Tokenizer.Exception
{
    /// <summary>
    /// Exception which will be thrown if the <see cref="IRRuleTokenizer" /> encountered
    /// an invalid character during the analyzation of the rrule.
    /// </summary>
    public class RRuleTokenizeException : System.Exception
    {
        public RRuleTokenizeException(string message) : base(message)
        {
        }
    }
}