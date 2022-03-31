using System;
using System.Linq;
using Util;

namespace CPRDGOLD.mappers
{
    internal class VisitOccurrence : Mapper<VisitOccurrence>
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

        [Saveable(false)]
        public long visit_occurrence_id { get; set; }
        public int? visit_source_concept_id { get; set; }
        public string visit_source_value { get; set; }
        public DateTime visit_start_date { get; set; }
        public DateTime? visit_start_datetime { get; set; }
        public int visit_type_concept_id { get; set; }

        protected override void LoadData()
        {
            var details = VisitDetail.GetData().GroupBy(dt => new { dt.person_id, dt.visit_detail_start_date }).Select(ds => ds.First());
            foreach (var item in details)
            {
                Add(new VisitOccurrence
                {
                    person_id = item.person_id,
                    visit_concept_id = 9202,
                    visit_start_date = item.visit_detail_start_date,
                    visit_start_datetime = item.visit_detail_start_datetime,
                    visit_end_date = item.visit_detail_end_date,
                    visit_end_datetime = item.visit_detail_end_datetime,
                    visit_type_concept_id = 32827,
                    provider_id = item.provider_id,
                    care_site_id = item.care_site_id,
                    visit_source_value = item.visit_detail_source_value,
                    visit_source_concept_id = 0
                });
            }
        }
    }
}
