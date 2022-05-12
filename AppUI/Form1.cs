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

namespace AppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var workloadForm = new WorkloadForm();
            workloadForm.Show();
            Hide();
            workloadForm.Closed += (s, args) => this.Close();
        }
    }
}