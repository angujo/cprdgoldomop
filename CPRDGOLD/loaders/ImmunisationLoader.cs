using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class ImmunisationLoader:ChunkLoader<ImmunisationLoader,Immunisation>
    {
        public ImmunisationLoader() : base("immunisation") { }
        public ImmunisationLoader(Chunk chunk) : base("immunisation", chunk) { }
    }
}
