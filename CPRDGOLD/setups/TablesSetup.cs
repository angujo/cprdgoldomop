using DBMS;
using Util;

namespace CPRDGOLD.setups
{
    internal class TablesSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-tables.sql"));

        public override void Run() { }
    }
}
