using CPRDGOLD.loaders;
using DBMS;
using System;
using Util;

namespace CPRDGOLD.mappers
{
    internal class Death : Mapper<Death>
    {
        public int? cause_concept_id { get; set; }
        public int? cause_source_concept_id { get; set; }
        public string cause_source_value { get; set; }
        public DateTime death_date { get; set; }
        public DateTime? death_datetime { get; set; }
        public int death_type_concept_id { get; set; }
        public long person_id { get; set; }

        // public void QueryInsert() => DBMS.FileQuery.ExecuteFile(Script.ForCPRDGOLD<Death>(), new string[][] { new string[] { @"{ch}", chunk.ordinal.ToString() } });

        protected override void LoadData(dynamic dSource = null)
        {
            string[] cols = new string[] { "person_id", "death_date", "death_datetime", "death_type_concept_id", "cause_concept_id", "cause_source_value", "cause_source_concept_id", };
            DB.Target.CopyBinaryRows<Death>(cols, (row, write) =>
            {
                chunk.GetLoader<ActivePatientLoader>(DBMS.models.ChunkLoadType.ACTIVE_PATIENT).LoopAllData(patient =>
                {
                    if ((null == patient.deathdate || patient.deathdate == default(DateTime)) && (null == patient.tod || default(DateTime) == patient.tod)) return;

                    row();
                    //person_id
                    write(patient.patid);
                    //death_date
                    write(null == patient.deathdate || patient.deathdate == default ? patient.tod : patient.deathdate);
                    //death_datetime
                    write(null == patient.deathdate || patient.deathdate == default ? patient.tod : patient.deathdate);
                    //death_type_concept_id
                    write(32815);
                    //cause_concept_id
                    write(0);
                    //cause_source_value
                    write("0");
                    //cause_source_concept
                    write(0);
                });
            });
        }
    }
}
