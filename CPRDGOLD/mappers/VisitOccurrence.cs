using CPRDGOLD.loaders;
using DBMS;
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

        protected override void LoadData(dynamic dSource = null)
        {
            string[] cols = new string[] { "person_id", "visit_concept_id", "visit_start_date", "visit_start_datetime",
                "visit_end_date", "visit_end_datetime", "visit_type_concept_id", "provider_id", "care_site_id", "visit_source_value",
                "visit_source_concept_id","visit_occurrence_id" };
            DB.Target.CopyBinaryRows<VisitOccurrence>(cols, (row, write) =>
           {
               chunk.GetLoader<ConsultationLoader>(DBMS.models.ChunkLoadType.CONSULTATION)
               .LoopGroupData(
                   dt => dt.eventdate.ToString(),
                   consult =>
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
