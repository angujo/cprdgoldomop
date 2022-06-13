using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class SourceToConceptMapLoader : FullLoader<SourceToConceptMapLoader, SourceToConceptMap>
    {
        public SourceToConceptMapLoader() : base("source_to_concept_map")
        {
        }

        public override void ChunkData(IEnumerable<SourceToConceptMap> items = null)
        {
            DataTableChunk(items, "source_code", "source_vocabulary_id");
        }

        public static SourceToConceptMap ByJobCode(string code) => DataTableValue(new {source_code = code});
    }
}