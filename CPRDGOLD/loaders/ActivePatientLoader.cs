using CPRDGOLD.models;
using DBMS.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.loaders
{
    internal class ActivePatientLoader : ChunkLoader<ActivePatientLoader, Patient>
    {
        public ActivePatientLoader() : base("patient") { }
        public ActivePatientLoader(Chunk chunk) : base("patient", chunk) { }
    }
}
