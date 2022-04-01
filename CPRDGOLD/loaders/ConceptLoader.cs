using CPRDGOLD.models;
using DBMS;
using System;
using System.Collections.Generic;

namespace CPRDGOLD.loaders
{
    internal class ConceptLoader : FullLoader<ConceptLoader, Concept>
    {
        public ConceptLoader() : base(DB.Vocabulary, "concept") { }
        public override void ChunkData(IEnumerable<Concept> items = null)
        {
            ParallelChunk(item => new string[][] {
                new string[] { item.concept_code },
                new string[] { item.concept_code, item.vocabulary_id },
                 null!= item.standard_concept && item.standard_concept.Equals("S",StringComparison.OrdinalIgnoreCase)? new string[] { item.concept_name, item.domain_id,"ND" }:new string[]{},
              null!= item.standard_concept && item.standard_concept.Equals("S",StringComparison.OrdinalIgnoreCase)? new string[] { item.concept_code, item.vocabulary_id, "S" }:new string[]{},
                null!= item.standard_concept && item.standard_concept.Equals("S",StringComparison.OrdinalIgnoreCase)?  new string[] { item.concept_code, "S" }:new string[]{},
            },
                items);
        }

        public static Concept ByCode(string code) => ChunkValue(new string[] { code, });
        public static Concept ByCodeVocab(string code, string vocab) => ChunkValue(code, vocab);
        public static Concept ByStdCodeVocab(string code, string vocab) => ChunkValue(code, vocab, "S");
        public static Concept ByStdNameDomain(string name, string domain) => ChunkValue(name, domain, "ND");
        public static Concept ByStdCode(string code) => ChunkValue(code, "S");
    }
}
