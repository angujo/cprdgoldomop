using CPRDGOLD.mergers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class ProcedureOccurrence : Mapper<ProcedureOccurrence>
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

        protected override void LoadData()
        {
            StemTableMerger.LoopAll(chunk, stem =>
            {
                if (!new string[] { "Procedure" }.Contains(stem.domain_id)) return;
                Add(new ProcedureOccurrence
                {
                    provider_id = stem.provider_id,
                    visit_occurrence_id = stem.visit_occurrence_id,
                    procedure_occurrence_id = stem.id,
                    procedure_source_value = stem.source_value,
                    person_id = stem.person_id,
                    procedure_source_concept_id = (int)stem.source_concept_id,
                    procedure_date = stem.start_date,
                    procedure_concept_id = (int)stem.concept_id,
                    procedure_datetime = stem.start_datetime,
                    procedure_type_concept_id = (int)stem.type_concept_id,
                });
            });
        }
    }
}
