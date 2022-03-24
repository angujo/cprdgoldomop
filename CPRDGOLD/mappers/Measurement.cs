using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Measurement
    {
        public int measurement_concept_id { get; set; }
        public DateTime measurement_date { get; set; }
        public DateTime? measurement_datetime { get; set; }
        public long measurement_id { get; set; }
        public int? measurement_source_concept_id { get; set; }
        public string measurement_source_value { get; set; }
        public string measurement_time { get; set; }
        public int measurement_type_concept_id { get; set; }
        public int? operator_concept_id { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public decimal? range_high { get; set; }
        public decimal? range_low { get; set; }
        public int? unit_concept_id { get; set; }
        public string unit_source_value { get; set; }
        public int? value_as_concept_id { get; set; }
        public decimal? value_as_number { get; set; }
        public string value_source_value { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }
    }
}
