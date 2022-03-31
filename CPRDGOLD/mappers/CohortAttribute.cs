using System;

namespace CPRDGOLD.mappers
{
    internal class CohortAttribute
    {
        public int attribute_definition_id { get; set; }
        public int cohort_definition_id { get; set; }
        public DateTime cohort_end_date { get; set; }
        public DateTime cohort_start_date { get; set; }
        public int subject_id { get; set; }
        public int? value_as_concept_id { get; set; }
        public decimal? value_as_number { get; set; }
    }
}
