using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;
using Util;

namespace CPRDGOLD.loaders
{
    public class LookupLoader : FullLoader<LookupLoader, Lookup>
    {
        public LookupLoader() : base("lookup")
        {
        }

        public override void ChunkData(IEnumerable<Lookup> items = null)
        {
            DataTableChunk(items, new[] {"code", "name", "lookup_type_id",});
            /*ParallelChunk(sstd => new[]
            {
                new[] {$"{sstd.code}", Consts.TUPLE_MISS_STR, sstd.name},
                new[] {$"{sstd.code}", $"{sstd.lookup_type_id}"},
            }, items);*/
        }

        public static Lookup ByNameCode(string name, string code) => DataTableValue(new {code, name,});

        public static Lookup ByCodeType(string code, long[] type_id) =>
            DataTableValue(new {code, lookup_type_id = type_id});

        public static Lookup ByCodeType(string code, long type_id) =>
            DataTableValue(new {code, lookup_type_id = type_id});
    }
}