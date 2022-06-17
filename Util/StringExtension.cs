using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Util
{
    public static class StringExtension
    {
        private const ulong gbBytes = 1073741824;

        public static void ToDataTable<T>(this IEnumerable<T> items, DataTable _dataTable,
            Action<long> loopCheck = null)
        {
            long count = 0;
            var  props = typeof(T).GetProperties();
            items.ToList()
                 .ForEach(item =>
                 {
                     var row = _dataTable.NewRow();

                     foreach (var prop in props)
                     {
                         var name  = prop.Name.ToLower();
                         var value = prop.GetValue(item);

                         if (_dataTable.IsPrimaryKey(name))
                             value = UtilClass.MissValue(prop.PropertyType, value);

                         row[name] = value ?? DBNull.Value;
                     }

                     loopCheck?.Invoke(count++);

                     _dataTable.Rows.Add(row);
                 });
        }

        public static IEnumerable<T> ToEnumerable<T>(this DataTable dataTable) =>
            dataTable.Rows.Cast<DataRow>().Select(dr => dr.Convert<T>());

        public static T Convert<T>(this DataRow row)
        {
            var m = (T) Activator.CreateInstance(typeof(T));
            foreach (var property in typeof(T).GetProperties())
            {
                if (!property.CanWrite) continue;
                var name = property.Name.ToLower();
                if (!row.Table.Columns.Contains(name)) continue;
                property.SetValue(m, DBNull.Value.Equals(row[name]) ? null : row[name]);
            }

            return m;
        }

        public static string ToDataTableFilter(this object search, DataTable _dataTable) =>
            string.Join("", search.AsDataTableFilter(_dataTable));

        private static string[] AsDataTableFilter(this object search, DataTable _dataTable)
        {
            var filter = new List<string>();
            if (search.GetType().IsAnonymousType())
            {
                foreach (var property in search.GetType().GetProperties())
                {
                    var val  = property.GetValue(search);
                    var name = property.Name.ToLower();
                    if (!_dataTable.Columns.Contains(name)) continue;
                    if (_dataTable.IsPrimaryKey(name))
                        val = UtilClass.MissValue(_dataTable.Columns[name].DataType, val);

                    if (filter.Count > 0) filter.Add(" AND ");
                    filter.Add(DataTableFilterValue(name, val));
                }
            }
            else if (search.GetType().IsArray)
            {
                foreach (var _search in (IEnumerable) search)
                {
                    if (_search is string s) filter.Add(s);
                    else filter.AddRange(_search.AsDataTableFilter(_dataTable));
                }
            }
            else return new[] {search as string};

            return filter.ToArray();
        }

        private static string DataTableFilterValue(string col_name, object value)
        {
            if (value is KeyValuePair<string, object> kv) return $"{col_name} {DTValue(kv.Value, kv.Key)}";
            return $"{col_name} {DTValue(value)}";
        }

        private static string DTValue(object value, string opr = null)
        {
            if (null == value || value is DBNull) return "IS NULL";
            if (value.IsNumber()) return $"{opr ?? "="} {value}";
            if (value is DateTime d) return $"{opr ?? "="} #{d.ToString("yyyy-M-d HH:m:s")}#";
            return value.GetType().IsArray
                ? $"{opr ?? "IN"} ({string.Join(", ", ((IEnumerable) value).Cast<object>().Select(av => av.IsNumber() ? av : $"'{av}'"))})"
                : $"{opr ?? "="} '{value}'";
        }

        public static bool IsPrimaryKey(this DataTable dataTable, string name) =>
            dataTable.PrimaryKey.Select(p => p.ColumnName).Contains(name);

        public static bool HasString(this string value, string find, bool ignoreCase = true) => 0 <=
            value.IndexOf(find, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        public static bool IsAnonymousType(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            // HACK: The only way to detect anonymous types right now.
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && type.Name.Contains("AnonymousType")
                   && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                   && type.Attributes.HasFlag(TypeAttributes.NotPublic);
        }

        public static string ToHash(this string[] text, string salt = "") => string.Join(".", text).ToHash(salt);

        public static string ToHash(this string text, string salt = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                var textBytes = Encoding.UTF8.GetBytes(text + salt);
                var hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }

        public static bool IsNumber(this object value) =>
            value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint ||
            value is long || value is ulong || value is float || value is double || value is decimal ||
            decimal.TryParse(value.ToString(), out var dc);


        public static string GetStringValue(this Enum value)
        {
            // Get the type
            var type = value.GetType();

            // Get fieldinfo for this type
            var fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            var attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static string Truncate(this string value, int maxLength = 200, string truncationSuffix = "…")
        {
            return string.IsNullOrEmpty(value) || value.Length <= maxLength
                ? value
                : value.Substring(0, maxLength) + truncationSuffix;
        }

        public static string ToCamelCase(this string str)
        {
            return str.ToPascalCase().FirstCharToLower();
        }

        public static string ToSnakeCase(this string str)
        {
            return Regex.Replace(Regex.Replace(str.FirstCharToLower(), "([A-Z])([^A-Z])", "_$1$2").ToLower(),
                                 "[^0-9a-zA-Z]+", "_");
        }

        public static string ToWords(this string str)
        {
            return Regex.Replace(Regex.Replace(str, "([A-Z])([^A-Z])", " $1$2"), "[^0-9a-zA-Z]+", " ");
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
                var builder = new StringBuilder();

                foreach (var b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
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
                var vals = new string[] {arr1[i], arr2[i]};
                if (!(null != arr1[i] && null != arr2[i] && arr1[i] != arr2[i]) ||
                    (!vals.Contains(Consts.TUPLE_MISS_STR)))
                    return false;
            }

            return true;
        }
    }
}