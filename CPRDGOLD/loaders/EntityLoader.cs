using CPRDGOLD.models;
using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class EntityLoader : FullLoader<EntityLoader, Entity>
    {
        public EntityLoader() : base("entity") { }
        public override void ChunkData(IEnumerable<Entity> items = null)
        {
            ParallelChunk(new List<Action<Entity>>
            {
                item =>AddChunkByKeys(item,new int[]{item.enttype,item.data_fields,}.Select(k=>$"{k}").ToArray()),       // DataFields & Enttype
            },items);
        }

        public static Entity ByDataFieldType(int[] dfields, int e_type, string name = null)
        {
            // return GetMe().searchOne(e => e.enttype == e_type && dfields.Contains(e.data_fields), name ?? $"datafieldstype{e_type}{string.Join(".", dfields)}");
            return ChunkValue(dfields.Select(v => new int[] { e_type, v }.Select(k => $"{k}").ToArray()));
        }

        public static Entity ByDataFieldType(int dfield, int e_type, string name = null)
        {
            return ByDataFieldType(new int[] { dfield }, e_type, name);
        }

        public static Entity ByType(int e_type)
        {
            //return GetMe().searchOne(e => e.enttype == e_type, $"enttype{e_type}");
            return ChunkValue($"{e_type}");
        }
    }
}
