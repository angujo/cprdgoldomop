using CPRDGOLD.loaders;
using DBMS;
using System;

namespace CPRDGOLD.mappers
{
    internal class Person : Mapper<Person>
    {
        public DateTime? birth_datetime { get; set; }
        public long care_site_id { get; set; }
        public string day_of_birth { get; set; }
        public int ethnicity_concept_id { get; set; }
        public int? ethnicity_source_concept_id { get; set; }
        public string ethnicity_source_value { get; set; }
        public int gender_concept_id { get; set; }
        public int? gender_source_concept_id { get; set; }
        public string gender_source_value { get; set; }
        public string location_id { get; set; }
        public short month_of_birth { get; set; }
        public long person_id { get; set; }
        public string person_source_value { get; set; }
        public string provider_id { get; set; }
        public int race_concept_id { get; set; }
        public int? race_source_concept_id { get; set; }
        public string race_source_value { get; set; }
        public int year_of_birth { get; set; }

        public Person() { birth_datetime = default(DateTime); }

        protected override void LoadData(dynamic dSource = null)
        {
            string[] cols = new string[] { "person_id", "gender_concept_id", "year_of_birth", "month_of_birth", "race_concept_id", "ethnicity_concept_id", "care_site_id",
                "person_source_value", "gender_source_value", "gender_source_concept_id", "race_source_concept_id", "ethnicity_source_concept_id" };
            DB.Target.CopyBinaryRows<Person>(cols, (row, write) =>
           {
               chunk.GetLoader<ActivePatientLoader>(DBMS.models.ChunkLoadType.ACTIVE_PATIENT).LoopAllData(patient =>
                {
                    row();
                    write(patient.patid);
                    write(1 == patient.gender ? 8507 : 8532);
                    write(patient.year_of_birth);
                    write(patient.mob);
                    write(0);
                    write(0);
                    write(patient.care_site_id);
                    write(patient.patid.ToString());
                    write(patient.gender.ToString());
                    write(0);
                    write(0);
                    write(0);
                });
           });
        }
    }
}
