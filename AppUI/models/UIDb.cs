using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DBMS;
using DBMS.models;
using Util;
using SchemaType = DBMS.SchemaType;

namespace AppUI.models
{
    public class UIDb : UIModel
    {
        private Dictionary<string, Dbschema> _schemata = new Dictionary<string, Dbschema>();
        private SchemaType[] _schemaTypes = {SchemaType.SOURCE, SchemaType.TARGET, SchemaType.VOCABULARY};
        private long workloadId;

        public UIDb(long workloadId)
        {
            this.workloadId = workloadId;
            var ss = DB.Internal.GetAll<Dbschema>("WHERE workloadid = @wlid", new {wlid = workloadId});
            foreach (var schema in ss)
            {
                if (!_schemaTypes.Select(st => st.GetStringValue()).Contains(schema.schematype)) continue;
                _schemata.Add(schema.schematype, schema);
            }
        }

        public Dbschema GetSchema(SchemaType type) =>
            _schemata.TryGetValue(type.GetStringValue(), out var sc)
                ? sc
                : new Dbschema {workloadid = workloadId, testsuccess = false, schematype = type.GetStringValue()};

        public Dbschema[] GetSchemas() => _schemata.Select(kv => kv.Value).ToArray();

        public bool TestSchema(SchemaType type)
        {
            if(!(_schemata.TryGetValue(type.GetStringValue(), out var dbschema) && DB.FromDbSchema(dbschema).TestConnection()))
                throw new Exception("Invalid Connection parameters set! Connection Failed!");
            return true;
        }
    }
}