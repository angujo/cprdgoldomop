using System;

namespace CPRDGOLD.models
{
    internal class Immunisation:ChunkedModel
    {
        public long batch { get; set; }
        public long compound { get; set; }
        public int consid { get; set; }
        public int? constype { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public long immstype { get; set; }
        public long medcode { get; set; }
        public long method { get; set; }
        public long patid { get; set; }
        public long reason { get; set; }
        public string sctdescid { get; set; }
        public string sctexpression { get; set; }
        public string sctid { get; set; }
        public bool? sctisassured { get; set; }
        public bool? sctisindicative { get; set; }
        public short sctmaptype { get; set; }
        public int? sctmapversion { get; set; }
        public long source { get; set; }
        public long staffid { get; set; }
        public long stage { get; set; }
        public long status { get; set; }
        public DateTime sysdate { get; set; }
        public string med_read_code { get; set; }
        public int? st_source_concept_id { get; set; }
        public int? ss_source_concept_id { get; set; }
        public int? st_target_concept_id { get; set; }
        public int? ss_target_concept_id { get; set; }
        public string conc_domain_id { get; set; }
        public long chunk_identifier { get { return ChunkIdentifier(eventdate); } }
    }
}
