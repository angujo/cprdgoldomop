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
    internal class SourceToStandardLoader : FullLoader<SourceToStandardLoader, SourceToStandard>
    {
        public SourceToStandardLoader() : base("source_to_standard") { }

        public override void ChunkData(IEnumerable<SourceToStandard> items = null)
        {
            ParallelChunk(item => new string[] { item.source_code, item.target_vocabulary_id, item.source_vocabulary_id }, items);
        }

        public static SourceToStandard BySourceCodeTargetVocab(string code, string vocab) => BySourceCodeTargetVocab(code, new string[] { vocab });
        public static SourceToStandard BySourceCodeTargetVocab(string code, string[] vocab) => ChunkValue(vocab.Select(v => new string[] { code, v, Consts.TUPLE_MISS }));
        public static SourceToStandard BySourceCodeSourceVocab(string code, string vocab) => BySourceCodeSourceVocab(code, new string[] { vocab });
        public static SourceToStandard BySourceCodeSourceVocab(string code, string[] vocab) => ChunkValue(vocab.Select(v => new string[] { code, Consts.TUPLE_MISS, v }));
    }
}
