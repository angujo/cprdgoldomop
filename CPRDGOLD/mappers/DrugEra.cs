using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class DrugEra
    {
        public DateTime dose_era_end_date { get; set; }
        public long dose_era_id { get; set; }
        public DateTime dose_era_start_date { get; set; }
        public decimal dose_value { get; set; }
        public int drug_concept_id { get; set; }
        public int unit_concept_id { get; set; }
        public DateTime drug_era_end_date { get; set; }
        public long drug_era_id { get; set; }
        public DateTime drug_era_start_date { get; set; }
        public int? drug_exposure_count { get; set; }
        public int? gap_days { get; set; }
        public long person_id { get; set; }
    }
}
