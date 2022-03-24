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
    internal class SourceToConceptMapLoader: FullLoader<SourceToConceptMapLoader,SourceToConceptMap>
    {
        public SourceToConceptMapLoader() : base("source_to_concept_map") { }
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<SourceToConceptMap>>
            {
            //    item =>AddChunkByKey(item,$"medcode{item.medcode}"),       //  Medcode
            });
        }
    }
}
