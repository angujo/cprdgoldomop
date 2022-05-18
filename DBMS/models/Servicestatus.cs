using System;
using Dapper;
using Util;

namespace DBMS.models
{
    [Table("servicestatus")]
    public class Servicestatus
    {
        public long     id                 { get; set; }
        public string   servicename        { get; set; }
        public string   servicedescription { get; set; }
        public Status   status             { get; set; }
        public DateTime lastrun            { get; set; }
    }
}