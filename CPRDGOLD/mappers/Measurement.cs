using CPRDGOLD.mergers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void LoadData()
        {
            StemTableMerger.LoopAll(chunk, stem =>
            {
                if (!new string[] { "Measurement" }.Contains(stem.domain_id)) return;
                Add(new Measurement
                {
                    provider_id = stem.provider_id,
                    visit_occurrence_id = stem.visit_occurrence_id,
                    unit_source_value = stem.unit_source_value,
                    value_source_value = stem.value_source_value,
                    measurement_id = stem.id,
                    measurement_source_value = stem.source_value,
                    person_id = stem.person_id,
                    measurement_source_concept_id = (int)stem.source_concept_id,
                    measurement_date = stem.start_date,
                    measurement_concept_id = (int)stem.concept_id,
                    measurement_datetime = stem.start_datetime,
                    measurement_type_concept_id = (int)stem.type_concept_id,
                    operator_concept_id = int.TryParse(stem.operator_concept_id, out int cid) ? cid : default,
                    value_as_number = int.TryParse(stem.value_as_number, out int vn) ? vn : default,
                    value_as_concept_id = int.TryParse(stem.value_as_concept_id, out int vc) ? vc : default,
                    unit_concept_id = int.TryParse(stem.unit_concept_id, out int uc) ? uc : default,
                    range_high = int.TryParse(stem.range_high, out int rh) ? rh : default,
                    range_low = int.TryParse(stem.range_low, out int rl) ? rl : default,
                });
            });
        }
    }
}
