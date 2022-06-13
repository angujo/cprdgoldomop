using System;
using CPRDGOLD.mergers;
using DBMS;
using Util;

namespace CPRDGOLD.mappers
{
    internal class Observation : Mapper<Observation>
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

        protected override void LoadData(dynamic stemSource)
        {
            var stemTable = stemSource as StemTableMerger;
            string[] cols = { "provider_id",  "unit_source_value", "observation_id", "observation_source_value",
                "person_id", "observation_source_concept_id", "observation_date", "observation_concept_id", "observation_datetime", "observation_type_concept_id",
                "value_as_number", "value_as_concept_id", "unit_concept_id", "value_as_string","visit_occurrence_id" };
            DB.Target.CopyBinaryRows<Observation>(cols, (row, write) =>
            {
                stemTable.LoopAllData(stem =>
               {
                   if (null == stem.domain_id || !stem.domain_id.HasString("observation")) return;
                   row();

                   write(stem.provider_id);
                   write(stem.unit_source_value);
                   write(stem.id);
                   write(stem.source_value);
                   write(stem.person_id);
                   write(stem.source_concept_id);
                   write(stem.start_date);
                   write(stem.concept_id);
                   write(stem.start_datetime);
                   write(stem.type_concept_id);
                   write(decimal.TryParse(stem.value_as_number, out var vn) ? vn : default);
                   write(int.TryParse(stem.value_as_concept_id, out var vc) ? vc : default);
                   write(int.TryParse(stem.unit_concept_id, out var uc) ? uc : default);
                   write(stem.value_as_string);
                   write(stem.chunk_identifier);
               });
            });
        }
    }
}
