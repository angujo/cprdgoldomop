using System;

namespace CPRDGOLD.mergers
{
    internal class StemTable
    {
        public int? concept_id { get; set; }
        public string domain_id { get; set; }
        public string end_date { get; set; }
        public long id { get; set; }
        public string operator_concept_id { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public string range_high { get; set; }
        public string range_low { get; set; }
        public string sig { get; set; }
        public int? source_concept_id { get; set; }
        public string source_value { get; set; }
        public DateTime start_date { get; set; }
        public DateTime? start_datetime { get; set; }
        public int? type_concept_id { get; set; }
        public string unit_concept_id { get; set; }
        public string unit_source_value { get; set; }
        public string value_as_concept_id { get; set; }
        public string value_as_number { get; set; }
        public string value_as_string { get; set; }
        public string value_source_value { get; set; }
        public long visit_occurrence_id { get; set; }
        public long chunk_identifier { get; set; }
    }
}
