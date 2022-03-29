using CPRDGOLD.models;
using DBMS.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.loaders
{
    internal class PatientLoader : ChunkLoader<PatientLoader, Patient>
    {
        public PatientLoader() : base("patient") { }
        public PatientLoader(Chunk chunk) : base("patient", chunk) { }
    }
}
