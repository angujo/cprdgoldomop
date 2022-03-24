using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class DrugExposure
    {
        public int? days_supply { get; set; }
        public string dose_unit_source_value { get; set; }
        public int drug_concept_id { get; set; }
        public DateTime drug_exposure_end_date { get; set; }
        public DateTime? drug_exposure_end_datetime { get; set; }
        public long drug_exposure_id { get; set; }
        public DateTime drug_exposure_start_date { get; set; }
        public DateTime? drug_exposure_start_datetime { get; set; }
        public int? drug_source_concept_id { get; set; }
        public string drug_source_value { get; set; }
        public int drug_type_concept_id { get; set; }
        public string lot_number { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public decimal? quantity { get; set; }
        public int? refills { get; set; }
        public int? route_concept_id { get; set; }
        public string route_source_value { get; set; }
        public string sig { get; set; }
        public string stop_reason { get; set; }
        public DateTime verbatim_end_date { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }
    }
}
