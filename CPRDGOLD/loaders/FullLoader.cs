using DBMS;
using DBMS.systems;
using SqlKata;
using System.Collections.Generic;
using System.Linq;

namespace CPRDGOLD.loaders
{
    public abstract class FullLoader<T, C> : Loader<T, C> where T : new()
    {
        public FullLoader(string table_name) : base(DB.Source, table_name) { }
        public FullLoader(DBMSSystem db, string table_name) : base(db, table_name) { }

        public abstract void ChunkData(IEnumerable<C> items = null);

        public void CustomizeQuery(Query query, string schema_name)
        {
            switch (table_name)
            {
                case "lookup":
                    query.Join($"{schema_name}.lookuptype", "lookup.lookup_type_id", "lookuptype.lookup_type_id")
                        .SelectRaw("lookuptype.name, lookup.*");
                    break;
                case "source_to_standard":
                    query.Where("target_standard_concept", "S").WhereNull("target_invalid_reason");
                    break;
            }
        }

        public static void Initialize()
        {
            GetMe();
        }

        protected static C ChunkValue(params string[] keys) => ChunkValue(new string[][] { keys });
        protected static C ChunkValue(IEnumerable<string[]> keys) => ChunkValue(keys.ToArray());
        protected static C ChunkValue(string[][] keys) => ((FullLoader<T, C>)(object)GetMe()).IChunkValue(keys);
    }
}
