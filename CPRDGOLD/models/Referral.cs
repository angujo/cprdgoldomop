using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Referral
    {
        public short attendance { get; set; }
        public int consid { get; set; }
        public int? constype { get; set; }
        public DateTime eventdate { get; set; }
        public int? fhsaspec { get; set; }
        public long id { get; set; }
        public short inpatient { get; set; }
        public long medcode { get; set; }
        public int? nhsspec { get; set; }
        public long patid { get; set; }
        public string sctdescid { get; set; }
        public string sctexpression { get; set; }
        public string sctid { get; set; }
        public bool? sctisassured { get; set; }
        public bool? sctisindicative { get; set; }
        public short sctmaptype { get; set; }
        public int? sctmapversion { get; set; }
        public int? source { get; set; }
        public long staffid { get; set; }
        public DateTime sysdate { get; set; }
        public short urgency { get; set; }
        public string med_read_code { get; set; }
        public int? st_source_concept_id { get; set; }
        public int? ss_source_concept_id { get; set; }
    }
}
