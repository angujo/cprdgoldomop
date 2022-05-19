using System;
using Dapper;
using Util;

namespace DBMS.models
{
    [Table("servicestatus")]
    public class Servicestatus
    {
        public long id { get; set; }

        public string servicename
        {
            get => Consts.SERVICE_NAME;
            set { }
        }

        public string servicedescription
        {
            get => "A service to run source file mapping and OMOP CDM transformation from source files.";
            set { }
        }

        public Status   status  { get; set; }
        public DateTime lastrun { get; set; }
    }
}