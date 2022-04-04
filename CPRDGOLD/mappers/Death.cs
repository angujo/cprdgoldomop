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

        public void QueryInsert() => DBMS.FileQuery.ExecuteFile(Script.ForCPRDGOLD<Death>(), new string[][] { new string[] { @"{ch}", chunk.ordinal.ToString() } });

        protected override void LoadData(dynamic dSource = null)
        {
            throw new NotImplementedException();
        }
    }
}
