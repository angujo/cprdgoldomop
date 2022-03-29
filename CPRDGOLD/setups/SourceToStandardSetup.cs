﻿using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.setups
{
    internal class SourceToStandardSetup : AbsSetup
    {
        public override void Create() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("create-source-to-standard.sql"));

        public override void Run()=>FileQuery.ExecuteFile(Script.ForCPRDGOLD("source-to-standard.sql"));
    }
}
