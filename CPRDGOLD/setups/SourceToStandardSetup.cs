using DBMS;
using Util;

namespace CPRDGOLD.setups
{
    internal class SourceToStandardSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-source-to-standard.sql"));

        public override void Run()=>FileQuery.ExecuteFile(Script.ForCPRDGOLD("source-to-standard.sql"));
    }
}
