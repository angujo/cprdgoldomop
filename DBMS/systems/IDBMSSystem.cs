using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;

namespace DBMS.systems
{
    internal interface IDBMSSystem
    {
        QueryFactory QueryFactory();
        string ConnectionString();
        IDbConnection GetConnection();
        Compiler GetCompiler();
    }
}
