using System;
using System.IO;
using System.Windows.Forms;

namespace AppUI.ui
{
    public partial class ServiceInfoForm : Form
    {
        private static readonly string SERVICE_EXEC = "OMOPBuilderService.exe";

        private static string CmdInstall => $"cd {AppDomain.CurrentDomain.BaseDirectory} && {SERVICE_EXEC} install";

        private static string CmdUninstall => $"cd {AppDomain.CurrentDomain.BaseDirectory} && {SERVICE_EXEC} uninstall";

        public ServiceInfoForm()
        {
            InitializeComponent();
            txtServInstall.Text   = string.Format(txtServInstall.Text, CmdInstall);
            txtServUninstall.Text = string.Format(txtServUninstall.Text, CmdUninstall);
        }

        private void btnCBInstall_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CmdInstall);
        }

        private void btnCBUninstall_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CmdUninstall);
        }
    }
}