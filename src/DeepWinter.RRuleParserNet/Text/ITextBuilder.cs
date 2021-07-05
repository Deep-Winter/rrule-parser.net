using DeepWinter.RRuleParserNet.Tokenizer;

namespace DeepWinter.RRuleParserNet.Text
{
  /// <summary>
  /// Describes an interface which is able to translate
  /// a given <see cref="IRRuleTokenContainer" />.
  /// </summary>
  public interface ITextBuilder
    {
      /// <summary>
      /// Builds a valid human readable text out of the
      /// given <see cref="IRRuleTokenContainer" />.
      /// </summary>
      /// <param name="rruleTokenContainer">Token container to convert.</param>
      /// <returns>Converted text.</returns>
      string BuildText(IRRuleTokenContainer rruleTokenContainer);
    }
}