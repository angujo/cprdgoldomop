using System;

namespace CPRDGOLD.models
{
    internal class Therapy:ChunkedModel
    {
        public int bnfcode { get; set; }
        public int consid { get; set; }
        public string dosageid { get; set; }
        public string drugdmd { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public int? issueseq { get; set; }
        public int? numdays { get; set; }
        public decimal? numpacks { get; set; }
        public int? packtype { get; set; }
        public long patid { get; set; }
        public bool? prn { get; set; }
        public long prodcode { get; set; }
        public decimal? qty { get; set; }
        public long staffid { get; set; }
        public DateTime sysdate { get; set; }
        public string prod_gemscriptcode { get; set; }
        public int? st_source_concept_id { get; set; }
        public int? ss_source_concept_id { get; set; }
        public int? st_target_concept_id { get; set; }
        public int? ss_target_concept_id { get; set; }
        public string conc_domain_id { get; set; }
        public long chunk_identifier { get { return ChunkIdentifier(eventdate); } }
    }
}
