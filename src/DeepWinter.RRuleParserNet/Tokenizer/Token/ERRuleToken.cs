using System;
using DeepWinter.RRuleParserNet.Tokenizer.Exception;
using DeepWinter.RRuleParserNet.Utils;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class ERRuleToken : Enumeration
  {
    public readonly static ERRuleToken Freq = new ERRuleToken(FreqToken.NAME, typeof(FreqToken));
    public readonly static ERRuleToken Until = new ERRuleToken(UntilToken.NAME, typeof(UntilToken));
    public readonly static ERRuleToken Count = new ERRuleToken(CountToken.NAME, typeof(CountToken));
    public readonly static ERRuleToken Interval = new ERRuleToken(IntervalToken.NAME, typeof(IntervalToken));
    public readonly static ERRuleToken ByDay = new ERRuleToken(ByDayToken.NAME, typeof(ByDayToken));
    public readonly static ERRuleToken ByMonthDay = new ERRuleToken(ByMonthDayToken.NAME, typeof(ByMonthDayToken));
    public readonly static ERRuleToken ByMonth = new ERRuleToken(ByMonthToken.NAME, typeof(ByMonthToken));
    public readonly static ERRuleToken BySetPos = new ERRuleToken(BySetPosToken.NAME, typeof(BySetPosToken));
    public readonly static ERRuleToken Start = new ERRuleToken(StartToken.NAME, typeof(StartToken));

    readonly Type _tokenType;

    private ERRuleToken(string name, Type type) : base(name)
    {
      _tokenType = type;
    }

    public ERRuleToken() { }

    public static ERRuleToken SearchRRuleToken(string input)
    {
      return FromName<ERRuleToken>(input);
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
