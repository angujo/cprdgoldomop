using CPRDGOLD.loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Person : Mapper<Person>
    {
        public string birth_datetime { get; set; }
        public long care_site_id { get; set; }
        public string day_of_birth { get; set; }
        public int ethnicity_concept_id { get; set; }
        public int? ethnicity_source_concept_id { get; set; }
        public string ethnicity_source_value { get; set; }
        public int gender_concept_id { get; set; }
        public int? gender_source_concept_id { get; set; }
        public short gender_source_value { get; set; }
        public string location_id { get; set; }
        public short month_of_birth { get; set; }
        public long person_id { get; set; }
        public long person_source_value { get; set; }
        public string provider_id { get; set; }
        public int race_concept_id { get; set; }
        public int? race_source_concept_id { get; set; }
        public string race_source_value { get; set; }
        public int year_of_birth { get; set; }

        protected override void LoadData()
        {
            ActivePatientLoader.LoopAll(patient =>
            {
                Add(new Person
                {
                    person_id = patient.patid,
                    gender_concept_id = 1 == patient.gender ? 8507 : 8532,
                    year_of_birth = patient.yob.ToString().Length < 4 ? patient.yob + 1800 : patient.yob,
                    month_of_birth = patient.mob,
                    race_concept_id = 0,
                    ethnicity_concept_id = 0,
                    care_site_id = long.TryParse(patient.patid.ToString().Substring(patient.patid.ToString().Length - 5), out long csid) ? csid : default,
                    person_source_value=patient.patid,
                    gender_source_value = patient.gender,
                    gender_source_concept_id=0,
                    race_source_concept_id=0,
                    ethnicity_source_concept_id=0,
                });
            });
        }
    }
}
