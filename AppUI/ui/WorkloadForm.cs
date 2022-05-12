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

        public WorkloadForm()
        {
            InitializeComponent();
            if (null == _workLoad)
            {
                _workLoad = new WorkLoad
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
            }
            DetailsTab();
        }

        public WorkloadForm(WorkLoad workLoad) : this()
        {
            _workLoad = workLoad;
        }

        private void DetailsTab()
        {
            Log.Console.Info("Am a button that has been clicked!");
            _uiWorkLoad = new UIWorkLoad(_workLoad);
            tbWlName.DataBindings.Add("Text", _uiWorkLoad, "Name");
            dtWlDate.DataBindings.Add("Value", _uiWorkLoad, "ReleaseDate");
        }
    }
}