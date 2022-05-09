using DBMS;
using Util;

namespace CPRDGOLD.post
{
    internal class PostConditionEra : PostRunner
    {
        public override void Implement() => FileQuery.ExecuteFile(Script.ForCPRDGOLD("condition-era.sql"));
    }
}
