using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    internal class SimpleCRUDResolver : SimpleCRUD.ITableNameResolver, SimpleCRUD.IColumnNameResolver
    {
        public string ResolveTableName(Type type)
        {
            return type.Name.ToLower();// string.Format("tbl_{0}", type.Name);
        }

        public string ResolveColumnName(PropertyInfo propertyInfo)
        {
            return propertyInfo.Name.ToLower();// string.Format("{0}_{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name);
        }
    }
}

