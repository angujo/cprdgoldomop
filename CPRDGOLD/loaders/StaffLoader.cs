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
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<Staff>>
            {
                //         item =>AddChunkByKey(item,$"scodesvocab{item.source_code}{item.source_vocabulary_id}"),
            });
        }
    }
}
