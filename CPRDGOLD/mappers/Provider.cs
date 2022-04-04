using CPRDGOLD.loaders;
using CPRDGOLD.models;
using DBMS;
using System.Linq;

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

        protected override void LoadData(dynamic refSource = null)
        {
            StaffLoader.Init();
            string[] cols = new string[] { "provider_id", "specialty_concept_id", "care_site_id", "gender_concept_id", "provider_source_value", "specialty_source_value", "gender_source_value", };
            var items = StaffLoader.GetData().Select(staff =>
            {
                SourceToConceptMap sconcept;
                Lookup lu;
                if (null == (lu = LookupLoader.ByCodeType(staff.role == 0 ? null : staff.role.ToString(), 76)) ||
                null == (sconcept = SourceToConceptMapLoader.BySourceCode(staff.role == 0 ? null : staff.role.ToString()))) return null;
                return new Provider
                {
                    provider_id = staff.staffid,
                    specialty_concept_id = sconcept.source_concept_id,
                    care_site_id = staff.care_site_id,
                    gender_concept_id = staff.gender_concept_id,
                    provider_source_value = staff.staffid.ToString(),
                    specialty_source_value = lu.text,
                    gender_source_value = staff.gender.ToString(),
                };
            }).Where(pr => null != pr);
            if (!items.Any()) return;
            DB.Target.CopyBinaryRows<Provider>(cols, (row, write) =>
            {
                foreach (var item in items)
                {
                    row();
                    write(item.provider_id);
                    write(item.specialty_concept_id);
                    write(item.care_site_id);
                    write(item.gender_concept_id);
                    write(item.provider_source_value);
                    write(item.specialty_source_value);
                    write(item.gender_source_value);
                }
            });
        }
    }
}
