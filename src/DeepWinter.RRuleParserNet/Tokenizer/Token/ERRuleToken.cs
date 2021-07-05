using System;
using DeepWinter.RRuleParserNet.Tokenizer.Exception;
using DeepWinter.RRuleParserNet.Utils;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class ERRuleToken : Enumeration
    {
        public static readonly ERRuleToken Freq = new ERRuleToken(FreqToken.NAME, typeof(FreqToken));
        public static readonly ERRuleToken Until = new ERRuleToken(UntilToken.NAME, typeof(UntilToken));
        public static readonly ERRuleToken Count = new ERRuleToken(CountToken.NAME, typeof(CountToken));
        public static readonly ERRuleToken Interval = new ERRuleToken(IntervalToken.NAME, typeof(IntervalToken));
        public static readonly ERRuleToken ByDay = new ERRuleToken(ByDayToken.NAME, typeof(ByDayToken));
        public static readonly ERRuleToken ByMonthDay = new ERRuleToken(ByMonthDayToken.NAME, typeof(ByMonthDayToken));
        public static readonly ERRuleToken ByMonth = new ERRuleToken(ByMonthToken.NAME, typeof(ByMonthToken));
        public static readonly ERRuleToken BySetPos = new ERRuleToken(BySetPosToken.NAME, typeof(BySetPosToken));
        public static readonly ERRuleToken Start = new ERRuleToken(StartToken.NAME, typeof(StartToken));

        private readonly Type _tokenType;

        private ERRuleToken(string name, Type type) : base(name)
        {
            _tokenType = type;
        }

        public ERRuleToken()
        {
        }

        public static ERRuleToken SearchRRuleToken(string input)
        {
            return FromName<ERRuleToken>(input);
        }

        public IRRuleToken GetTokenInstance(object value)
        {
            try
            {
                return (IRRuleToken) Activator.CreateInstance(_tokenType, value);
            }
            catch (System.Exception error)
            {
                throw new RRuleTokenizeException($"Cannot create token instance: {error.Message}");
            }
        }
    }
}