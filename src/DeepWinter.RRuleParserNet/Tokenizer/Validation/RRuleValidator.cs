using System;
using DeepWinter.RRuleParserNet.Tokenizer.Validation.Exception;

namespace DeepWinter.RRuleParserNet.Tokenizer.Validation
{
  /// <summary>
  /// Default implementation of <see cref="IRRuleValidator"/>. Currently validates the following:
  /// - If the"FREQ" token is set exactly once.
  /// - "UNTIL" or "COUNT" token is set (Both can't be set.)
  /// </summary>
  public class RRuleValidator : IRRuleValidator
  {
    public void ValidateRRuleParts(IRRuleTokenContainer tokenContainer)
    {
      EnsureFreqExistence(tokenContainer);
      EnsureSingleExistenceUntilCount(tokenContainer);
    }

    private void EnsureFreqExistence(IRRuleTokenContainer tokenContainer)
    {
      if (tokenContainer.GetFreq() == null)
        throw new RRuleValidationException("Required rrule part 'FREQ' is not present");
    }

    private void EnsureSingleExistenceUntilCount(IRRuleTokenContainer tokenContainer)
    {
      if (tokenContainer.GetUntil() != null && tokenContainer.GetCount() != null)
        throw new RRuleValidationException("RRule part 'UNTIL' and 'COUNT' are present at the same time");
    }
  }
}
