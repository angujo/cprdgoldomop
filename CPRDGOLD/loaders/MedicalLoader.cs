using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class MedicalLoader : FullLoader<MedicalLoader, Medical>
    {
        public MedicalLoader() : base("medical") { }
        public override void ChunkData(IEnumerable<Medical> items = null)
        {
            ParallelChunk(item => new[] { $"{item.medcode}" }, items);
        }

        public static Medical ByMedcode(string medcode) => long.TryParse(medcode, out long mc) ? ByMedcode(mc) : null;

        public static Medical ByMedcode(long medcode) => ChunkValue($"{medcode}");
    }
}
