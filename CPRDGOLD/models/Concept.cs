using System;

namespace CPRDGOLD.models
{
    internal class Concept
    {
        public string concept_class_id { get; set; }
        public string concept_code { get; set; }
        public int concept_id { get; set; }
        public string concept_name { get; set; }
        public string domain_id { get; set; }
        public string invalid_reason { get; set; }
        public string standard_concept { get; set; }
        public DateTime valid_end_date { get; set; }
        public DateTime valid_start_date { get; set; }
        public string vocabulary_id { get; set; }
    }
}
