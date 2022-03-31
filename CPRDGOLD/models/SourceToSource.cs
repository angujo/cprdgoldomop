using System;

namespace CPRDGOLD.models
{
    internal class SourceToSource
    {
        public string source_code { get; set; }
        public string source_code_description { get; set; }
        public string source_concept_class_id { get; set; }
        public int? source_concept_id { get; set; }
        public string source_domain_id { get; set; }
        public string source_invalid_reason { get; set; }
        public DateTime source_valid_end_date { get; set; }
        public DateTime source_valid_start_date { get; set; }
        public string source_vocabulary_id { get; set; }
        public string target_concept_class_id { get; set; }
        public int? target_concept_id { get; set; }
        public string target_concept_name { get; set; }
        public string target_domain_id { get; set; }
        public string target_invalid_reason { get; set; }
        public string target_standard_concept { get; set; }
        public string target_vocabulary_id { get; set; }
    }
}
