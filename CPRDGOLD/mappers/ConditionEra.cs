using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class ConditionEra
    {
        public int condition_concept_id { get; set; }
        public DateTime condition_era_end_date { get; set; }
        public long condition_era_id { get; set; }
        public DateTime condition_era_start_date { get; set; }
        public int? condition_occurrence_count { get; set; }
        public long person_id { get; set; }
    }
}
