using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class SourceToConceptMap
    {
        public string invalid_reason { get; set; }
        public string source_code { get; set; }
        public string source_code_description { get; set; }
        public int source_concept_id { get; set; }
        public string source_vocabulary_id { get; set; }
        public int target_concept_id { get; set; }
        public string target_vocabulary_id { get; set; }
        public DateTime valid_end_date { get; set; }
        public DateTime valid_start_date { get; set; }
    }
}
