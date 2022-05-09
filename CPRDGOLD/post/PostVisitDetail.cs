using DBMS;
using Util;

namespace CPRDGOLD.post
{
    internal class PostVisitDetail : PostRunner
    {
        public override void Implement()=> FileQuery.ExecuteFile(Script.ForCPRDGOLD<PostVisitDetail>());
    }
}
