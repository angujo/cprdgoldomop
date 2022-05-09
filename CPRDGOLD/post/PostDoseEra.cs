using DBMS;
using Util;

namespace CPRDGOLD.post
{
    internal class PostDoseEra : PostRunner
    {
        public override void Implement() => FileQuery.ExecuteFile(Script.ForCPRDGOLD<PostDoseEra>());
    }
}
