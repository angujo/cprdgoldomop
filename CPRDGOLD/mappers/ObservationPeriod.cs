using CPRDGOLD.loaders;
using DBMS;
using System;
using Util;

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
            PatientLoader.Init(chunk);

            string[] cols = { "person_id", "observation_period_end_date", "observation_period_start_date", "period_type_concept_id" };
            DB.Target.CopyBinaryRows<ObservationPeriod>(cols, (row, write) =>
            {
                PatientLoader.LoopAll(chunk, patient =>
                 {
                     row();
                     write(patient.patid);
                     write((DateTime)(null == patient.op_end_date ? null : patient.op_end_date));
                     write((DateTime)(null == patient.op_start_date ? null : patient.op_start_date));
                     write(patient.pt_concept_id);
                 });
            });
        }
    }
}
