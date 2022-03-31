using DBMS;
using Util;

namespace CPRDGOLD.setups
{
    internal class DaySupplyDecodeSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-daysupply-decodes.sql"));

        public override void Run() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("daysupply-decodes.sql"));
    }
}
