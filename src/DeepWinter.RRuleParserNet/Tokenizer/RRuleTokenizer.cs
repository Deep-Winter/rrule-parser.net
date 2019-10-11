using System;
using System.Collections.Generic;
using DeepWinter.RRuleParserNet.Tokenizer.Exception;
using DeepWinter.RRuleParserNet.Tokenizer.Token;
using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;

namespace DeepWinter.RRuleParserNet.Tokenizer
{
  public class RRuleTokenizer : IRRuleTokenizer
  {
    readonly IValueParser _valueParser;
    readonly IRRuleValidator _rruleValidator;

    public RRuleTokenizer(IValueParser valueParser, IRRuleValidator rruleValidator)
    {
      _valueParser = valueParser;
      _rruleValidator = rruleValidator;
    }

    public IRRuleTokenContainer Tokenize(string rruleInput)
    {
      var rruleTokens = new List<IRRuleToken>();

      var rruleParts = SplitRRule(rruleInput);

      foreach (var rrulePart in rruleParts)
      {
        rruleTokens.Add(ProcessRRulePart(rrulePart));
      }

      IRRuleTokenContainer tokenContainer = new RRuleTokenContainer(rruleTokens);

      _rruleValidator.ValidateRRuleParts(tokenContainer);

      return tokenContainer;
    }

    private IRRuleToken ProcessRRulePart(string rrulePart)
    {
      var rruleKeyValue = SplitRRulePart(rrulePart);
      if (rruleKeyValue.Length != 2)
        throw new RRuleTokenizeException(string.Format("RRule part {0} contains more than key/value", rrulePart));

      string rruleKey = rruleKeyValue[0];
      string rruleValue = rruleKeyValue[1];

      ERRuleToken rruleToken = ERRuleToken.SearchRRuleToken(rruleKey);
      if (rruleToken == null)
        throw new RRuleTokenizeException(string.Format("RRule key {0} not found", rruleKey));

      object valueInstance = ParseValue(rruleToken, rruleValue);
      if (valueInstance == null)
        throw new RRuleTokenizeException(string.Format("RRule value {0} is not applicable for key {1}", rruleValue, rruleKey));

      return rruleToken.GetTokenInstance(valueInstance);
    }

    private string[] SplitRRule(string rruleInput)
    {
      return rruleInput.Split(";");
    }

    private string[] SplitRRulePart(string rrulePartInput)
    {
      return rrulePartInput.Split("=");
    }

    private object ParseValue(ERRuleToken rruleToken, string payload)
    {
      return _valueParser.ParseValue(rruleToken, payload);
    }


  }
}
