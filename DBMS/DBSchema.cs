using System;

namespace DBMS
{
    public class DBSchema
    {
        public int Port { get; set; }
        public string Server { get; set; }
        public string DBName { get; set; }
        public string SchemaName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
