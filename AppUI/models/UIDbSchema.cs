using DBMS.models;
using Util;

namespace AppUI.models
{
    public class UIDbSchema
    {
        private UIDb _uiDb;

        private DbSchema target;
        private DbSchema source;
        private DbSchema vocabulary;

        public string user
        {
            get => target.username;
            set => target.username = value;
        }

        public string password
        {
            set
            {
                target.password     = value;
                source.password     = value;
                vocabulary.password = value;
            }
        }

        public string server
        {
            get => target.server;
            set => target.server = value;
        }

        public string dbname
        {
            get => target.dbname;
            set => target.dbname = value;
        }

        public string username
        {
            get => target.username;
            set => target.username = value;
        }

        public string target_schemaname
        {
            get => target.schemaname;
            set => target.schemaname = value;
        }

        public string source_schemaname
        {
            get => source.schemaname;
            set => source.schemaname = value;
        }

        public string vocab_schemaname
        {
            get => vocabulary.schemaname;
            set => vocabulary.schemaname = value;
        }

        public UIDbSchema(long workload_id)
        {
            _uiDb = new UIDb(workload_id);
            loadSchemas();
        }

        private void loadSchemas()
        {
            target     = _uiDb.GetSchema(DbSchemaType.TARGET);
            source     = _uiDb.GetSchema(DbSchemaType.SOURCE);
            vocabulary = _uiDb.GetSchema(DbSchemaType.VOCABULARY);
        }

        public void Save()
        {
            target.Save();
            source.Save();
            vocabulary.Save();
        }
    }
}