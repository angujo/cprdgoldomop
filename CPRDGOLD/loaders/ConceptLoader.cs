using System;
using System.Collections.Generic;
using CPRDGOLD.models;
using DBMS;

namespace CPRDGOLD.loaders
{
    internal class ConceptLoader : FullLoader<ConceptLoader, Concept>
    {
        public ConceptLoader() : base(DB.Vocabulary, "concept")
        {
        }

        /*public override void ChunkData(IEnumerable<Concept> items = null)
        {
            ParallelChunk(item => new[]
                          {
                new[] { item.concept_code },
                new[] { item.concept_code, item.vocabulary_id },
                 null!= item.standard_concept && item.standard_concept.Equals("S",StringComparison.OrdinalIgnoreCase)? new[] { item.concept_name, item.domain_id,"ND" }:new string[]{},
              null!= item.standard_concept && item.standard_concept.Equals("S",StringComparison.OrdinalIgnoreCase)? new[] { item.concept_code, item.vocabulary_id, "S" }:new string[]{},
                null!= item.standard_concept && item.standard_concept.Equals("S",StringComparison.OrdinalIgnoreCase)?  new[] { item.concept_code, "S" }:new string[]{},
            },
                items);
        }*/

        public override void ChunkData(IEnumerable<Concept> items = null) => DataTableChunk(
            items, new[] {"concept_code", "vocabulary_id", "standard_concept", "concept_name", "domain_id",}
        );

        public static Concept ByCode(string code) => DataTableValue(new {concept_code = code});

        public static Concept ByStdCodeVocab(string code, string vocab) =>
            DataTableValue(new {concept_code = code, vocabulary_id = vocab, standard_concept = "S"});

        public static Concept ByStdNameDomain(string name, string domain) =>
            DataTableValue(new {concept_name = name, domain_id = domain, standard_concept = "S"});

        /*public static Concept ByCodeVocab(string code, string vocab) =>
            DataTableValue(new {concept_code = code, vocabulary_id = vocab});
        public static Concept ByStdCode(string code) =>
            DataTableValue(new {concept_code = code, standard_concept = "S"});*/
    }
}