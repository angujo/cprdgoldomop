using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mergers
{
    internal class AddIn 
    {
        public string category { get; set; }
        public int? consid { get; set; }
        public short constype { get; set; }
        public string data { get; set; }
        public short data_fields { get; set; }
        public string description { get; set; }
        public int? enttype { get; set; }
        public DateTime eventdate { get; set; }
        public string gemscript_description { get; set; }
        public long patid { get; set; }
        public string qualifier_source_value { get; set; }
        public string read_code_description { get; set; }
        public string source_value { get; set; }
        public long staffid { get; set; }
        public string unit_source_value { get; set; }
        public string value_as_date { get; set; }
        public string value_as_number { get; set; }
        public string value_as_string { get; set; }
        public int? st_source_concept_id { get; set; }

    }
}
