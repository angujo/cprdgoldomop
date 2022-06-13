using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class PracticeLoader : FullLoader<PracticeLoader, Practice>
    {
        public PracticeLoader() : base("practice")
        {
        }

        public override void ChunkData(IEnumerable<Practice> items = null)
        {
            DataTableChunk(items);
        }
    }
}