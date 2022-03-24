using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Linq;
using Util;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UtilClass.Tester();
            var keys = new string[] { "john", };
            var keys1 = new string[] { "john", "doe", "smith", "james" };
            var keys2 = new string[] { "john", "doe", "smith1", "james" };
            var allKeys = new string[][] { keys1, };
            NestDictionary<string, object> dict = new NestDictionary<string, object>();

            foreach (var key in allKeys)
            {
                var val = new Random().Next(1, 9999);
                dict.AddValue(val, key);
            }

            var john = dict.Get<string, int>(new string[] { "john" });
            var johnF = dict.FirstValue<string, int>(new string[] { "john" });



            dict.AddValue<string, int>(98798765, keys);
            var exists = dict.Exists<string, int>(keys);
            var exists2 = dict.Exists<string, int>(new string[] { "jane", "doe" });
            var finalDict = dict.LastDictionary<string, int>(keys);
            var fval = dict.FirstValue<string, int>(keys);
            var nkeys = keys.Reverse().Skip(1).Reverse().ToArray();
            var fval2 = dict.FirstValue<string, int>(new string[] { "john" });
            var value = dict.Get<string, int>(keys);
            System.Console.WriteLine(exists);
            System.Console.WriteLine(value);
            // System.Console.WriteLine(dict.Get<string,object>("jane", "Doe"));
            // CPRDGOLDMap.ChunkBased(new Util.Chunk());
        }
    }
}