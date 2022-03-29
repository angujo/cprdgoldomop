using CPRDGOLD.loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class ObservationPeriod : Mapper<ObservationPeriod>
    {
        public DateTime? observation_period_end_date { get; set; }
        public long observation_period_id { get; set; }
        public DateTime? observation_period_start_date { get; set; }
        public int period_type_concept_id { get; set; }
        public long person_id { get; set; }

        protected override void LoadData()
        {
            PatientLoader.LoopAll(patient =>
            {
                Add(new ObservationPeriod
                {
                    person_id = patient.patid,
                    observation_period_end_date = (DateTime)(null == patient.op_end_date ? null : patient.op_end_date),
                    observation_period_start_date = (DateTime)(null == patient.op_start_date ? null : patient.op_start_date),
                    period_type_concept_id = patient.pt_concept_id,
                });
            });
        }
    }
}
