using DBMS;
using Util;

namespace CPRDGOLD.setups
{
    internal class DaySupplyModeSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-daysupply-modes.sql"));

        public override void Run() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("daysupply-modes.sql"));
    }
}
