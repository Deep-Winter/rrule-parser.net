using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;

namespace DeepWinter.RRuleParserNet.Tokenizer
{
    public static class RRuleTokenizerFactory
    {
        public static IRRuleTokenizer DefaultImpl()
        {
            return new RRuleTokenizer(new RRuleValueParser(), new RRuleValidator());
        }
    }
}