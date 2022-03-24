using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Therapy
    {
        public int bnfcode { get; set; }
        public int consid { get; set; }
        public string dosageid { get; set; }
        public string drugdmd { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public int? issueseq { get; set; }
        public int? numdays { get; set; }
        public decimal? numpacks { get; set; }
        public int? packtype { get; set; }
        public long patid { get; set; }
        public bool? prn { get; set; }
        public long prodcode { get; set; }
        public decimal? qty { get; set; }
        public long staffid { get; set; }
        public DateTime sysdate { get; set; }
    }
}
