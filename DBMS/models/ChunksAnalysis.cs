using Dapper;

namespace DBMS.models
{
    [Table("chunks_analysis")]
    public class ChunksAnalysis
    {
        public long   workloadid { get; set; }
        public string descr      { get; set; }
        public long   value      { get; set; }
    }
}