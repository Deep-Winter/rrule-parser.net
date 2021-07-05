using System;
using System.Collections.Generic;
using DeepWinter.RRuleParserNet.Tokenizer.Exceptions;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
    public class ERRuleToken
    {
        public static readonly ERRuleToken Freq = new ERRuleToken(typeof(FreqToken));
        public static readonly ERRuleToken Until = new ERRuleToken(typeof(UntilToken));
        public static readonly ERRuleToken Count = new ERRuleToken(typeof(CountToken));
        public static readonly ERRuleToken Interval = new ERRuleToken(typeof(IntervalToken));
        public static readonly ERRuleToken ByDay = new ERRuleToken(typeof(ByDayToken));
        public static readonly ERRuleToken ByMonthDay = new ERRuleToken(typeof(ByMonthDayToken));
        public static readonly ERRuleToken ByMonth = new ERRuleToken(typeof(ByMonthToken));
        public static readonly ERRuleToken BySetPos = new ERRuleToken(typeof(BySetPosToken));
        public static readonly ERRuleToken Start = new ERRuleToken(typeof(StartToken));

        public static readonly Dictionary<string, ERRuleToken> Tokens = new Dictionary<string, ERRuleToken>(StringComparer.CurrentCultureIgnoreCase)
        {
            [FreqToken.NAME] = Freq,
            [UntilToken.NAME] = Until,
            [CountToken.NAME] = Count,
            [IntervalToken.NAME] = Interval,
            [ByDayToken.NAME] = ByDay,
            [ByMonthDayToken.NAME] = ByMonthDay,
            [ByMonthToken.NAME] = ByMonth,
            [BySetPosToken.NAME] = BySetPos,
            [StartToken.NAME] = Start
        };

        private readonly Type _tokenType;

        protected ERRuleToken(Type type)
        {
            _tokenType = type;
        }

        public override string ToString()
        {
            return _tokenType.Name;
        }

        public static ERRuleToken SearchRRuleToken(string input)
        {
            return Tokens.TryGetValue(input, out var token)
                ? token
                : throw new Exception(
                    $@"Unknown token {input}. Possible values are: {string.Join(", ", Tokens.Keys)}");
        }

        public IRRuleToken GetTokenInstance(object value)
        {
            try
            {
                return (IRRuleToken)Activator.CreateInstance(_tokenType, value);
            }
            catch (Exception error)
            {
                throw new RRuleTokenizeException($"Cannot create token instance: {error.Message}");
            }
        }
    }
}