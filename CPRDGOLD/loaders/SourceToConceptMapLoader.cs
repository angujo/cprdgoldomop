﻿using CPRDGOLD.models;
using System.Collections.Generic;

namespace CPRDGOLD.loaders
{
    internal class SourceToConceptMapLoader : FullLoader<SourceToConceptMapLoader, SourceToConceptMap>
    {
        public SourceToConceptMapLoader() : base("source_to_concept_map") { }
        public override void ChunkData(IEnumerable<SourceToConceptMap> items = null)
        {
            ParallelChunk(item => new string[] { item.source_code, item.source_vocabulary_id.ToLower() }, items);
        }

        public static SourceToConceptMap ByJobCode(string code) => ChunkValue(code);
    }
}
