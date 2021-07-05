using System.Globalization;
using DeepWinter.RRuleParserNet.Translation.Language;

namespace DeepWinter.RRuleParserNet.Translation
{
    public class LanguagePackageFragmentTranslator : IFragmentTranslator
    {
        private readonly ILanguagePackage _languagePackage;

        /// <summary>
        /// Creates the LanguagePackageFragmentTranslator. The first parameter
        /// defines the language package to use.
        /// </summary>
        /// <param name="languagePackage">The language package to use for this translator.</param>
        public LanguagePackageFragmentTranslator(ILanguagePackage languagePackage)
        {
            _languagePackage = languagePackage;
        }

        /// <see cref="IFragmentTranslator.GetCompatibleLocale()" />
        public CultureInfo GetCompatibleLocale()
        {
            return _languagePackage.GetCompatibleLocale();
        }

        /// <see cref="IFragmentTranslator.GetTranslatedFragment(ETranslationFragment)" />
        public string GetTranslatedFragment(ETranslationFragment translationFragment)
        {
            return _languagePackage.GetFragment(translationFragment);
        }
    }
}