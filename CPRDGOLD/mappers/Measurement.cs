using CPRDGOLD.mergers;
using DBMS;
using System;
using System.Linq;
using Util;

namespace CPRDGOLD.mappers
{
    internal class Measurement : Mapper<Measurement>
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

        protected override void LoadData(dynamic stemSource)
        {
            StemTableMerger stemTable = stemSource as StemTableMerger;
            string[] cols = new string[] { "provider_id",  "unit_source_value", "value_source_value", "measurement_id",
                "measurement_source_value", "person_id", "measurement_source_concept_id", "measurement_date", "measurement_concept_id",
                "measurement_datetime", "measurement_type_concept_id", "operator_concept_id", "value_as_number", "value_as_concept_id",
                "unit_concept_id", "range_high", "range_low", };
            DB.Target.CopyBinaryRows<Measurement>(cols, (row, write) =>
            {
                stemTable.LoopAllData(stem =>
               {
                   if (null == stem.domain_id || !stem.domain_id.HasString("measurement")) return;
                   row();

                   write(stem.provider_id);
                   write(stem.unit_source_value);
                   write(stem.value_source_value);
                   write(stem.id);
                   write(stem.source_value);
                   write(stem.person_id);
                   write(stem.source_concept_id);
                   write(stem.start_date);
                   write(stem.concept_id);
                   write(stem.start_datetime);
                   write(stem.type_concept_id);
                   write(int.TryParse(stem.operator_concept_id, out int cid) ? cid : default);
                   write(Decimal.TryParse(stem.value_as_number, out Decimal vn) ? vn : default);
                   write(int.TryParse(stem.value_as_concept_id, out int vc) ? vc : default);
                   write(int.TryParse(stem.unit_concept_id, out int uc) ? uc : default);
                   write(Decimal.TryParse(stem.range_high, out Decimal rh) ? rh : default);
                   write(Decimal.TryParse(stem.range_low, out Decimal rl) ? rl : default);
               });
            });
        }
    }
}
