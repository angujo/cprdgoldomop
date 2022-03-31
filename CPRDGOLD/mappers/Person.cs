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

        protected override void LoadData()
        {
            // PropertyInfo[] props = typeof(Person).GetProperties();
            string[] cols = new string[] { "person_id", "gender_concept_id", "year_of_birth", "month_of_birth", "race_concept_id", "ethnicity_concept_id", "care_site_id",
                "person_source_value", "gender_source_value", "gender_source_concept_id", "race_source_concept_id", "ethnicity_source_concept_id" };

            // Log.Info(string.Join("\t", props.Select(pi => pi.Name)));
            DB.Target.CopyBinaryRows("person", cols, (row, write) =>
            {

                ActivePatientLoader.LoopAll(chunk, patient =>
                      {
                          row();
                          write(patient.patid);
                          write(1 == patient.gender ? 8507 : 8532);
                          write(patient.yob.ToString().Length < 4 ? patient.yob + 1800 : patient.yob);
                          write(patient.mob);
                          write(0);
                          write(0);
                          write(patient.care_site_id);
                          write(patient.patid.ToString());
                          write(patient.gender.ToString());
                          write(0);
                          write(0);
                          write(0);

                          #region Works
                          /*  DB.Target.CopyText("person",cols,writer => {
                              writer.Write(patient.patid);
                              writer.Write(Delimiter);
                              writer.Write(1 == patient.gender ? 8507 : 8532);
                              writer.Write(Delimiter);
                              writer.Write(patient.yob.ToString().Length < 4 ? patient.yob + 1800 : patient.yob);
                              writer.Write(Delimiter);
                              writer.Write(patient.mob);
                              writer.Write(Delimiter);
                              writer.Write(0);
                              writer.Write(Delimiter);
                              writer.Write(0);
                              writer.Write(Delimiter);
                              writer.Write(patient.care_site_id);
                              writer.Write(Delimiter);
                              writer.Write(patient.patid);
                              writer.Write(Delimiter);
                              writer.Write(patient.gender);
                              writer.Write(Delimiter);
                              writer.Write(0);
                              writer.Write(Delimiter);
                              writer.Write(0);
                              writer.Write(Delimiter);
                              writer.Write(0);
                              writer.WriteLine();
                          });
                        Person p = new Person
                          {
                              person_id = patient.patid,
                              gender_concept_id = 1 == patient.gender ? 8507 : 8532,
                              year_of_birth = patient.yob.ToString().Length < 4 ? patient.yob + 1800 : patient.yob,
                              month_of_birth = patient.mob,
                              race_concept_id = 0,
                              ethnicity_concept_id = 0,
                              care_site_id = patient.care_site_id,
                              person_source_value = patient.patid,
                              gender_source_value = patient.gender,
                              gender_source_concept_id = 0,
                              race_source_concept_id = 0,
                              ethnicity_source_concept_id = 0,
                          };
                          DB.Target.CopyInsert<Person>(writer =>
                          {
                              var row = string.Join("\t", props.Select(pi => pi.GetValue(p, null)));
                              Log.Info(row);
                              writer.WriteLine(row);
                          });*/
                          //  Add();
                          #endregion
                      });
            });
        }
    }
}
