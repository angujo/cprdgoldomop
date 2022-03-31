using CPRDGOLD.models;
using System.Collections.Generic;

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
