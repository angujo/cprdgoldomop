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

        public override void ChunkData()
        {
            ParallelChunk(new List<Action<Lookup>>
            {
                sstd => AddChunkByKeys(sstd, new string[]{$"{sstd.code}",sstd.name}),
                sstd => AddChunkByKeys(sstd, $"{sstd.code}",$"{sstd.lookup_type_id}")
            });
        }

        public static Lookup ByNameCode(string name, string code)
        {
            //  return GetMe().searchOne(lu => $"{lu.code}" == code && lu.name == name, $"namecode{name}{code}".ToSnakeCase());
            //   return GetMe().QuerySearchOne("code::varchar = ? AND name = ? ", new object[] { code, name }, lu => $"{lu.code}" == code && lu.name == name);
            return ChunkValue(code, name);
        }

        public static Lookup ByCodeType(string code, long[] type_id)
        {
            // return GetMe().searchOne(lu => $"{lu.code}" == code && type_id.Contains(lu.lookup_type_id), $"codetype{string.Join(".", type_id)}{code}".ToSnakeCase());
            // return GetMe().QuerySearchOne("code::varchar = ? AND lookup.lookup_type_id IN (?) ", new object[] { code, type_id },              lu => $"{lu.code}" == code && type_id.Contains(lu.lookup_type_id));
            return ChunkValue(type_id.Select(v => new string[] { code, $"{v}" }).ToArray());
        }

        public static Lookup ByCodeType(string code, long type_id)
        {
            return ByCodeType(code, new long[] { type_id });
        }
    }
}
