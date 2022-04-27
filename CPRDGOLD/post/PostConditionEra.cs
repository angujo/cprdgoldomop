using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.post
{
    internal class PostConditionEra : PostRunner
    {
        public override void Implement() => DBMS.FileQuery.ExecuteFile(Script.ForCPRDGOLD("condition-era.sql"));
    }
}
