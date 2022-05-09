using System.Collections.Generic;
using System.Data;
using System.Linq;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI.models
{
    public class UIDb
    {
        private Dictionary<string, DbSchema> _schemata = new Dictionary<string, DbSchema>();
        private DbSchemaType[] _schemaTypes = {DbSchemaType.SOURCE, DbSchemaType.TARGET, DbSchemaType.VOCABULARY};

        public UIDb(long workload_id)
        {
            var ss = DB.Internal.GetAll<DbSchema>("WHERE workloadid = @wlid", new {wlid = workload_id});
            foreach (var schema in ss)
            {
                if (!_schemaTypes.Select(st => st.GetStringValue()).Contains(schema.schematype)) continue;
                _schemata.Add(schema.schematype, schema);
            }
        }

        public DbSchema GetSchema(DbSchemaType type) =>
            _schemata.TryGetValue(type.GetStringValue(), out var sc) ? sc : new DbSchema();

        public DbSchema[] GetSchemas() => _schemata.Select(kv => kv.Value).ToArray();
    }
}