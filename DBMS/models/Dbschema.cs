using Dapper;
using System;
using Util;

namespace DBMS.models
{
    [Table("dbschema")]
    public class Dbschema : CRUDModel<Dbschema>
    {
        private string _password;
        public long workloadid { get; set; }
        public int  port       { get; set; }

        /*
         * Either source,target,vocabulary
         */
        public string schematype { get; set; }
        public string server     { get; set; }
        public string dbname     { get; set; }
        public string schemaname { get; set; }
        public string username   { get; set; }

        [Editable(false)]
        public string UIPassword
        {
            set => _password = value;
        }

        public string password
        {
            get => _password;
            set => _password = EncryptionHelper.Encrypt(value);
        }

        public Boolean testsuccess { get; set; }

        public Dbschema()
        {
        }
    }
}