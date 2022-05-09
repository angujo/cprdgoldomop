using System;
using CPRDGOLD.mergers;
using DBMS;
using Util;

namespace CPRDGOLD.mappers
{
    internal class Specimen : Mapper<Specimen>
    {
        public int? anatomic_site_concept_id { get; set; }
        public string anatomic_site_source_value { get; set; }
        public int? disease_status_concept_id { get; set; }
        public string disease_status_source_value { get; set; }
        public long person_id { get; set; }
        public decimal? quantity { get; set; }
        public int specimen_concept_id { get; set; }
        public DateTime specimen_date { get; set; }
        public DateTime? specimen_datetime { get; set; }
        public long specimen_id { get; set; }
        public string specimen_source_id { get; set; }
        public string specimen_source_value { get; set; }
        public int specimen_type_concept_id { get; set; }
        public int? unit_concept_id { get; set; }
        public string unit_source_value { get; set; }

        protected override void LoadData(dynamic stemSource)
        {
            StemTableMerger stemTable = stemSource as StemTableMerger;
            string[] cols = { "specimen_id", "specimen_source_value", "person_id", "specimen_date", "specimen_concept_id", "specimen_datetime",
                "specimen_type_concept_id", "unit_concept_id", "unit_source_value",  };
            DB.Target.CopyBinaryRows<Specimen>(cols, (row, write) =>
            {
                stemTable.LoopAllData(stem =>
               {
                   if (null == stem.domain_id || !stem.domain_id.HasString("specimen")) return;
                   row();

                   write(stem.id);
                   write(stem.source_value);
                   write(stem.person_id);
                   write(stem.start_date);
                   write(stem.concept_id);
                   write(stem.start_datetime);
                   write(stem.type_concept_id);
                   write(int.TryParse(stem.unit_concept_id, out int uc) ? uc : default);
                   write(stem.unit_source_value);
               });
            });
        }
    }
}
