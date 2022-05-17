using Dapper;

namespace DBMS.models
{
    [Table("status_view")]
    public class StatusView
    {
        public long   workloadid { get; set; }
        public string txt        { get; set; }
        public string code       { get; set; }
        public string value      { get; set; }
    }
}