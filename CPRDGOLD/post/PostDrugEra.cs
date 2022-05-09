using DBMS;
using Util;

namespace CPRDGOLD.post
{
    internal class PostDrugEra : PostRunner
    {
        public override void Implement() => FileQuery.ExecuteFile(Script.ForCPRDGOLD<PostDrugEra>());
    }
}
