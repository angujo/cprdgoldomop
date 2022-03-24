using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public class NestDictionary<K, V> : ConcurrentDictionary<K, V>, INestDictionary<K, V> { }

    public interface INestDictionary<K, V> : IDictionary<K, V> { }

    public static class Extension
    {

        public static void AddValue<K, V>(this INestDictionary<K, object> dictionary, V value, params K[] keys) => dictionary.IAddValue(value, keys);
        public static IDictionary<K, V> LastDictionary<K, V>(this INestDictionary<K, object> dictionary, params K[] keys) => dictionary.FindSubDictionary<K, V>(keys);
        public static bool Exists<K, V>(this INestDictionary<K, object> dictionary, params K[] keys) => dictionary.IExists<K, V>(keys);
        public static V Get<K, V>(this INestDictionary<K, object> dictionary, params K[] keys) => dictionary.IGet<K, V>(keys);
        public static bool TryUpdate<K, V>(this INestDictionary<K, object> dictionary, V value, params K[] keys) => dictionary.ITryUpdate<K, V>(value, keys);
        public static V FirstValue<K, V>(this INestDictionary<K, object> dictionary, params K[] keys) => dictionary.IFirstValue<K, V>(keys);

        private static void IAddValue<K, V>(this INestDictionary<K, object> dictionary, V value, params K[] keys) => dictionary.NewValueDictionary<K, V>(keys)[keys.Last()] = value;

        private static IDictionary<K, V> NewValueDictionary<K, V>(this IDictionary<K, object> dictionary, params K[] keys)
        {
            if (dictionary.FindSubDictionary<K, V>(keys) is IDictionary<K, V> valueDictionary) return valueDictionary;
            return dictionary.CreateDictionary<K, V>(keys);
        }

        private static IDictionary<K, V> CreateDictionary<K, V>(this IDictionary<K, object> dictionary, params K[] keys)
        {
            K key = keys.First();
            if (dictionary.ContainsKey(key) && dictionary[key] is IDictionary<K, object> childD) return childD.CreateDictionary<K, V>(keys.Skip(1).ToArray());

            if (dictionary.ContainsKey(key) && dictionary[key] is IDictionary<K, V> childH) return childH;

            keys = keys.Skip(1).ToArray();

            if (keys.Length == 1)
            {
                var ndict = new ConcurrentDictionary<K, V>();
                ndict.TryAdd(keys.First(), default);
                ((NestDictionary<K, object>)dictionary).TryAdd(key, ndict);
                return ndict;
            }

            var d = new NestDictionary<K, object>();

            ((NestDictionary<K, object>)dictionary).TryAdd(key, d);

            return d.CreateDictionary<K, V>(keys);
        }

        private static IDictionary<K, V> FindSubDictionary<K, V>(this IDictionary<K, object> dictionary, params K[] keys)
        {
            // If it doesn't exist, don't bother
            if (!dictionary.IExists<K, V>(keys)) return null; // Or throw

            // If we reached end of keys, or got 0 keys, return
            if (keys.Count() == 0) return null; // Or throw

            // Get the first key for lookup
            K key = keys.First();

            if (keys.Count() == 1 && dictionary is IDictionary<K, V> fdict && dictionary.ContainsKey(key)) return fdict;


            if (2 == keys.Count() && dictionary.ContainsKey(key) && (dictionary[key] is IDictionary<K, V> finDictionary) && finDictionary.ContainsKey(keys.Last())) return finDictionary;

            // Look in the current dictionary if the first key is another dictionary.
            return dictionary[keys.First()] is IDictionary<K, object> subDictionary
                ? subDictionary.FindSubDictionary<K, V>(keys.Skip(1).ToArray()) // If it is, follow the subdictionary down after removing the key just used
                : keys.Count() == 1 // If we only have one key remaining, the last key should be for a value in the current dictionary. 
                    ? (IDictionary<K, V>)dictionary // Return the current dictionary as it's the proper last one
                    : null; // (or throw). If we didn't find a dictionary and we have remaining keys, the dictionary tree is invalid
        }

        /// <summary>
        /// Returns whether the param list of keys has dictionaries all the way down to the final key
        /// </summary>
        private static bool IExists<K, V>(this IDictionary<K, object> dictionary, params K[] keys)
        {
            // If we have no keys, we have traversed all the keys, and should have dictionaries all the way down.
            // (needs a fix for initial empty key params though)
            if (keys.Count() == 0) return false;

            // Get the first key for lookup
            K key = keys.First();

            if (keys.Count() == 1 && dictionary is IDictionary<K, V> && dictionary.ContainsKey(key)) return true;


            if (2 == keys.Count() && dictionary.ContainsKey(key)) return (dictionary[key] is IDictionary<K, V> finDictionary) && finDictionary.ContainsKey(keys.Last());

            // If the dictionary contains the first key in the param list, and the value is another dictionary, 
            // return that dictionary with first key removed (recursing down)
            if (dictionary.ContainsKey(key) && dictionary[key] is IDictionary<K, object> subDictionary)
                return subDictionary.IExists<K, V>(keys.Skip(1).ToArray());

            // If we didn't have a dictionary, but we have multiple keys left, there are not enough dictionaries for all keys
            if (keys.Count() > 1) return false;

            // If we get here, we have 1 key, and we have a dictionary, we simply check whether the last value exists,
            // thus completing our recursion
            return dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Returns a value from the last key, assuming there is a dictionary available for every key but last
        /// </summary>
        private static V IGet<K, V>(this IDictionary<K, object> dictionary, params K[] keys)
        {
            var subDictionary = dictionary.FindSubDictionary<K, V>(keys);
            if (subDictionary == null) return default; // Or throw

            return (V)subDictionary[keys.Last()];
        }

        /// <summary>
        /// Tries to set a value to any dictionary found at the end of the params keys, or returns false
        /// </summary>
        private static bool ITryUpdate<K, V>(this IDictionary<K, object> dictionary, V value, params K[] keys)
        {
            // Get the deepest sub dictionary, set if available
            var subDictionary = dictionary.FindSubDictionary<K, V>(keys);
            if (subDictionary == null) return false;

            subDictionary[keys.Last()] = value;
            return true;
        }

        private static V IFirstValue<K, V>(this IDictionary<K, object> dictionary, params K[] keys)
        {
            if (0 == keys.Length) return default(V);
            if (dictionary.FindSubDictionary<K, V>(keys) is IDictionary<K, V> fsdict) return fsdict[keys.Last()];
            var fdict = dictionary.FeasibleDictionary<K, V>(out K[] remKeys, keys);
            return (fdict is IDictionary<K, V> vdict ? vdict : fdict is IDictionary<K, object> valDict ? valDict.IValueDictionary<K, V>() : null) is IDictionary<K, V> holderDict ? holderDict.FirstOrDefault().Value : default;
        }

        private static object FeasibleDictionary<K, V>(this IDictionary<K, object> dictionary, out K[] remKeys, params K[] keys)
        {
            var key = keys.FirstOrDefault();
            remKeys = keys;
            if (key == null) return dictionary;
            return dictionary.ContainsKey(key) ?
                dictionary[key] is IDictionary<K, object> extDict ? extDict.FeasibleDictionary<K, V>(out remKeys, keys.Skip(1).ToArray()) : (dictionary[key] is IDictionary<K, V> valDict ? valDict : (object)dictionary)
               : dictionary;
        }

        private static IDictionary<K, V> IValueDictionary<K, V>(this IDictionary<K, object> dictionary)
        {
            if (dictionary.Count() == 0) return null;
            var firstValue = dictionary.FirstOrDefault().Value;
            return firstValue is IDictionary<K, V> fdict ? fdict : firstValue is IDictionary<K, object> kvpair ? kvpair.IValueDictionary<K, V>() : null;
        }
    }
}
