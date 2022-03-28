using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private Stopwatch stopwatch = new();

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

        [TestMethod]
        public void TestStates()
        {
            var arrays = new string[][] {
            new string[] { "job",Consts.TUPLE_MISS},
            new string[] { "job","doe"},
            };

            var ss = arrays[0].LooselySameAs(arrays[1]);
            List<Tuple<string>> ts = new List<Tuple<string>>
            {
                Tuple.Create(Consts.TUPLE_MISS),
                Tuple.Create("john"),
                Tuple.Create("doe"),
            };

            var res = ts.FirstOrDefault(tpl => tpl.Item1.Equals("john")) is Tuple<string> dt ? dt.Item1 : default;
            var res2 = ts.FirstOrDefault(tpl => tpl.Item1.Equals("qqq")) is Tuple<string> dt2 ? dt2.Item1 : default;

        }

        [TestMethod]
        public void TestPerformance()
        {
            int MAX = 10000000;

            List<int> lists = new List<int>();
            HashSet<int> hashsets = new HashSet<int>();
            ConcurrentBag<int> cbag = new ConcurrentBag<int>();

            Console.WriteLine("Lists ");
            TimeLapse(() =>
            {
                Console.WriteLine("Load ");
                foreach (var n in Enumerable.Range(0, MAX)) lists.Add(n);
            });

            TimeLapse(() =>
            {
                Console.WriteLine("Loop ");
                foreach (var n in lists) _ = n;
            });

            TimeLapse(() =>
            {
                Console.WriteLine("Parallel Loop ");
                Parallel.ForEach(lists, n => _ = n);
            });

            Console.WriteLine("Hashsets ");

            TimeLapse(() =>
            {
                Console.WriteLine("Load ");
                foreach (var n in Enumerable.Range(0, MAX)) hashsets.Add(n);
            });

            TimeLapse(() =>
            {
                Console.WriteLine("Loop ");
                foreach (var n in hashsets) _ = n;
            });

            Console.WriteLine("ConcurrentBag ");

            TimeLapse(() =>
            {
                Console.WriteLine("Load ");
                foreach (var n in Enumerable.Range(0, MAX)) cbag.Add(n);
            });

            TimeLapse(() =>
            {
                Console.WriteLine("Loop ");
                foreach (var n in cbag) _ = n;
            });

            Console.WriteLine("ConcurrentBag Parallel");

            TimeLapse(() =>
            {
                Console.WriteLine("Load ");
                Parallel.ForEach(Enumerable.Range(0, MAX), n => cbag.Add(n));
            });

            TimeLapse(() =>
            {
                Console.WriteLine("Loop ");
                Parallel.ForEach(cbag, n => _ = n);
            });
        }

        private void TimeLapse(Action act)
        {
            stopwatch.Start();
            act();
            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}