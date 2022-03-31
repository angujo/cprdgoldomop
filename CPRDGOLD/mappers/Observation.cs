using CPRDGOLD.mergers;
using System;
using System.Linq;

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

        protected override void LoadData()
        {
            StemTableMerger.LoopAll(chunk, stem =>
            {
                if (!new string[] { "Measurement" }.Contains(stem.domain_id)) return;
                Add(new Observation
                {
                    provider_id = stem.provider_id,
                    visit_occurrence_id = stem.visit_occurrence_id,
                    unit_source_value = stem.unit_source_value,
                    observation_id = stem.id,
                    observation_source_value = stem.source_value,
                    person_id = stem.person_id,
                    observation_source_concept_id = (int)stem.source_concept_id,
                    observation_date = stem.start_date,
                    observation_concept_id = (int)stem.concept_id,
                    observation_datetime = stem.start_datetime,
                    observation_type_concept_id = (int)stem.type_concept_id,
                    value_as_number = Decimal.TryParse(stem.value_as_number, out Decimal vn) ? vn : default,
                    value_as_concept_id = int.TryParse(stem.value_as_concept_id, out int vc) ? vc : default,
                    unit_concept_id = int.TryParse(stem.unit_concept_id, out int uc) ? uc : default,
                    value_as_string = stem.value_as_string,
                });
            });
        }
    }
}
