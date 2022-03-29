using CPRDGOLD.models;
using DBMS;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    public class LookupLoader : FullLoader<LookupLoader, Lookup>
    {
        public LookupLoader() : base("lookup") { }

        public override void ChunkData(IEnumerable<Lookup> items = null)
        {
            ParallelChunk(sstd => new string[][] {
                new string[] { $"{sstd.code}",Consts.TUPLE_MISS, sstd.name },
                new string[] { $"{sstd.code}", $"{sstd.lookup_type_id}" },
            }, items);
        }

        public static Lookup ByNameCode(string name, string code) => ChunkValue(code, Consts.TUPLE_MISS, name);

        public static Lookup ByCodeType(string code, long[] type_id) => ChunkValue(type_id.Select(v => new string[] { code, $"{v}"}));

        public static Lookup ByCodeType(string code, long type_id) => ByCodeType(code, new long[] { type_id });
    }
}
