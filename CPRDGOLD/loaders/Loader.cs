using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DBMS.models;
using DBMS.systems;
using SqlKata;
using SqlKata.Execution;
using Util;

namespace CPRDGOLD.loaders
{
    public abstract class Loader<T, C> where T : new()
    {
        // protected ConcurrentDictionary<string, C> tupleChunk = new ConcurrentDictionary<string, C>();
        protected DBMSSystem db { get; set; }
        protected DataTable  _dataTable;

        protected List<C> dataset => _dataTable.ToEnumerable<C>().ToList();

        protected string table_name;

        protected static T me;

        protected Loader(DBMSSystem qf, string table)
        {
            db         = qf;
            table_name = table;
            _dataTable = new DataTable(typeof(C).Name);
            foreach (var prop in typeof(C).GetProperties())
            {
                var column = new DataColumn
                {
                    DataType    = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType,
                    ColumnName  = prop.Name.ToLower(),
                    AllowDBNull = true,
                };
                _dataTable.Columns.Add(column);
            }
        }

        /*public void Add(C obj)
        {
            data.Add(obj);
        }*/

        public static void Init() => GetMe();

        public static List<C> GetData() => ((Loader<T, C>) (object) GetMe()).dataset;

        protected void LoadData()
        {
            RunQuery((query, schema_name) =>
            {
                if (null != GetType().GetMethod("ChunkData"))
                    GetType().GetMethod("ChunkData").Invoke(this, new object[] {query.Get<C>()});
                else query.Get<C>().ToDataTable(_dataTable);
            });
        }

        private void RunQuery(Action<Query, string> queryAct)
        {
            if (null == db || null == table_name) return;
            Action<Query, string> actn = (query, schema_name) =>
            {
                if (null != GetType().GetMethod("CustomizeQuery"))
                    GetType().GetMethod("CustomizeQuery").Invoke(this, new object[] {query, schema_name});
                queryAct(query, schema_name);
            };
            if (null != GetType().GetMethod("GetChunk"))
            {
                var ch = (Chunk) GetType().GetMethod("GetChunk").Invoke(this, null);
                db.RunChunk(ch, table_name, actn);
            }
            else
            {
                db.RunFactory(table_name, actn);
            }
        }

        public void Clean()
        {
            _dataTable.Rows.Clear();
            Log.Warning("Cleaning #{name}", typeof(T).Name);
        }

        protected static T GetMe()
        {
            if (me != null) return me;
            me = new T();
            var _me = (Loader<T, C>) (object) me;
            Log.Info($"Starting Data Load #Loader [{typeof(T).Name}]");
            _me.LoadData();
            Log.Info($"Finished Data Load #Loader {_me._dataTable.Rows.Count} [{typeof(T).Name}]");
            return me;
        }

        public static void LoopAll(Action<C> looper)
        {
            var m = (Loader<T, C>) (object) GetMe();
            Log.Info($"Starting Looping Through All #{typeof(T).Name}");
            Log.Info($"Total Data Chunk to LoopAll [{m._dataTable.Rows.Count}] [{typeof(T).Name}]");
            m._dataTable.ToEnumerable<C>().ToList().ForEach(looper);

            Log.Info($"Finished Looping Through All #{typeof(T).Name}");
        }

        #region ChunkData

