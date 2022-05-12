using System;
using System.Windows.Forms;
using AppUI.models;
using DBMS.models;
using Util;

namespace AppUI.ui
{
    public partial class WorkloadForm : Form
    {
        private WorkLoad   _workLoad;
        private UIWorkLoad _uiWorkLoad;
        private UIDbSchema _uiDbSchema;
        public  Form       parent;

        public WorkloadForm() : this(null)
        {
        }

        public WorkloadForm(WorkLoad workLoad)
        {
            InitializeComponent();
            _workLoad = workLoad ?? new WorkLoad
            {
                Name            = Guid.NewGuid().ToString(),
                FilesLocked     = false,
                SourceProcessed = false,
                CdmLoaded       = false,
                ChunksSetup     = false,
                ChunksLoaded    = false,
                CdmProcessed    = false,
                IsRunning       = false,
                MaxParallels    = 3,
            };

            DetailsTab();
        }

        private void DetailsTab()
        {
            _uiWorkLoad = new UIWorkLoad(_workLoad);
            tbWlName.DataBindings.Clear();
            dtWlDate.DataBindings.Clear();

            tbWlName.DataBindings.Add("Text", _uiWorkLoad, "Name");
            dtWlDate.DataBindings.Add("Value", _uiWorkLoad, "ReleaseDate");
        }

        private void SchemaTab()
        {
            _uiDbSchema = new UIDbSchema(_workLoad.Id);
            scServer.DataBindings.Clear();
            scDb.DataBindings.Clear();
            scUsername.DataBindings.Clear();
            scPort.DataBindings.Clear();
            scPassword.DataBindings.Clear();
            scTarget.DataBindings.Clear();
            scSource.DataBindings.Clear();
            scVocabulary.DataBindings.Clear();

            scServer.DataBindings.Add("Text", _uiDbSchema, "server");
            scDb.DataBindings.Add("Text", _uiDbSchema, "dbname");
            scUsername.DataBindings.Add("Text", _uiDbSchema, "user");
            scPort.DataBindings.Add("Text", _uiDbSchema, "portnumber");
            scPassword.DataBindings.Add("Text", _uiDbSchema, "password");
            scTarget.DataBindings.Add("Text", _uiDbSchema, "target_schemaname");
            scSource.DataBindings.Add("Text", _uiDbSchema, "source_schemaname");
            scVocabulary.DataBindings.Add("Text", _uiDbSchema, "vocab_schemaname");
        }

        private void AnalysisTab()
        {
            lvAnalysis.Items.Clear();
            UIAnalysis.LoadAnalysis(lv => lvAnalysis.Items.Add(lv));
        }

        private void ChunksTab()
        {
            var uic = new UIChunks();
            lvChunks.Items.Clear();
            uic.LoadChunks(lv => lvChunks.Items.Add(lv));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null == parent)
            {
                Close();
                return;
            }

            Hide();
            parent.Show();
        }

        private void tabWorkload_Selected(object sender, TabControlEventArgs e)
        {
            Log.Info("Tab Selected! {@Name}", e.TabPage.Name);
            switch (e.TabPage.Name.ToLower())
            {
                case "tabschema":
                    SchemaTab();
                    break;
                case "tabdetails":
                    DetailsTab();
                    break;
                case "tabprogress":
                    AnalysisTab();
                    break;
                case "tabchunks":
                    ChunksTab();
                    break;
            }
        }
    }
}