using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppUI.models;
using AppUI.ui;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI
{
    public partial class MainForm : Form
    {
        private WorkloadForm  activeWorkload;
        private Servicestatus _serviceStatus;
        private UIService     _uiService;

        public MainForm()
        {
            InitializeComponent();
            _uiService = new UIService();
            loadWorkPlans();
            LoadService();
        }

        private void loadWorkPlans()
        {
            try
            {
                lvWorkplans.Items.Clear();
                var plans = DB.Internal.GetAll<WorkLoad>();
                Log.Info("Reloading the Workplans...");
                foreach (var workLoad in plans)
                {
                    var listViewItem = new ListViewItem(workLoad.Name);
                    listViewItem.SubItems.Add(workLoad.Releasedate.ToString("yy-MMM-dd ddd"));
                    listViewItem.SubItems.Add(workLoad.Isrunning ? "Running" : "Not Running");
                    listViewItem.Tag = workLoad;

                    lvWorkplans.Items.Add(listViewItem);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }

        private void LoadService()
        {
            _serviceStatus    = DB.Internal.Load<Servicestatus>();
            txtServName.Text  = Consts.SERVICE_NAME;
            txtServTick.Text  = TimeSpan.FromMilliseconds(Consts.SERVICE_TIMER).ToString();
            txtSrvStatus.Text = _uiService.Status<string>(); // _serviceStatus.status.GetStringValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            activeWorkload = new WorkloadForm();
            activeWorkload.Show();
            Hide();
            activeWorkload.Closed += (s, args) => this.Close();
        }

        private void lvWorkplans_DoubleClick(object sender, EventArgs e)
        {
            if (lvWorkplans.SelectedItems.Count <= 0) return;
            activeWorkload =
                new WorkloadForm(DB.Internal.Load<WorkLoad>(((WorkLoad) lvWorkplans.SelectedItems[0].Tag).Id));
            activeWorkload.parent = this;
            activeWorkload.Show();
            Hide();
            activeWorkload.Closed += (s, args) => this.Close();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadWorkPlans();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnServInstall_Click(object sender, EventArgs e)
        {
            (new ServiceInfoForm()).ShowDialog(this);
        }
    }
}