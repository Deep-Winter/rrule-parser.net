namespace DeepWinter.RRuleParserNet
{
    public interface IRRuleParser
    {
        /// <summary>
        /// Takes a RRule as first parameter and coverts it into a human readable text.
        /// </summary>
        /// <param name="pRRule">The RRule to convert.</param>
        /// <returns>Convert RRule as human readable text.</returns>
        /// <exception cref="Tokenizer.Exception.RRuleTokenizeException">If the given RRule is invalid</exception>
        /// <exception cref="Tokenizer.Validation.Exception.RRuleValidationException">If the given RRule contains invalid keys (e.g. 'FREQ' key is not set)</exception>
        string ParseRRule(string pRRule);

        /// <summary>
        /// Tries to takes a RRule as first parameter and coverts it into a human readable text.
        /// </summary>
        /// <param name="pRRule"></param>
        /// <param name="pRRuleAsHumanReadableText"></param>
        /// <returns>true, if pRRuleAsHumanReadableText contains result</returns>
        bool TryParseRRule(string pRRule, out string pRRuleAsHumanReadableText);
    }
}