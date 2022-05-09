using Dapper;
using System;
using Util;

namespace DBMS.models
{
    [Table("dbschema")]
    public class DbSchema : CRUDModel<DbSchema>
    {
        private string _password;

        public long id         { get; set; }
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
            get => EncryptionHelper.Encrypt(_password);
            set => _password = EncryptionHelper.Decrypt(value);
        }

        public string testsuccess { get; set; }

        public DbSchema()
        {
        }
    }
}