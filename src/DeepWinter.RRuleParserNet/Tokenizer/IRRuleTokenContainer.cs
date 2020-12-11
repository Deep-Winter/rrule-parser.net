using System;
using DeepWinter.RRuleParserNet.Tokenizer.Token;

namespace DeepWinter.RRuleParserNet.Tokenizer
{
  public interface IRRuleTokenContainer
  {
    /// <summary>
    /// Returns the total amount of rules.
    /// </summary>
    /// <returns>Total count of rules</returns>
    int RuleCount();

    /// <summary>
    /// Returns the "FREQ" token.
    /// <code>null</code> if not set
    /// </summary>
    /// <returns>"FREQ" token or <code>null</code></returns>
    FreqToken GetFreq();

    /// <summary>
    ///  Returns the "UNTIL" token.
    ///  <code>null</code> if not set
    /// </summary>
    /// <returns>"UNTIL" token or <code>null</code></returns>
    UntilToken GetUntil();

    /// <summary>
    ///  Returns the "DTSTART" token.
    ///  <code>null</code> if not set
    /// </summary>
    /// <returns>"DTSTART" token or <code>null</code></returns>
    StartToken GetStart();


    /// <summary>
    /// Returns the "COUNT" token.
    /// <code>null</code> if not set
    /// </summary>
    /// <returns>"COUNT" token or <code>null</code></returns>
    CountToken GetCount();

    /// <summary>
    /// Returns the "INTERVAL" token.
    /// <code>null</code> if not set
    /// </summary>
    /// <returns>"INTERVAL" token or <code>null</code></returns>
    IntervalToken GetInterval();

    /// <summary>
    /// Returns the "BYDAY" token.
    /// <code>null</code> if not set
    /// </summary>
    /// <returns>"BYDAY" token or <code>null</code></returns>
    ByDayToken GetByDay();

    /// <summary>
    /// Returns the "BYMONTHDAY" token.
    /// <code>null</code> if not set
    /// </summary>
    /// <returns>"BYMONTHDAY" token or <code>null</code></returns>
    ByMonthDayToken GetByMontDay();

    /// <summary>
    /// Returns the "BYMONTH" token.
    ///  <code>null</code> if not set
    /// </summary>
    /// <returns>"BYMONTH" token or <code>null</code></returns>
    ByMonthToken GetByMonth();

    /// <summary>
    /// Returns the "BYSETPOS" token.
    /// <code>null</code> if not set
    /// </summary>
    /// <returns>"BYSETPOS" token or <code>null</code></returns>
    BySetPosToken GetBySetPos();

    /// <summary>
    /// Merges the current container with the given container.
    /// If the token is already set by the current container
    /// it WILL NOT be overridden.
    /// </summary>
    /// <param name="tokenContainer">Token container to merge with.</param>
    void Merge(IRRuleTokenContainer tokenContainer);
  }
}
