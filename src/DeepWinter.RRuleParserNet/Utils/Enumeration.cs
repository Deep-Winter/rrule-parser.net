using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeepWinter.RRuleParserNet.Utils
{
    public abstract class Enumeration : IComparable
    {
        protected Enumeration()
        {
        }

        protected Enumeration(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int CompareTo(object other)
        {
            return string.Compare(Name, ((Enumeration) other).Name, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetTypeInfo().GetFields(BindingFlags.Public |
                                                      BindingFlags.Static |
                                                      BindingFlags.DeclaredOnly);
            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;
                if (locatedValue != null) yield return locatedValue;
            }
        }

        public static string ToString<T>() where T : Enumeration, new()
        {
            return string.Join(", ", GetAll<T>().Select(e => e.Name));
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
            if (otherValue == null) return false;
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Name.Equals(otherValue.Name);
            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static T FromName<T>(string name) where T : Enumeration, new()
        {
            var element = GetAll<T>()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (element == null)
                throw new Exception(
                    $@"Unknown enum type for {typeof(T).Name}: ""{name}"". possible values are: {string.Join(",", GetAll<T>().Select(s => s.Name))}");

            return element;
        }
    }
}