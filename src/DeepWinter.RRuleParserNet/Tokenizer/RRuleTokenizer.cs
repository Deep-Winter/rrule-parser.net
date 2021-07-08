using System.Collections.Generic;
using DeepWinter.RRuleParserNet.Tokenizer.Exceptions;
using DeepWinter.RRuleParserNet.Tokenizer.Token;
using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;

namespace DeepWinter.RRuleParserNet.Tokenizer
{
    public class RRuleTokenizer : IRRuleTokenizer
    {
        private readonly IRRuleValidator _rruleValidator;
        private readonly IValueParser _valueParser;

        public RRuleTokenizer(IValueParser valueParser, IRRuleValidator rruleValidator)
        {
            _valueParser = valueParser;
            _rruleValidator = rruleValidator;
        }

        public IRRuleTokenContainer Tokenize(string rruleInput)
        {
            var rruleTokens = new List<IRRuleToken>();

            var rruleParts = SplitRRule(rruleInput);

            foreach (var rrulePart in rruleParts) rruleTokens.Add(ProcessRRulePart(rrulePart));

            IRRuleTokenContainer tokenContainer = new RRuleTokenContainer(rruleTokens);

            _rruleValidator.ValidateRRuleParts(tokenContainer);

            return tokenContainer;
        }

        private IRRuleToken ProcessRRulePart(string rrulePart)
        {
            var rruleKeyValue = SplitRRulePart(rrulePart);
            if (rruleKeyValue.Length != 2)
                throw new RRuleTokenizeException(
                    $"RRule part {rrulePart} contains more than key/value");

            var rruleKey = rruleKeyValue[0];
            var rruleValue = rruleKeyValue[1];

            var rruleToken = ERRuleToken.SearchRRuleToken(rruleKey);
            if (rruleToken == null)
                throw new RRuleTokenizeException($"RRule key {rruleKey} not found");

            var valueInstance = ParseValue(rruleToken, rruleValue);
            if (valueInstance == null)
                throw new RRuleTokenizeException($"RRule value {rruleValue} is not applicable for key {rruleKey}");

            return rruleToken.GetTokenInstance(valueInstance);
        }

        private string[] SplitRRule(string rruleInput)
        {
            return rruleInput.Split(';');
        }

        private string[] SplitRRulePart(string rrulePartInput)
        {
            return rrulePartInput.Split('=');
        }

        private object ParseValue(ERRuleToken rruleToken, string payload)
        {
            return _valueParser.ParseValue(rruleToken, payload);
        }
    }
}