using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Cost
    {
        public decimal? amount_allowed { get; set; }
        public string cost_domain_id { get; set; }
        public long cost_event_id { get; set; }
        public long cost_id { get; set; }
        public int cost_type_concept_id { get; set; }
        public int? currency_concept_id { get; set; }
        public int? drg_concept_id { get; set; }
        public string drg_source_value { get; set; }
        public decimal? paid_by_patient { get; set; }
        public decimal? paid_by_payer { get; set; }
        public decimal? paid_by_primary { get; set; }
        public decimal? paid_dispensing_fee { get; set; }
        public decimal? paid_ingredient_cost { get; set; }
        public decimal? paid_patient_coinsurance { get; set; }
        public decimal? paid_patient_copay { get; set; }
        public decimal? paid_patient_deductible { get; set; }
        public long payer_plan_period_id { get; set; }
        public int? revenue_code_concept_id { get; set; }
        public string revenue_code_source_value { get; set; }
        public decimal? total_charge { get; set; }
        public decimal? total_cost { get; set; }
        public decimal? total_paid { get; set; }
    }
}
