using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;
using Util;

namespace CPRDGOLD.loaders
{
    internal class SourceToStandardLoader : FullLoader<SourceToStandardLoader, SourceToStandard>
    {
        public SourceToStandardLoader() : base("source_to_standard")
        {
        }

        public override void ChunkData(IEnumerable<SourceToStandard> items = null)
        {
            DataTableChunk(items, "source_code", "target_vocabulary_id", "source_vocabulary_id");
            // ParallelChunk(item => new[] { item.source_code, item.target_vocabulary_id, item.source_vocabulary_id }, items);
        }

        public static SourceToStandard BySourceCodeTargetVocab(string code, string vocab) =>
            BySourceCodeTargetVocab(code, new[] {vocab});

        public static SourceToStandard BySourceCodeTargetVocab(string code, string[] vocab) =>
            DataTableValue(new {source_code = code, target_vocabulary_id = vocab});

        public static SourceToStandard BySourceCodeSourceVocab(string code, string vocab) =>
            BySourceCodeSourceVocab(code, new[] {vocab});

        public static SourceToStandard BySourceCodeSourceVocab(string code, string[] vocab) =>
            DataTableValue(new {source_code = code, source_vocabulary_id = vocab});
    }
}