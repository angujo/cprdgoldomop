using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    internal class Staff
    {
        public short gender { get; set; }
        public long id { get; set; }
        public short role { get; set; }
        public long staffid { get; set; }

        public long care_site_id { get { return staffid.ToString().Length>5 && long.TryParse(staffid.ToString().Substring(staffid.ToString().Length - 5), out long csid) ? csid : default; } }

        public int gender_concept_id { get { return 1 == gender ? 8507 : 2 == gender ? 8532 : 0; } }
    }
}
