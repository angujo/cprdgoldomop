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
    internal class SourceToSourceLoader : FullLoader<SourceToSourceLoader, SourceToSource>
    {
        public SourceToSourceLoader() : base("source_to_source") { }
        public override void ChunkData(IEnumerable<SourceToSource> items = null)
        {
            ParallelChunk(item => new string[] { item.source_code, item.source_vocabulary_id }, items);
        }
        public static SourceToSource BySourceCodeSourceVocab(string code, string vocab) => BySourceCodeSourceVocab(code, new string[] { vocab });
        public static SourceToSource BySourceCodeSourceVocab(string code, string[] vocab) => ChunkValue(vocab.Select(v => new string[] { code, v }));
    }
}
