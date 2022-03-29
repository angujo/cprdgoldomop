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
            ParallelChunk(item => new string[][] { 
                new int[] { item.enttype, item.data_fields, }.Select(k => $"{k}").ToArray(),
                new int[] { item.enttype, }.Select(k => $"{k}").ToArray(),
            }, items);
        }

        public static Entity ByDataFieldType(int[] dfields, int e_type) => ChunkValue(dfields.Select(v => new int[] { e_type, v }.Select(k => $"{k}").ToArray()));

        public static Entity ByDataFieldType(int dfield, int e_type) => ByDataFieldType(new int[] { dfield }, e_type);

        public static Entity ByType(int e_type) => ChunkValue( $"{e_type}");
    }
}
