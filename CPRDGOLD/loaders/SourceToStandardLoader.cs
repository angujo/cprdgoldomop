using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;
using Util;

namespace CPRDGOLD.loaders
{
    internal class SourceToStandardLoader : FullLoader<SourceToStandardLoader, SourceToStandard>
    {
        public SourceToStandardLoader() : base("source_to_standard") { }

        public override void ChunkData(IEnumerable<SourceToStandard> items = null)
        {
            ParallelChunk(item => new[] { item.source_code, item.target_vocabulary_id, item.source_vocabulary_id }, items);
        }

        public static SourceToStandard BySourceCodeTargetVocab(string code, string vocab) => BySourceCodeTargetVocab(code, new[] { vocab });
        public static SourceToStandard BySourceCodeTargetVocab(string code, string[] vocab) => ChunkValue(vocab.Select(v => new[] { code, v, Consts.TUPLE_MISS }));
        public static SourceToStandard BySourceCodeSourceVocab(string code, string vocab) => BySourceCodeSourceVocab(code, new[] { vocab });
        public static SourceToStandard BySourceCodeSourceVocab(string code, string[] vocab) => ChunkValue(vocab.Select(v => new[] { code, Consts.TUPLE_MISS, v }));
    }
}
