using System;

namespace CPRDGOLD.mergers
{
    internal class TestInt
    {
        public int?     consid       { get; set; }
        public short    data_fields  { get; set; }
        public int?     enttype      { get; set; }
        public string   enttype_desc { get; set; }
        public DateTime eventdate    { get; set; }
        public string   map_value    { get; set; }
        public long     medcode      { get; set; }
        public string   Operator     { get; set; }

        public int OperatorConceptId
        {
            get
            {
                switch (Operator)
                {
                    case "<=": return 4171754;
                    case ">=": return 4171755;
                    case "<": return 4171756;
                    case "=": return 4172703;
                    case ">": return 4172704;
                }

                return default;
            }
        }

        public long   patid                { get; set; }
        public string range_high           { get; set; }
        public string range_low            { get; set; }
        public string read_code            { get; set; }
        public string read_description     { get; set; }
        public long   staffid              { get; set; }
        public string unit                 { get; set; }
        public string value_as_concept_id  { get; set; }
        public string value_as_number      { get; set; }
        public int?   st_source_concept_id { get; set; }
        public int?   ss_source_concept_id { get; set; }
        public int?   st_target_concept_id { get; set; }
        public int?   ss_target_concept_id { get; set; }
        public string conc_domain_id       { get; set; }
        public long   chunk_identifier     { get; set; }
    }
}