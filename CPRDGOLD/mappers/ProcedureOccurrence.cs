using System;
using CPRDGOLD.mergers;
using DBMS;
using Util;

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

        protected override void LoadData(dynamic stemSource)
        {
            StemTableMerger stemTable = stemSource as StemTableMerger;
            string[] cols = { "provider_id",  "procedure_occurrence_id", "procedure_source_value",
                "person_id", "procedure_source_concept_id", "procedure_date", "procedure_concept_id", "procedure_datetime",
                "procedure_type_concept_id","visit_occurrence_id", };
            DB.Target.CopyBinaryRows<ProcedureOccurrence>(cols, (row, write) =>
            {
                stemTable.LoopAllData(stem =>
               {
                   if (null == stem.domain_id || !stem.domain_id.HasString("procedure")) return;
                   row();

                   write(stem.provider_id);
                   write(stem.id);
                   write(stem.source_value);
                   write(stem.person_id);
                   write(stem.source_concept_id);
                   write(stem.start_date);
                   write(stem.concept_id);
                   write(stem.start_datetime);
                   write(stem.type_concept_id);
                   write(stem.chunk_identifier);
               });
            });
        }
    }
}
