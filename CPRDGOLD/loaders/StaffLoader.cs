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
    internal class StaffLoader : FullLoader<StaffLoader, Staff>
    {
        public StaffLoader() : base("staff") { }
        public override void ChunkData(IEnumerable<Staff> items = null)
        {
            ParallelChunk(items);
        }
    }
}
