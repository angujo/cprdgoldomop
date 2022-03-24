using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    public class Lookup
    {
        public short code { get; set; }
        public long lookup_id { get; set; }
        public long lookup_type_id { get; set; }
        public string text { get; set; }
        public string name { get; set; }
    }
}
