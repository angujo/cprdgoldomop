using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;
using Util;

namespace CPRDGOLD.loaders
{
    public class LookupLoader : FullLoader<LookupLoader, Lookup>
    {
        public LookupLoader() : base("lookup") { }

        public override void ChunkData(IEnumerable<Lookup> items = null)
        {
            ParallelChunk(sstd => new[]
            {
                new[] { $"{sstd.code}",Consts.TUPLE_MISS, sstd.name },
                new[] { $"{sstd.code}", $"{sstd.lookup_type_id}" },
            }, items);
        }

        public static Lookup ByNameCode(string name, string code) => ChunkValue(code, Consts.TUPLE_MISS, name);

        public static Lookup ByCodeType(string code, long[] type_id) => ChunkValue(type_id.Select(v => new[] { code, $"{v}"}));

        public static Lookup ByCodeType(string code, long type_id) => ByCodeType(code, new[] { type_id });
    }
}
