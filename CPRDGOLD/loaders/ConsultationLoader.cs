using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class ConsultationLoader:ChunkLoader<ConsultationLoader,Consultation>
    {
        public ConsultationLoader() : base("consultation") { }
        public ConsultationLoader(Chunk chunk) : base("consultation", chunk) { }
    }
}
