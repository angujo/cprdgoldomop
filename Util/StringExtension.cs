using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Util
{
    public static class StringExtension
    {
        private const UInt64 gbBytes = 1073741824;

        public static bool HasString(this string value, string find, bool ignoreCase = true) => 0 <= value.IndexOf(find, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static string Truncate(this string value, int maxLength = 200, string truncationSuffix = "…")
        {
            return String.IsNullOrEmpty(value) || value.Length <= maxLength
                ? value
                : value.Substring(0, maxLength) + truncationSuffix;
        }

        public static string ToCamelCase(this string str)
        {
            return str.ToPascalCase().FirstCharToLower();
        }

        public static string ToSnakeCase(this string str)
        {
            return Regex.Replace(Regex.Replace(str.FirstCharToLower(), "([A-Z])([^A-Z])", "_$1$2").ToLower(), "[^0-9a-zA-Z]+", "_");
        }

        public static string FirstCharWord(this string str)
        {
            return Regex.Replace(str, "^[^0-9a-zA-Z]+", "");
        }

        public static string ToKebabCase(this string str)
        {
            return Regex.Replace(str.ToSnakeCase(), "[^0-9a-zA-Z]+", "-");
        }

        public static string ToPascalCase(this string str)
        {
            return Regex.Replace(Regex.Replace(str, "[^0-9a-zA-Z]+", "_"), @"(^|_)([0-9]+)?([a-zA-Z])",
                                m => m.Groups[2].Value + m.Groups[3].Value.ToUpper());
        }

        public static string FirstCharToLower(this string str)
        {
            return string.IsNullOrEmpty(str) || char.IsLower(str[0]) ? str : char.ToLower(str[0]) + str.Substring(1);
        }

        public static string FirstCharToUpper(this string str)
        {
            return string.IsNullOrEmpty(str) || char.IsUpper(str[0]) ? str : char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string MD5(this string s)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }

        public static bool HasNullOrEmpty(this string[] arr) => arr.Count(i => string.IsNullOrEmpty(i)) > 0;

        public static bool LooselySameAs(this string[] arr1, string[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;
            for (var i = 0; i < arr1.Length; i++)
            {
                var vals = new string[] { arr1[i], arr2[i] };
                if (!(null != arr1[i] && null != arr2[i] && arr1[i] != arr2[i]) || (!vals.Contains(Consts.TUPLE_MISS))) return false;
            }
            return true;
        }
    }
}
