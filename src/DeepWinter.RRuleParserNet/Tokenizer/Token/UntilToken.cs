﻿using System;
using static DeepWinter.RRuleParserNet.Tokenizer.Token.UntilToken;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{
  public class UntilToken : RRuleToken<ValueWrapper>
  {
    public const string NAME = "UNTIL";

    public UntilToken(ValueWrapper value) : base(value)
    {
    }

    public override string GetName() => NAME;

    public class ValueWrapper
    {
      private DateTime _localDate;

      public ValueWrapper(DateTime localDateTime)
      {
        _localDate = localDateTime;
      }

      public DateTime getLocalDateTime()
      {
        return _localDate;
      }

      public override string ToString()
      {
        return getLocalDateTime().ToString("O");
      }

      
    }
  }
}
