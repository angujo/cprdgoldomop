﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Death
    {
        public int? cause_concept_id { get; set; }
        public int? cause_source_concept_id { get; set; }
        public string cause_source_value { get; set; }
        public DateTime death_date { get; set; }
        public DateTime? death_datetime { get; set; }
        public int death_type_concept_id { get; set; }
        public long person_id { get; set; }
    }
}
