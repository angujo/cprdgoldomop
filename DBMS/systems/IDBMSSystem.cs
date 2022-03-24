using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
