using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Location
    {
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public long location_id { get; set; }
        public string location_source_value { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }
}
