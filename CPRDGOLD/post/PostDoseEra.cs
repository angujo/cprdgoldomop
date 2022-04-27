using CPRDGOLD.mappers;
using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.post
{
    internal class PostDoseEra : PostRunner
    {
        public override void Implement() => FileQuery.ExecuteFile(Script.ForCPRDGOLD<PostDoseEra>());
    }
}
