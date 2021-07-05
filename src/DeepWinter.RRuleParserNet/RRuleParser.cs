using DeepWinter.RRuleParserNet.Text;
using DeepWinter.RRuleParserNet.Tokenizer;
using DeepWinter.RRuleParserNet.Tokenizer.Validation;
using DeepWinter.RRuleParserNet.Tokenizer.Value;
using DeepWinter.RRuleParserNet.Translation;
using DeepWinter.RRuleParserNet.Translation.Language;

namespace DeepWinter.RRuleParserNet
{
    public class RRuleParser : IRRuleParser
    {
    }

    /// <summary>
    /// Creates the RRuleParser. With <see cref="TextBuilder"/> as TextBuilder.
    /// </summary>
    /// <param name="languagePackage">The language to use.</param>
    public RRuleParser(ILanguagePackage languagePackage) :
      this(new TextBuilder(new LanguagePackageFragmentTranslator(languagePackage)))
    {

    }

    /// <summary>
    /// Creates the RRuleParser. With <see cref="RRuleTokenizer" /> as RRuleTokenizer.
    /// </summary>
    /// <param name="textBuilder">The text builder to use.</param>
    public RRuleParser(ITextBuilder textBuilder) :
      this(new RRuleTokenizer(new RRuleValueParser(), new RRuleValidator()), textBuilder)
    {

    }

    /// <summary>
    /// Creates the RRuleParser. With <see cref="TextBuilder"/> as TextBuilder and the
    /// english translation.
    /// </summary>
    /// <param name="rruleTokenizer"></param>
    public RRuleParser(IRRuleTokenizer rruleTokenizer) :
        this(rruleTokenizer, new TextBuilder(new LanguagePackageFragmentTranslator(new EnglishTranslation())))
    {

    }

    /// <summary>
    /// Creates the RRuleParser.
    /// </summary>
    /// <param name="rruleTokenizer">The tokenizer to use.</param>
    /// <param name="textBuilder">The text builder to use.</param>
    public RRuleParser(IRRuleTokenizer rruleTokenizer, ITextBuilder textBuilder)
    {
      _tokenizer = rruleTokenizer;
      _textBuilder = textBuilder;
    }

    public string ParseRRule(string pRRule)
    {
      // Build the rrule token container from the given rule.
      var rruleTokenContainer = TokenizeRRule(pRRule);

      // Build the text for the rrule token container
      return BuildText(rruleTokenContainer);
    }

    private IRRuleTokenContainer TokenizeRRule(string input)
    {
      return _tokenizer.Tokenize(input);
    }

    private string BuildText(IRRuleTokenContainer tokenContainer)
    {
      return _textBuilder.BuildText(tokenContainer);
    }

    public static IRRuleParser CreateDefault()
    {
      return new RRuleParser();
    }

    public static IRRuleParser CreateEnglish()
    {
      return new RRuleParser(new EnglishTranslation());
    }
  
    public static IRRuleParser CreateDutch()
    {
      return new RRuleParser(new DutchTranslation());
    }
  
    public static IRRuleParser CreatePortuguese()
    {
      return new RRuleParser(new PortugueseTranslation());
    }
  
    public static IRRuleParser CreateGerman()
    {
      return new RRuleParser(new GermanTranslation());
    }
    
    public static IRRuleParser CreateItalian()
    {
      return new RRuleParser(new ItalianTranslations());
    }

    public static IRRuleParser Create(string code)
    {
      switch(code)
      {
        case "de":
          return CreateGerman();
        case "en":
          return CreateEnglish();
        case "nl":
            return CreateDutch();
        case "pt":
            return CreatePortuguese();
        case "it":
            return CreateItalian();
        default:
          return CreateDefault();
      }
   }
}
