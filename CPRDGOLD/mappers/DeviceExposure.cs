using CPRDGOLD.mergers;
using DBMS;
using System;
using System.Linq;
using Util;

namespace CPRDGOLD.mappers
{
    internal class DeviceExposure : Mapper<DeviceExposure>
    {
        public int device_concept_id { get; set; }
        public DateTime device_exposure_end_date { get; set; }
        public DateTime? device_exposure_end_datetime { get; set; }
        public long device_exposure_id { get; set; }
        public DateTime device_exposure_start_date { get; set; }
        public DateTime? device_exposure_start_datetime { get; set; }
        public int? device_source_concept_id { get; set; }
        public string device_source_value { get; set; }
        public int device_type_concept_id { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public int? quantity { get; set; }
        public string unique_device_id { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }

        protected override void LoadData(dynamic stemSource)
        {
            StemTableMerger stemTable = stemSource as StemTableMerger;
            string[] cols = new string[] { "provider_id",  "device_exposure_id", "device_source_value", "person_id", "device_source_concept_id",
                "device_exposure_start_date", "device_concept_id", "device_exposure_start_datetime", "device_exposure_end_date", "device_exposure_end_datetime",
                "device_type_concept_id","visit_occurrence_id",  };
            DB.Target.CopyBinaryRows<DeviceExposure>(cols, (row, write) =>
            {
                stemTable.LoopAllData(stem =>
               {
                   if (null == stem.domain_id || !stem.domain_id.HasString("device")) return;
                   row();

                   write(stem.provider_id);
                   write(stem.id);
                   write(stem.source_value);
                   write(stem.person_id);
                   write(stem.source_concept_id);
                   write(stem.start_date);
                   write(stem.concept_id);
                   write(stem.start_datetime);
                   write(DateTime.TryParse(stem.end_date, out DateTime dt1) ? dt1 : default);
                   write(DateTime.TryParse(stem.end_date, out DateTime dt2) ? dt2 : default);
                   write(stem.type_concept_id);
                   write(stem.chunk_identifier);
               });
            });
        }
    }
}
