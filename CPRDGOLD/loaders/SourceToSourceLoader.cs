using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    internal class SourceToSourceLoader : FullLoader<SourceToSourceLoader, SourceToSource>
    {
        public SourceToSourceLoader() : base("source_to_source")
        {
        }

        public override void ChunkData(IEnumerable<SourceToSource> items = null)
        {
            DataTableChunk(items, "source_code", "source_vocabulary_id");
            //ParallelChunk(item => new[] { item.source_code, item.source_vocabulary_id }, items);
        }

        public static SourceToSource BySourceCodeSourceVocab(string code, string vocab) =>
            BySourceCodeSourceVocab(code, new[] {vocab});

        public static SourceToSource BySourceCodeSourceVocab(string code, string[] vocab) =>
            DataTableValue(new {source_code = code, source_vocabulary_id = vocab});
    }
}