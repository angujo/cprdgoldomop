using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.models
{
    public class DaySupplyDecode
    {
        public decimal? daily_dose { get; set; }
        public long id { get; set; }
        public short numdays { get; set; }
        public int? numpacks { get; set; }
        public int prodcode { get; set; }
        public decimal? qty { get; set; }
    }
}
