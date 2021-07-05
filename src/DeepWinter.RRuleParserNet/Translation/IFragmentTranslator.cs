using System.Globalization;

namespace DeepWinter.RRuleParserNet.Translation
{
  /// <summary>
  /// Describes a translation provider which should be able to translate the
  /// required text blocks.
  /// </summary>
  /// <see cref="LanguagePackageFragmentTranslator" />
  public interface IFragmentTranslator
    {
      /// <summary>
      /// Translates the given <see cref="ETranslationFragment" />.
      /// </summary>
      /// <param name="translationFragment">Fragment to translate.</param>
      /// <returns>The translated fragment.</returns>
      string GetTranslatedFragment(ETranslationFragment translationFragment);

        /// <summary>
        /// Returns the locale that is compatible with this
        /// translation.
        /// </summary>
        /// <returns>Locale of translation.</returns>
        CultureInfo GetCompatibleLocale();
    }
}