using System;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI.models
{
    public class UIDbSchema : UIModel
    {
        private UIDb _uiDb;

        private Dbschema target;
        private Dbschema source;
        private Dbschema vocabulary;

        public string user
        {
            get => target.username;
            set
            {
                target.username     = value;
                source.username     = value;
                vocabulary.username = value;
                PropagateChange();
            }
        }

        public string password
        {
            get => "";
            set
            {
                target.password     = EncryptionHelper.Encrypt(value);
                source.password     = EncryptionHelper.Encrypt(value);
                vocabulary.password = EncryptionHelper.Encrypt(value);
                PropagateChange();
            }
        }

        public string server
        {
            get => target.server;
            set
            {
                target.server     = value;
                source.server     = value;
                vocabulary.server = value;
                PropagateChange();
            }
        }

        public string dbname
        {
            get => target.dbname;
            set
            {
                target.dbname     = value;
                source.dbname     = value;
                vocabulary.dbname = value;
                PropagateChange();
            }
        }

        public int portnumber
        {
            get => target.port;
            set
            {
                target.port     = value;
                source.port     = value;
                vocabulary.port = value;
                PropagateChange();
            }
        }

        public string target_schemaname
        {
            get => target.schemaname;
            set
            {
                target.schemaname = value;
                PropagateChange();
            }
        }

        public string source_schemaname
        {
            get => source.schemaname;
            set
            {
                source.schemaname = value;
                PropagateChange();
            }
        }

        public string vocab_schemaname
        {
            get => vocabulary.schemaname;
            set
            {
                vocabulary.schemaname = value;
                PropagateChange();
            }
        }

        public bool vocab_test
        {
            get => vocabulary.testsuccess;
            set
            {
                vocabulary.testsuccess = value;
                PropagateChange();
            }
        }

        public bool target_test
        {
            get => target.testsuccess;
            set
            {
                target.testsuccess = value;
                PropagateChange();
            }
        }

        public bool source_test
        {
            get => source.testsuccess;
            set
            {
                source.testsuccess = value;
                PropagateChange();
            }
        }

        public UIDbSchema(long workload_id)
        {
            _uiDb = new UIDb(workload_id);
            loadSchemas();
            SetBouncer(Save);
        }

        private void loadSchemas()
        {
            target     = _uiDb.GetSchema(SchemaType.TARGET);
            source     = _uiDb.GetSchema(SchemaType.SOURCE);
            vocabulary = _uiDb.GetSchema(SchemaType.VOCABULARY);
        }

        public void Save()
        {
            target.Save();
            source.Save();
            vocabulary.Save();
        }

        public void TestTarget()
        {
            try
            {
                target_test = _uiDb.TestSchema(SchemaType.TARGET);
            }
            catch (Exception e)
            {
                target.testsuccess = false;
                target.Save();
                throw;
            }
        }

        public void TestSource()
        {
            try
            {
                source_test = _uiDb.TestSchema(SchemaType.SOURCE);
            }
            catch (Exception e)
            {
                source.testsuccess = false;
                source.Save();
                throw;
            }
        }

        public void TestVocabulary()
        {
            try
            {
                vocab_test = _uiDb.TestSchema(SchemaType.VOCABULARY);
            }
            catch (Exception e)
            {
                vocabulary.testsuccess = false;
                vocabulary.Save();
                throw;
            }
        }
    }
}