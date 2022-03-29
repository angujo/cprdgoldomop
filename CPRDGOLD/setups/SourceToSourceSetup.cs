using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.setups
{
    internal class SourceToSourceSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-source-to-source.sql"));

        public override void Run() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("source-to-source.sql"));
    }
}