        /*
        protected C IChunkValue(string[][] keys)
        {
            foreach (var iKeys in keys)
            {
                if (iKeys.Length <= 0 || iKeys.Where(k => string.IsNullOrEmpty(k)).Count() > 0) continue;
                if (ChunkTupleValue(iKeys) is C value) return value;
            }

            return default;
        }

         protected void ParallelChunk(IEnumerable<C> items = null) => IParallelChunk(null, items);

    protected void ParallelChunk(Func<C, string[]> getKeys, IEnumerable<C> items = null) =>
          ParallelChunk(c => new[] {getKeys(c)}, items);

      protected void ParallelChunk(Func<C, string[][]> getKeys, IEnumerable<C> items = null) =>
          IParallelChunk(getKeys, items);

      private void IParallelChunk(Func<C, string[][]> getKeys, IEnumerable<C> items = null)
      {
          var cData = items ?? new C[] { };
          if (getKeys == null)
          {
              Log.Info($"No Data Chunk Actions For #{typeof(T).Name}");
              if (null != items) data.AddRange(items);
              return;
          }

          Log.Info($"Starting Data Chunk #{typeof(T).Name}");
          Log.Info($"DataChunk Stats: Total Data to Chunk: #{items.Count()} [{typeof(T).Name}]");
          var count = 0;
          Parallel.ForEach(cData,
                           new ParallelOptions {MaxDegreeOfParallelism = 50, CancellationToken = Runner.Token},
                           dt =>
                           {
                               string[][] keys;
                               if (null == (keys = getKeys(dt))) return;
                               foreach (var _keys in keys)
                               {
                                   if (_keys.HasNullOrEmpty()) continue;
                                   var ky = string.Join(".", _keys);
                                   if (tupleChunk.ContainsKey(ky)) continue;
                                   tupleChunk[ky] = dt;
                               }

                               var br = Interlocked.Increment(ref count);
                               if (0 == br % Consts.LOOP_LOG_COUNT)
                               {
                                   Log.Info($"Data Chunk Count {br} of {cData.Count()} #{typeof(T).Name}");
                               }
                           });
          Log.Info($"DataChunk Stats: Total Chunks: #{tupleChunk.Count}/{cData.Count()} [{typeof(T).Name}]");
          Log.Info($"Finished Data Chunk #{typeof(T).Name}");
      }
*/

        protected void DataTableChunk(IEnumerable<C> items = null, params string[] idxCols) =>
            IDataTableChunk(items, idxCols);

        protected C IDataTableValue(object search)
        {
            var filter = search.ToDataTableFilter(_dataTable);

            try
            {
                DataRow[] rows;
                if (filter.Length <= 0 || (rows = _dataTable.Select(filter)).Length <= 0) return default;
                return rows.First().Convert<C>();
            }
            catch (Exception e)
            {
                Log.Error(filter);
                Log.Error(e);
                throw;
            }
        }

        private void IDataTableChunk(IEnumerable<C> items = null, params string[] idxCols)
        {
            var cData = items ?? new C[] { };
            var props = typeof(C).GetProperties();

            _dataTable.PrimaryKey = idxCols.Where(c => !string.IsNullOrEmpty(c)).Select(n => n.ToLower()).Where(
                                               keyCol => _dataTable.Columns.Contains(keyCol) &&
                                                         !_dataTable.PrimaryKey.Select(c => c.ColumnName)
                                                                    .Contains(keyCol))
                                           .Select(kc => _dataTable.Columns[kc]).ToArray();

            Log.Info($"Starting Data Chunk #{typeof(T).Name}");
            Log.Info($"DataChunk Stats: Total Data to Chunk: #{cData.Count()} [{typeof(T).Name}]");

            // Group the data to remove duplicates
            Log.Info(
                $"Starting Data Chunk Loading With{(_dataTable.PrimaryKey.Length <= 0 ? "out " : " ")}Grouping #{typeof(T).Name}");

            (_dataTable.PrimaryKey.Length <= 0
                    ? cData
                    : cData.GroupBy(
                               d => string.Join(".",
                                                props.Where(pr => _dataTable.IsPrimaryKey(pr.Name.ToLower()))
                                                     .Select(
                                                         ps =>
                                                             $"{UtilClass.MissValue(ps.PropertyType, ps.GetValue(d))}"))
                                          .ToLower().ToHash())
                           .Select(g => g.First())
                ).ToDataTable(_dataTable, count =>
                {
                    if (0 == count % Consts.LOOP_LOG_COUNT)
                        Log.Info($"Data Chunk Count {count} of {cData.Count()} #{typeof(T).Name}");
                });

            Log.Info($"DataChunk Stats: Total Chunks: #{_dataTable.Rows.Count}/{cData.Count()} [{typeof(T).Name}]");
            Log.Info($"Finished Data Chunk #{typeof(T).Name}");
        }

        /*protected C ChunkTupleValue(string[] keys)
        {
            var tKey = string.Join(".", keys);
            return !keys.HasNullOrEmpty() && tupleChunk.ContainsKey(tKey) ? tupleChunk[tKey] : default;
        }*/

        #endregion
    }
}