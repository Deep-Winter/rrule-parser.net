using System;

namespace DeepWinter.RRuleParserNet.Tokenizer
{
  /// <summary>
  /// Describes an interface which is able to tokenize a given rrule string.
  /// <see cref="RRuleTokenizer" /> for default implementation.
  /// </summary>
  public interface IRRuleTokenizer
    {
        /// <summary>
        /// Takes a rrule string as first parameter and tokenize it into key/value pairs.
        /// </summary>
        /// <param name="rruleInput">RRule as string to tokenize.</param>
        /// <returns>The parsed tokens as a <see cref="IRRuleTokenContainer" />.</returns>
        /// <exception cref="Exception.RRuleTokenizeException">If the tokenization fails somehow.</exception>
        /// <exception cref="Validation.Exception.RRuleValidationException">If the validation fails.</exception>
        IRRuleTokenContainer Tokenize(string rruleInput);
    }
}