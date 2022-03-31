using System;

namespace CPRDGOLD.mappers
{
    internal class Metadata
    {
        public int metadata_concept_id { get; set; }
        public DateTime metadata_date { get; set; }
        public DateTime? metadata_datetime { get; set; }
        public int metadata_type_concept_id { get; set; }
        public string name { get; set; }
        public int? value_as_concept_id { get; set; }
        public string value_as_string { get; set; }
    }
}
