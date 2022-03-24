using CPRDGOLD.models;
using DBMS;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class ConceptLoader : FullLoader<ConceptLoader, Concept>
    {
        public ConceptLoader() : base(DB.Target, "concept") { }
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<Concept>>
            {
                item => AddChunkByKeys(item,new string[]{item.concept_code,item.vocabulary_id,item.standard_concept}),      // Concept Code 
                item => AddChunkByKeys(item,new string[]{"concname",item.concept_name,item.domain_id,item.standard_concept}),      // Concept Code 
            });
        }

        public static Concept ByCode(string code)
        {
            //return GetMe().searchOne(c => c.concept_code == code);
            return ChunkValue(new string[] { code });
        }
        public static Concept ByCodeVocab(string code, string vocab)
        {
            //return GetMe().searchOne(c => c.concept_code == code && c.vocabulary_id == vocab);
            return ChunkValue(code, vocab);
        }
        public static Concept ByStdCodeVocab(string code, string vocab)
        {
            // GetMe().createFilter("standard", c => c.standard_concept == "S" && string.IsNullOrEmpty(c.invalid_reason));
            // return GetMe().searchOne(c => c.concept_code == code && c.vocabulary_id == vocab, "standard");
            return ChunkValue(code, vocab, "S");
        }
        public static Concept ByStdNameDomain(string name, string domain)
        {
            // GetMe().createFilter("standard", c => c.standard_concept == "S" && string.IsNullOrEmpty(c.invalid_reason));
            // return GetMe().searchOne(c => c.concept_name == name && c.domain_id == domain, "standard");
            return ChunkValue("concname", name, domain, "S");
        }
        public static Concept ByStdCode(string code)
        {
            //  GetMe().createFilter("standard", c => c.standard_concept == "S" && string.IsNullOrEmpty(c.invalid_reason));
            // return GetMe().searchOne(c => c.concept_code == code, "standard");
            return ChunkValue(code);
        }
    }
}
