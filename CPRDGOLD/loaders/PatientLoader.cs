using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class PatientLoader : ChunkLoader<PatientLoader, Patient>
    {
        public PatientLoader() : base("patient") { }
        public PatientLoader(Chunk chunk) : base("patient", chunk) { }
    }
}
