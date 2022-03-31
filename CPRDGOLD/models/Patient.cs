using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Patient
    {
        public short accept { get; set; }
        public int? capsup { get; set; }
        public DateTime chsdate { get; set; }
        public short chsreg { get; set; }
        public DateTime crd { get; set; }
        public DateTime deathdate { get; set; }
        public long famnum { get; set; }
        public DateTime frd { get; set; }
        public short gender { get; set; }
        public long id { get; set; }
        public int? Internal { get; set; }
        public short marital { get; set; }
        public short mob { get; set; }
        public long patid { get; set; }
        public long care_site_id { get { return patid.ToString().Length > 5 && long.TryParse(patid.ToString().Substring(patid.ToString().Length - 5), out long csid) ? csid : default; } }
        public int? pracid { get; set; }
        public int? prescr { get; set; }
        public int? reggap { get; set; }
        public int? regstat { get; set; }
        public DateTime tod { get; set; }
        public short toreason { get; set; }
        public long vmid { get; set; }
        public short yob { get; set; }
        public DateTime? op_start_date { get; set; }
        public DateTime? op_end_date { get; set; }
        public int pt_concept_id { get; set; }
    }
}
