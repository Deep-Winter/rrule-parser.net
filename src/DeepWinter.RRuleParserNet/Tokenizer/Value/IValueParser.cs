using System;
using DeepWinter.RRuleParserNet.Tokenizer.Token;

namespace DeepWinter.RRuleParserNet.Tokenizer.Value
{
  /// <summary>
  ///  Describes a value parser which is able to convert the value of a
  ///  rrule into the requried object.
  ///  (This additional interface exists because most rrule tokens have the same value type.)
  /// </summary>
  public interface IValueParser
  {
    /// <summary>
    /// Parses the value of a rrule into the required object.
    /// </summary>
    /// <param name="value"> The incoming value as string which should be parsed.</param>
    /// <returns>The parsed object which is compatible with the token implementation.</returns>
    /// <exception cref="Exception.RRuleTokenizeException">If the value for a token is invalid.</exception>
    object ParseValue(ERRuleToken rRuleToken, string value);
  }
}
