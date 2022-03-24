using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Cohort
    {
        public int cohort_definition_id { get; set; }
        public DateTime cohort_end_date { get; set; }
        public DateTime cohort_start_date { get; set; }
        public int subject_id { get; set; }
    }
}
