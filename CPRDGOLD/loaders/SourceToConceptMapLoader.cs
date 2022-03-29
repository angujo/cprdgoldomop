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
    internal class SourceToConceptMapLoader : FullLoader<SourceToConceptMapLoader, SourceToConceptMap>
    {
        public SourceToConceptMapLoader() : base("source_to_concept_map") { }
        public override void ChunkData(IEnumerable<SourceToConceptMap> items = null)
        {
            ParallelChunk(item => new string[] { item.source_code }, items);
        }

        public static SourceToConceptMap BySourceCode(string code) => ChunkValue(code);
    }
}
