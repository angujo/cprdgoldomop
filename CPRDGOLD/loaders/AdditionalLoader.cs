using CPRDGOLD.models;
using DBMS.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.loaders
{
    internal class AdditionalLoader : ChunkLoader<AdditionalLoader, Additional>
    {
        public AdditionalLoader() : base("additional") { }
        public AdditionalLoader(Chunk chunk) : base("additional", chunk) { }
    }
}
