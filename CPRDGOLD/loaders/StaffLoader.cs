using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class StaffLoader : FullLoader<StaffLoader, Staff>
    {
        public StaffLoader() : base("staff") { }
        public override void ChunkData(IEnumerable<Staff> items = null)
        {
            ParallelChunk(items);
        }
    }
}
