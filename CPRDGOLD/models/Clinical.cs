using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Clinical
    {
        public int adid { get; set; }
        public int consid { get; set; }
        public short constype { get; set; }
        public int? enttype { get; set; }
        public int? episode { get; set; }
        public DateTime eventdate { get; set; }
        public long id { get; set; }
        public long medcode { get; set; }
        public long patid { get; set; }
        public string sctdescid { get; set; }
        public string sctexpression { get; set; }
        public string sctid { get; set; }
        public bool? sctisassured { get; set; }
        public bool? sctisindicative { get; set; }
        public short sctmaptype { get; set; }
        public int? sctmapversion { get; set; }
        public long staffid { get; set; }
        public DateTime sysdate { get; set; }
        public string med_read_code { get; set; }
        public int? st_source_concept_id { get; set; }
        public int? ss_source_concept_id { get; set; }
    }
}
