using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Observation
    {
        public int? observation_concept_id { get; set; }
        public DateTime observation_date { get; set; }
        public DateTime? observation_datetime { get; set; }
        public long observation_id { get; set; }
        public int? observation_source_concept_id { get; set; }
        public string observation_source_value { get; set; }
        public int observation_type_concept_id { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public int? qualifier_concept_id { get; set; }
        public string qualifier_source_value { get; set; }
        public int? unit_concept_id { get; set; }
        public string unit_source_value { get; set; }
        public int? value_as_concept_id { get; set; }
        public decimal? value_as_number { get; set; }
        public string value_as_string { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }
    }
}
