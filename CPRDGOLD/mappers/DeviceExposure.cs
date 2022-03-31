using CPRDGOLD.mergers;
using System;
using System.Linq;

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

        protected override void LoadData()
        {
            StemTableMerger.LoopAll(chunk, stem =>
            {
                if (!new string[] { "Device" }.Contains(stem.domain_id)) return;
                Add(new DeviceExposure
                {
                    provider_id = stem.provider_id,
                    visit_occurrence_id = stem.visit_occurrence_id,
                    quantity = null,
                    device_exposure_id = stem.id,
                    device_source_value = stem.source_value,
                    person_id = stem.person_id,
                    device_source_concept_id = (int)stem.source_concept_id,
                    device_exposure_start_date = stem.start_date,
                    device_concept_id = (int)stem.concept_id,
                    device_exposure_start_datetime = stem.start_datetime,
                    device_exposure_end_date = string.IsNullOrEmpty(stem.end_date) ? default : DateTime.Parse(stem.end_date),
                    device_exposure_end_datetime = string.IsNullOrEmpty(stem.end_date) ? default : DateTime.Parse(stem.end_date),
                    device_type_concept_id = (int)stem.type_concept_id,
                    unique_device_id = null,
                    visit_detail_id = 0,
                });
            });
        }
    }
}
