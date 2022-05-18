using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public MainForm()
        {
            InitializeComponent();
            loadWorkPlans();
            LoadService();
        }

        private void loadWorkPlans()
        {
            lvWorkplans.Items.Clear();
            var plans = DB.Internal.GetAll<WorkLoad>();
            Log.Info("Reloading the Workplans...");
            foreach (var workLoad in plans)
            {
                var listViewItem = new ListViewItem(workLoad.Name);
                listViewItem.SubItems.Add(workLoad.ReleaseDate.ToString("yy-MMM-dd ddd"));
                listViewItem.SubItems.Add(workLoad.IsRunning ? "Running" : "Not Running");
                listViewItem.Tag = workLoad;

                lvWorkplans.Items.Add(listViewItem);
            }
        }

        private void LoadService()
        {
            _serviceStatus    = DB.Internal.Load<Servicestatus>();
            txtServName.Text  = _serviceStatus.servicename;
            txtSrvStatus.Text = _serviceStatus.status.GetStringValue();
            txtServLast.Text  = _serviceStatus.lastrun.ToString("R");
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
    }
}