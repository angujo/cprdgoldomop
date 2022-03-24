using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Consultation
    {
        public int consid { get; set; }
        public short constype { get; set; }
        public long duration { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public long patid { get; set; }
        public long staffid { get; set; }
        public DateTime sysdate { get; set; }
    }
}
