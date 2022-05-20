using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.Config;
using NLog.Targets;
using SqlKata;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Util;
using DBMS;
using DBMS.models;
using DBMS.systems;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private LoggingConfiguration loggingConfig = new LoggingConfiguration();

        private Stopwatch stopwatch = new();

        [TestMethod]
        public void TestSimple()
        {
           // var sts = Setting.AppConnection;
           //  Log.Info( "John DOe 101");
            //Logger logger1 = createLog(1);
           // Logger logger2 = createLog(2);

          //  logger1.Info("Am trying to do something!");
          //  logger2.Info("Am also trying here!");
          var c = 200;
          while (c>0)
          {
              Console.WriteLine($"{c} = {c%3}");
              c--;
          }
        }

        [TestMethod]
        public void TestCompiler()
        {
            var chunk = new Chunk
            {
                column = "patient_id",
                ordinal = 0,
                relationColumn = "patid",
                tableName = "_chunk",
                dbms = DB.Target,
                ordinalColumn = "ordinal",
                relationTableName = "consultation",
            };
            var schema_name = "source";
            DBMSSystem db = (DBMSSystem)chunk.dbms;
            var query = new Query(string.Join(".", new string[] { db.schema.SchemaName, chunk.tableName, }));
            query.Join(Dot(db.schema.SchemaName, chunk.relationTableName), Dot(chunk.relationTableName, chunk.relationColumn), Dot(chunk.tableName, chunk.column))
                .SelectRaw(Dot(chunk.relationTableName, "*"))
                .Where(Dot(chunk.tableName, chunk.ordinalColumn), chunk.ordinal);

            var withChunk = new Query($"{db.schema.SchemaName}.{chunk.tableName}")
                        .Where("ordinal", chunk.ordinal).Select("patient_id");
            var clinical = new Query("chunks")
                .Join($"{schema_name}.clinical", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                .Select("patid", "eventdate", "consid", "staffid");
            var referral = new Query("chunks")
                .Join($"{schema_name}.referral", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                .Select("patid", "eventdate", "consid", "staffid");
            var test = new Query("chunks")
                .Join($"{schema_name}.test", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                .Select("patid", "eventdate", "consid", "staffid");
            var immunisation = new Query("chunks")
                .Join($"{schema_name}.immunisation", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                .Select("patid", "eventdate", "consid", "staffid");
            var therapy = new Query("chunks")
                .Join($"{schema_name}.therapy", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                .Select("patid", "eventdate", "consid", "staffid");
            query.With("chunks", withChunk)
                 .Join(clinical.UnionAll(referral).UnionAll(test).UnionAll(immunisation).UnionAll(therapy).As("u"),
                 j => j.WhereRaw("consultation.patid=u.patid AND consultation.consid = u.consid AND consultation.eventdate = u.eventdate"));
            var q = new Query("_chunks").Where("id", 21);
            var compiler = DB.Target.GetCompiler();

            string sql = compiler.Compile(query).Sql;

        }

        [TestMethod]
        public void TestMethod1()
        {
          //  UtilClass.Tester();
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



            dict.AddValue(98798765, keys);
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
            new string[] { "job",""},
            new string[] { "","doe"},
            };
            bool[] hasNE = new bool[arrays.Length];
            for (var i = 0; i < arrays.Length; i++)
            {
                hasNE[i] = arrays[i].HasNullOrEmpty();
            }

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

        [TestMethod]
        public void TestKeyRef()
        {
            Tuple<string> t1 = Tuple.Create("joe1");
            Tuple<string> t2 = Tuple.Create("joe2");

            Dictionary<Tuple<string>, TestClass> dict = new Dictionary<Tuple<string>, TestClass>();
            TestClass test = new TestClass { Description = "My God", Name = "I Work" };
            dict.Add(t1, test);
            dict.Add(t2, test);

            dict[t1].Description = "May be";

            var desc = dict[t2].Description;

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
        private string Dot(string schema, string table)
        {
            return string.Join(".", new string[] { schema, table });
        }

        private Logger createLog(int id)
        {
            string Name = $"Chunker{id}";
            var target = new FileTarget
            {
                Name = Name,
                FileName = Path.Combine(Environment.CurrentDirectory, "logs", $"log-{id}.log"),
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveAboveSize = 10240,
                Layout = "${longdate} ${level:uppercase=true} ${message:withexception=true}"
            };
            var loggingRule = new LoggingRule("*", LogLevel.Debug, target);

            loggingConfig.AddTarget(target);
            loggingConfig.LoggingRules.Add(loggingRule);
            // loggingConfig.Reload();

            return LogManager.GetLogger(Name);
        }
    }

    internal class TestClass
    {
        public string? Name        { get; set; }
        public string? Description { get; set; }
    }
}