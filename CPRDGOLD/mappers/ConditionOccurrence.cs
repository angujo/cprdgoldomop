using CPRDGOLD.mergers;
using DBMS;
using System;
using System.Linq;
using Util;

namespace CPRDGOLD.mappers
{
    internal class ConditionOccurrence : Mapper<ConditionOccurrence>
    {
        public int condition_concept_id { get; set; }
        public DateTime? condition_end_date { get; set; }
        public DateTime? condition_end_datetime { get; set; }
        public long? condition_occurrence_id { get; set; }
        public int? condition_source_concept_id { get; set; }
        public string condition_source_value { get; set; }
        public DateTime? condition_start_date { get; set; }
        public DateTime? condition_start_datetime { get; set; }
        public int? condition_status_concept_id { get; set; }
        public string condition_status_source_value { get; set; }
        public int? condition_type_concept_id { get; set; }
        public long? person_id { get; set; }
        public long? provider_id { get; set; }
        public string stop_reason { get; set; }
        public long? visit_detail_id { get; set; }
        public long? visit_occurrence_id { get; set; }

        protected override void LoadData(dynamic stemSource)
        {
            StemTableMerger stemTable = stemSource as StemTableMerger;
            string[] cols = new string[] { "provider_id",  "condition_occurrence_id",
                "condition_source_value", "person_id", "condition_concept_id", "condition_start_date", "condition_source_concept_id", "condition_start_datetime",
                "condition_end_date", "condition_end_datetime", "condition_type_concept_id","visit_occurrence_id", };
            DB.Target.CopyBinaryRows<ConditionOccurrence>(cols, (row, write) =>
            {
                stemTable.LoopAllData(stem =>
               {
                   if (string.IsNullOrEmpty(stem.domain_id) || !stem.domain_id.ToString().HasString("condition")) return;
                   row();

                   write(stem.provider_id);
                   write(stem.id);
                   write(stem.source_value);
                   write(stem.person_id);
                   write(stem.concept_id);
                   write(stem.start_date);
                   write(stem.source_concept_id);
                   write(stem.start_datetime);
                   write(DateTime.TryParse(stem.end_date, out DateTime dt1) ? dt1 : default);
                   write(DateTime.TryParse(stem.end_date, out DateTime dt2) ? dt2 : default);
                   write(stem.type_concept_id);
                   write(stem.chunk_identifier);
               });
            });
        }

        // public void Dependency() => chunk.Implement(LoadType.CONDITIONERA, () => FileQuery.ExecuteFile(Script.ForCPRDGOLD<ConditionEra>(), new string[][] { new string[] { @"{ch}", chunk.ordinal.ToString() } }));
    }
}
