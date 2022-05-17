using Dapper;
using System;
using Util;

namespace DBMS.models
{
    [Table("dbschema")]
    public class Dbschema : CRUDModel<Dbschema>
    {
        public long workloadid { get; set; }
        public int  port       { get; set; }

        /*
         * Either source,target,vocabulary
         */
        public string  schematype  { get; set; }
        public string  server      { get; set; }
        public string  dbname      { get; set; }
        public string  schemaname  { get; set; }
        public string  username    { get; set; }
        public string  password    { get; set; }
        public Boolean testsuccess { get; set; }

        public Dbschema()
        {
        }
    }
}