﻿namespace DeepWinter.RRuleParserNet.Tokenizer
{
  /// <summary>
  /// Describes a RRule token, which contains the name of the token and
  /// the current value(T).
  /// </summary>
  /// <see cref="Token.FreqToken" />
  public interface IRRuleToken
    {
        /// <summary>
        /// Returns the name of the RRule token (e.g. "FREQ"/"INTERVAL"/"UNTIL"/...)
        /// </summary>
        /// <returns>Name of the RRule token.</returns>
        string GetName();

        /// <summary>
        /// Returns the parsed the value of the RRule token. (e.g. "YEARLY", for token "FREQ")
        /// </summary>
        /// <returns>Parsed value of the RRule token.</returns>
        object GetValue();
    }

    /// <summary>
    /// Abstract RRuleToken
    /// </summary>
    /// <typeparam name="T">The accepted value of the token</typeparam>
    public abstract class RRuleToken<T> : IRRuleToken
    {
        private readonly T _value;

        protected RRuleToken(T value)
        {
            _value = value;
        }

        public abstract string GetName();


        public object GetValue()
        {
            return _value;
        }
    }
}