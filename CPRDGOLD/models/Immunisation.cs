using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Immunisation
    {
        public long batch { get; set; }
        public long compound { get; set; }
        public int consid { get; set; }
        public int? constype { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public long immstype { get; set; }
        public long medcode { get; set; }
        public long method { get; set; }
        public long patid { get; set; }
        public long reason { get; set; }
        public string sctdescid { get; set; }
        public string sctexpression { get; set; }
        public string sctid { get; set; }
        public bool? sctisassured { get; set; }
        public bool? sctisindicative { get; set; }
        public short sctmaptype { get; set; }
        public int? sctmapversion { get; set; }
        public long source { get; set; }
        public long staffid { get; set; }
        public long stage { get; set; }
        public long status { get; set; }
        public DateTime sysdate { get; set; }
    }
}
