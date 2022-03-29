using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.setups
{
    internal class DaySupplyDecodeSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-daysupply-decodes.sql"));

        public override void Run() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("daysupply-decodes.sql"));
    }
}
