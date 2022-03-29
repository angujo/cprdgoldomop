using DBMS;
using DBMS.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.setups
{
    internal class ChunkSetup : AbsSetup
    {
        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public void ChunkLoad(long chunkSize)
        {
            string from = @"COPY (select row_number() over(order by patid) rid, patid  from {ss}.patient p) TO STDOUT (FORMAT BINARY)".RemovePlaceholders();
            string to = @"COPY {ss}._chunk (ordinal, patient_id) FROM STDIN (FORMAT BINARY)".RemovePlaceholders();

            DB.Source.BinaryCopy(DB.Source, from, to);

            DB.Source.RunQuery("update {ss}._chunk set ordinal =q.ord from (select ceil((t.rid-1)/{lmt}) ord, t.patid  from (select row_number() over(order by p.patient_id) rid, patient_id patid from {ss}._chunk p) t) q where patient_id =q.patid "
                .RemovePlaceholders(new string[][] { new string[] { "{lmt}",chunkSize.ToString() } }));
        }
    }
}
