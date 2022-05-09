using System;
using CPRDGOLD.loaders;
using DBMS;
using DBMS.models;

namespace CPRDGOLD.mappers
{
    internal class VisitDetail : Mapper<VisitDetail>
    {
        public int? admitting_source_concept_id { get; set; }
        public string admitting_source_value { get; set; }
        public long care_site_id { get; set; }
        public int? discharge_to_concept_id { get; set; }
        public string discharge_to_source_value { get; set; }
        public long visit_detail_parent_id { get; set; }
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

        protected override void LoadData(dynamic dSource = null)
        {
            string[] cols = { "person_id", "visit_detail_concept_id", "visit_detail_start_date", "visit_detail_start_datetime",
                "visit_detail_end_date", "visit_detail_end_datetime", "visit_detail_type_concept_id", "provider_id", "care_site_id", "visit_detail_source_value",
                "visit_detail_source_concept_id","visit_occurrence_id", };
            DB.Target.CopyBinaryRows<VisitDetail>(cols, (row, write) =>
           {
               chunk.GetLoader<ConsultationLoader>(ChunkLoadType.CONSULTATION).LoopAllData(consult =>
                {
                    row();
                    write(consult.patid);
                    write(9202);
                    write(consult.eventdate);
                    write(consult.eventdate);
                    write(consult.eventdate);
                    write(consult.eventdate);
                    write(32827);
                    write(consult.staffid);
                    write(consult.care_site_id);
                    write(consult.constype.ToString());
                    write(0);
                    write(consult.chunk_identifier);
                });
           });
        }
    }
}
