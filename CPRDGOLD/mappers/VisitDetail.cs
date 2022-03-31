using CPRDGOLD.loaders;
using System;

namespace CPRDGOLD.mappers
{
    internal class VisitDetail : Mapper<VisitDetail>
    {
        public int? admitting_source_concept_id { get; set; }
        public string admitting_source_value { get; set; }
        public long care_site_id { get; set; }
        public int? discharge_to_concept_id { get; set; }
        public string discharge_to_source_value { get; set; }
        public long parent_visit_detail_id { get; set; }
        public long person_id { get; set; }
        public long preceding_visit_detail_id { get; set; }
        public long provider_id { get; set; }
        public int visit_detail_concept_id { get; set; }
        public DateTime visit_detail_end_date { get; set; }
        public DateTime? visit_detail_end_datetime { get; set; }
        public long visit_detail_id { get; set; }
        public int? visit_detail_source_concept_id { get; set; }
        public string visit_detail_source_value { get; set; }
        public DateTime visit_detail_start_date { get; set; }
        public DateTime? visit_detail_start_datetime { get; set; }
        public int visit_detail_type_concept_id { get; set; }
        public long visit_occurrence_id { get; set; }

        protected override void LoadData()
        {
            ConsultationLoader.LoopAll(chunk, consult =>
            {
                Add(new VisitDetail
                {
                    person_id = consult.patid,
                    visit_detail_concept_id = 9202,
                    visit_detail_start_date = consult.eventdate,
                    visit_detail_start_datetime = consult.eventdate,
                    visit_detail_end_date = consult.eventdate,
                    visit_detail_end_datetime = consult.eventdate,
                    visit_detail_type_concept_id = 32827,
                    provider_id = consult.staffid,
                    care_site_id = consult.care_site_id,
                    visit_detail_source_value = consult.constype.ToString(),
                    visit_detail_source_concept_id = 0
                });
            });
        }

        public void Dependency() => VisitOccurrence.InsertSets(chunk);
    }
}
