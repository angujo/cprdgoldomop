using DBMS;
using System;

namespace CPRDGOLD.mappers
{
    internal class CdmSource : Mapper<CdmSource>
    {
        public string cdm_etl_reference { get; set; }
        public string cdm_holder { get; set; }
        public DateTime cdm_release_date { get; set; }
        public string cdm_source_abbreviation { get; set; }
        public string cdm_source_name { get; set; }
        public string cdm_version { get; set; }
        public string source_description { get; set; }
        public string source_documentation_reference { get; set; }
        public DateTime source_release_date { get; set; }
        public string vocabulary_version { get; set; }

        protected override void LoadData(dynamic refSource = null)
        {
            DB.Target.InsertPlain(new CdmSource
            {
                cdm_source_name = "Synthea synthetic health database",
                cdm_source_abbreviation = "Synthea",
                cdm_holder = "OHDSI Community",
                source_description = "SyntheaTM is a Synthetic Patient Population Simulator. The goal is to output synthetic, realistic (but not real), patient data and associated health records in a variety of formats.",
                source_documentation_reference = "https://synthetichealth.github.io/synthea/",
                cdm_etl_reference = "https://github.com/OHDSI/ETL-Synthea",
                source_release_date = DateTime.Now,
                cdm_release_date = DateTime.Now,
                cdm_version = "v5.3",
                vocabulary_version = null,
            });
        }
    }
}
