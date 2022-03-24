using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class ProcedureOccurrence
    {
        public int? modifier_concept_id { get; set; }
        public string modifier_source_value { get; set; }
        public long person_id { get; set; }
        public int procedure_concept_id { get; set; }
        public DateTime procedure_date { get; set; }
        public DateTime? procedure_datetime { get; set; }
        public long procedure_occurrence_id { get; set; }
        public int? procedure_source_concept_id { get; set; }
        public string procedure_source_value { get; set; }
        public int procedure_type_concept_id { get; set; }
        public long provider_id { get; set; }
        public int? quantity { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }
    }
}
