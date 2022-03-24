using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class ObservationPeriod
    {
        public DateTime observation_period_end_date { get; set; }
        public long observation_period_id { get; set; }
        public DateTime observation_period_start_date { get; set; }
        public int period_type_concept_id { get; set; }
        public long person_id { get; set; }
    }
}
