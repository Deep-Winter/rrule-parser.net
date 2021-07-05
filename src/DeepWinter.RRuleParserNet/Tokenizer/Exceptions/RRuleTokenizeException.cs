namespace DeepWinter.RRuleParserNet.Tokenizer.Exceptions
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
        
        public RRuleTokenizeException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}