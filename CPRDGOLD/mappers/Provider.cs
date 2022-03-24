using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Provider
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
    }
}
