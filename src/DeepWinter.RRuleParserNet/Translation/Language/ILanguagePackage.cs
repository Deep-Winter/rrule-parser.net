using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation.Language
{
  /// <summary>
  /// Describes a language package which is able to provide the translation
  /// for each <see cref="ETranslationFragment" />.
  /// </summary>
  /// <seealso cref="EnglishTranslation" />
  public interface ILanguagePackage
    {
        /// <summary>
        /// Returns the translated string for the given <see cref="ETranslationFragment" />.
        /// </summary>
        /// <param name="translationFragment">Fragment to translate.</param>
        /// <returns>Translated fragment.</returns>
        string GetFragment(ETranslationFragment translationFragment);

        /// <summary>
        /// Returns the CultureInfo that is compatible with this
        /// language package.
        /// </summary>
        /// <returns>CultureInfo of language package.</returns>
        CultureInfo GetCompatibleLocale();
    }
}