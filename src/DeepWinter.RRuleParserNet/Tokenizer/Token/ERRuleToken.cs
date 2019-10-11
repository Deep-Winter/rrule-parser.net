using System;
using DeepWinter.RRuleParserNet.Tokenizer.Exception;
using DeepWinter.RRuleParserNet.Utils;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class ERRuleToken : Enumeration
  {
    public static ERRuleToken Freq = new ERRuleToken(FreqToken.NAME, typeof(FreqToken));
    public static ERRuleToken Until = new ERRuleToken(UntilToken.NAME, typeof(UntilToken));
    public static ERRuleToken Count = new ERRuleToken(CountToken.NAME, typeof(CountToken));
    public static ERRuleToken Interval = new ERRuleToken(IntervalToken.NAME, typeof(IntervalToken));
    public static ERRuleToken ByDay = new ERRuleToken(ByDayToken.NAME, typeof(ByDayToken));
    public static ERRuleToken ByMonthDay = new ERRuleToken(ByMonthDayToken.NAME, typeof(ByMonthDayToken));
    public static ERRuleToken ByMonth = new ERRuleToken(ByMonthToken.NAME, typeof(ByMonthToken));
    public static ERRuleToken BySetPos = new ERRuleToken(BySetPosToken.NAME, typeof(BySetPosToken));

    readonly Type _tokenType;

    private ERRuleToken(string name, Type type) : base(name)
    {
      _tokenType = type;
    }

    public ERRuleToken() { }

    public static ERRuleToken SearchRRuleToken(string input)
    {
      return FromName<ERRuleToken>(input.ToUpperInvariant());
    }

    public IRRuleToken GetTokenInstance(object value)
    {
      try
      {
        return (IRRuleToken)Activator.CreateInstance(_tokenType, args: value);
      }
      catch (System.Exception error)
      {
        throw new RRuleTokenizeException($"Cannot create token instance: {error.Message}");
      }
    }
  }
}
