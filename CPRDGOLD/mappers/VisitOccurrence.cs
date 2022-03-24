using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class VisitOccurrence
    {
        public long admitted_from_concept_id { get; set; }
        public string admitted_from_source_value { get; set; }
        public int? admitting_source_concept_id { get; set; }
        public string admitting_source_value { get; set; }
        public long care_site_id { get; set; }
        public int? discharge_to_concept_id { get; set; }
        public string discharge_to_source_value { get; set; }
        public long discharged_to_concept_id { get; set; }
        public string discharged_to_source_value { get; set; }
        public long person_id { get; set; }
        public long preceding_visit_occurrence_id { get; set; }
        public long provider_id { get; set; }
        public int visit_concept_id { get; set; }
        public DateTime visit_end_date { get; set; }
        public DateTime? visit_end_datetime { get; set; }
        public long visit_occurrence_id { get; set; }
        public int? visit_source_concept_id { get; set; }
        public string visit_source_value { get; set; }
        public DateTime visit_start_date { get; set; }
        public DateTime? visit_start_datetime { get; set; }
        public int visit_type_concept_id { get; set; }
    }
}
