using System;
using System.Collections.Generic;
using System.Text;

namespace DeepWinter.RRuleParserNet.Tokenizer.Token
{

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
            //ugly but design does not allow easy modification
            return getLocalDateTime().ToString(UntilToken.DATE_FORMAT);
        }


    }
}
