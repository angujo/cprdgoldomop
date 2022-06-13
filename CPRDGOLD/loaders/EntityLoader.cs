using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class EntityLoader : FullLoader<EntityLoader, Entity>
    {
        public EntityLoader() : base("entity")
        {
        }

        public override void ChunkData(IEnumerable<Entity> items = null)
        {
            DataTableChunk(items, new[] {"enttype", "data_fields",});
            /*ParallelChunk(item => new[]
            { 
                new[] { item.enttype, item.data_fields, }.Select(k => $"{k}").ToArray(),
                new[] { item.enttype, }.Select(k => $"{k}").ToArray(),
            }, items);*/
        }

        public static Entity ByDataFieldType(int[] dfields, int e_type) =>
            DataTableValue(new {data_fields = dfields, enttype = e_type,});

        public static Entity ByDataFieldType(int dfield, int e_type) =>
            DataTableValue(new {data_fields = dfield, enttype = e_type});

        public static Entity ByType(int e_type) => DataTableValue(new {enttype = e_type});
    }
}