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

        public override void ChunkData()
        {
            ParallelChunk(new List<Action<SourceToStandard>>
            {
                sstd =>AddChunkByKeys(sstd, new string[]{sstd.source_code, "tvocab",sstd.target_vocabulary_id}),  // SourceCode and Target Vocabulary     
                sstd =>AddChunkByKeys(sstd, new string[]{sstd.source_code, "svocab",sstd.source_vocabulary_id}),           // SourceCode and Source Vocabulary
            });
        }

        public static SourceToStandard BySourceCodeTargetVocab(string code, string vocab) => BySourceCodeTargetVocab(code, new string[] { vocab });
        public static SourceToStandard BySourceCodeTargetVocab(string code, string[] vocab)
        {
            // return GetMe().searchOne(st => st.source_code == code && vocab.Contains(st.target_vocabulary_id), $"sctv{code}{string.Join(".", vocab)}");
            // return GetMe().QuerySearchOne("source_code = ? AND target_vocabulary_id IN (?)", new object[] { code, vocab }, st => st.source_code == code && vocab.Contains(st.target_vocabulary_id));
            return ChunkValue(vocab.Select(v => new string[] { code, "tvocab", v }));
        }
        public static SourceToStandard BySourceCodeSourceVocab(string code, string vocab) => BySourceCodeSourceVocab(code, new string[] { vocab });
        public static SourceToStandard BySourceCodeSourceVocab(string code, string[] vocab)
        {
            //  return GetMe().searchOne(st => st.source_code == code && vocab.Contains(st.source_vocabulary_id), $"sctv{code}{string.Join(".", vocab)}");
            //  return GetMe().QuerySearchOne("source_code = ? AND source_vocabulary_id IN (?)", new object[] { code, vocab }, st => st.source_code == code && vocab.Contains(st.source_vocabulary_id));
            return ChunkValue(vocab.Select(v => new string[] { code, "svocab", v }));
        }
    }
}
