using CPRDGOLD.loaders;
using CPRDGOLD.models;

namespace CPRDGOLD.mappers
{
    internal class Provider : Mapper<Provider>
    {
        public long care_site_id { get; set; }
        public string dea { get; set; }
        public int? gender_concept_id { get; set; }
        public int? gender_source_concept_id { get; set; }
        public string gender_source_value { get; set; }
        public string npi { get; set; }
        public long provider_id { get; set; }
        public string provider_name { get; set; }
        public string provider_source_value { get; set; }
        public int? specialty_concept_id { get; set; }
        public int? specialty_source_concept_id { get; set; }
        public string specialty_source_value { get; set; }
        public int? year_of_birth { get; set; }

        protected override void LoadData()
        {
            StaffLoader.LoopAll(staff =>
            {
                Lookup lu = LookupLoader.ByCodeType(staff.role == 0 ? null : staff.role.ToString(), 76);
                SourceToConceptMap sconcept = SourceToConceptMapLoader.BySourceCode(staff.role == 0 ? null : staff.role.ToString());
                if (null == lu) return;
                if (null == sconcept) return;
                Add(new Provider
                {
                    provider_id = staff.staffid,
                    specialty_concept_id = sconcept.source_concept_id,
                    care_site_id = staff.care_site_id,
                    gender_concept_id = staff.gender_concept_id,
                    provider_source_value = staff.staffid.ToString(),
                    specialty_source_value = lu.text,
                    gender_source_value = staff.gender.ToString(),
                });
            });
        }
    }
}
