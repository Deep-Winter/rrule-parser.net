using System;
namespace DeepWinter.RRuleParserNet.Tokenizer.Validation
{
  /// <summary>
  /// Describes a RRule constraint validator which checks if the RRules
  /// are set correctly.
  /// </summary>
  /// <see cref="RuleValidator"/>
  public interface IRRuleValidator
  {
    /// <summary>
    /// Validates the given RRule token container.
    /// </summary>
    /// <param name="tokenContainer">RRule token container to check against</param>
    /// <exception cref="Exception.RRuleValidationException">If the validation of the rrule token container fails.</exception>
    void ValidateRRuleParts(IRRuleTokenContainer tokenContainer);
  }
}
