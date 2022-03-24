﻿using CPRDGOLD.mergers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class ConditionOccurrence : Mapper<ConditionOccurrence>
    {
        public int condition_concept_id { get; set; }
        public DateTime condition_end_date { get; set; }
        public DateTime? condition_end_datetime { get; set; }
        public long condition_occurrence_id { get; set; }
        public int? condition_source_concept_id { get; set; }
        public string condition_source_value { get; set; }
        public DateTime condition_start_date { get; set; }
        public DateTime? condition_start_datetime { get; set; }
        public int? condition_status_concept_id { get; set; }
        public string condition_status_source_value { get; set; }
        public int condition_type_concept_id { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public string stop_reason { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }

        protected override void LoadData()
        {
            StemTableMerger.Prepare(chunk);

            StemTableMerger.LoopAll(chunk, stem =>
            {
                Add(new ConditionOccurrence
                {
                    provider_id = stem.provider_id,
                    visit_occurrence_id = stem.visit_occurrence_id,
                    condition_status_concept_id = null,
                    condition_occurrence_id = stem.id,
                    condition_source_value = stem.source_value,
                    person_id = stem.person_id,
                    condition_concept_id = (int)stem.concept_id,
                    condition_start_date = stem.start_date,
                    condition_source_concept_id = stem.source_concept_id,
                    condition_start_datetime = stem.start_datetime,
                    condition_end_date = DateTime.Parse(stem.end_date),
                    condition_end_datetime = DateTime.Parse(stem.end_date.ToString()),
                    condition_type_concept_id = (int)stem.type_concept_id,
                    stop_reason = null,
                });
            });
        }
    }
}
