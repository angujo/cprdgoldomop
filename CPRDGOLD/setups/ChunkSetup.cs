using DBMS;
using System;
using Util;

namespace CPRDGOLD.setups
{
    internal class ChunkSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("chunk-setup.sql"));

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
                .RemovePlaceholders(new string[][] { new string[] { "{lmt}", chunkSize.ToString() } }));
        }

        public void ChunkOrdinate(long workload_id)
        {
            DB.Internal.RunQuery($"DELETE FROM chunktimer WHERE workloadid = {workload_id}");

            string from = @"COPY (select ordinal, {wlid} AS workloadid  from {ss}._chunk p GROUP BY ordinal) TO STDOUT (FORMAT BINARY)"
                .RemovePlaceholders(new string[] { "{wlid}", $"{workload_id}" });
            string to = @"COPY chunktimer (chunkid, workloadid) FROM STDIN (FORMAT BINARY)".RemovePlaceholders();

            DB.Source.BinaryCopy(DB.Internal, from, to);
        }
    }
}
