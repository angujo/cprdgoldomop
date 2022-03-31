using System;

namespace CPRDGOLD.mappers
{
    internal class CohortDefinition : Mapper<CohortDefinition>
    {
        public string cohort_definition_description { get; set; }
        public int cohort_definition_id { get; set; }
        public string cohort_definition_name { get; set; }
        public string cohort_definition_syntax { get; set; }
        public DateTime cohort_initiation_date { get; set; }
        public int? definition_type_concept_id { get; set; }
        public int? subject_concept_id { get; set; }

        protected override void LoadData()
        {
            Add(new CohortDefinition
            {
                cohort_definition_id = 224,
                cohort_definition_name = "HES Patients",
                cohort_definition_description = "Patients participating in Hospital Episodes Statistics (HES) linkage",
                cohort_initiation_date = DateTime.Now,
            });
        }
    }
}
