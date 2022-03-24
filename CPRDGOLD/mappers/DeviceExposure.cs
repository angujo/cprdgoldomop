using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class DeviceExposure
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
    }
}
