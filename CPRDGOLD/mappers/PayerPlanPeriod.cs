using System;

namespace CPRDGOLD.mappers
{
    internal class PayerPlanPeriod
    {
        public string family_source_value { get; set; }
        public int? payer_concept_id { get; set; }
        public DateTime payer_plan_period_end_date { get; set; }
        public long payer_plan_period_id { get; set; }
        public DateTime payer_plan_period_start_date { get; set; }
        public int? payer_source_concept_id { get; set; }
        public string payer_source_value { get; set; }
        public long person_id { get; set; }
        public int? plan_concept_id { get; set; }
        public int? plan_source_concept_id { get; set; }
        public string plan_source_value { get; set; }
        public int? sponsor_concept_id { get; set; }
        public int? sponsor_source_concept_id { get; set; }
        public string sponsor_source_value { get; set; }
        public int? stop_reason_concept_id { get; set; }
        public int? stop_reason_source_concept_id { get; set; }
        public string stop_reason_source_value { get; set; }
    }
}
