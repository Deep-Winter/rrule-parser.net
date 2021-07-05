namespace DeepWinter.RRuleParserNet.Tokenizer.Validation.Exception
{
    /// <summary>
    /// Runtime exception which can be thrown during constraint validation of the
    /// RRule tokens. (e.g.will be thrown if the "FREQ" token is not set.)
    /// </summary>
    public class RRuleValidationException : System.Exception
    {
        public RRuleValidationException(string message) : base(message)
        {
        }
    }
}