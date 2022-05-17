using Dapper;
using System;
using System.Reflection;
using Util;

namespace DBMS
{
    internal class SimpleCRUDResolver : SimpleCRUD.ITableNameResolver, SimpleCRUD.IColumnNameResolver
    {
        public string ResolveTableName(Type type)
        {
            return type.Name.ToSnakeCase(); // string.Format("tbl_{0}", type.Name);
        }

        public string ResolveColumnName(PropertyInfo propertyInfo)
        {
            return propertyInfo.Name.ToSnakeCase();
            // string.Format("{0}_{1}", propertyInfo.DeclaringType.Name, propertyInfo.Name);
        }
    }
}