using System.ComponentModel;

namespace AppUI.ui
{
    partial class ServiceInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1           = new System.Windows.Forms.Label();
            this.txtServInstall   = new System.Windows.Forms.Label();
            this.groupBox1        = new System.Windows.Forms.GroupBox();
            this.btnCBInstall     = new System.Windows.Forms.Button();
            this.groupBox2        = new System.Windows.Forms.GroupBox();
            this.btnCBUninstall   = new System.Windows.Forms.Button();
            this.txtServUninstall = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor    = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location  = new System.Drawing.Point(12, 9);
            this.label1.Name      = "label1";
            this.label1.Size      = new System.Drawing.Size(560, 23);
            this.label1.TabIndex  = 0;
            this.label1.Text      = "A service is required for running the system. The GUI is just for viewing the ser" + "vice status and processes. See below on how to set this up.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtServInstall
            // 
            this.txtServInstall.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServInstall.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtServInstall.Location = new System.Drawing.Point(93, 16);
            this.txtServInstall.Name     = "txtServInstall";
            this.txtServInstall.Size     = new System.Drawing.Size(461, 57);
            this.txtServInstall.TabIndex = 2;
            this.txtServInstall.Text     = "To install the service run the cmd \r\n{0}\r\nusing an elevated command line interfac" + "e (cli)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCBInstall);
            this.groupBox1.Controls.Add(this.txtServInstall);
            this.groupBox1.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name     = "groupBox1";
            this.groupBox1.Size     = new System.Drawing.Size(560, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop  = false;
            this.groupBox1.Text     = "Installation";
            // 
            // btnCBInstall
            // 
            this.btnCBInstall.Font                    =  new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCBInstall.Location                =  new System.Drawing.Point(6, 19);
            this.btnCBInstall.Name                    =  "btnCBInstall";
            this.btnCBInstall.Size                    =  new System.Drawing.Size(75, 23);
            this.btnCBInstall.TabIndex                =  3;
            this.btnCBInstall.Text                    =  "To Clipboard";
            this.btnCBInstall.UseVisualStyleBackColor =  true;
            this.btnCBInstall.Click                   += new System.EventHandler(this.btnCBInstall_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.btnCBUninstall);
            this.groupBox2.Controls.Add(this.txtServUninstall);
            this.groupBox2.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 131);
            this.groupBox2.Name     = "groupBox2";
            this.groupBox2.Size     = new System.Drawing.Size(560, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop  = false;
            this.groupBox2.Text     = "Uninstallation";
            // 
            // btnCBUninstall
            // 
            this.btnCBUninstall.Font                    =  new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCBUninstall.Location                =  new System.Drawing.Point(6, 19);
            this.btnCBUninstall.Name                    =  "btnCBUninstall";
            this.btnCBUninstall.Size                    =  new System.Drawing.Size(75, 23);
            this.btnCBUninstall.TabIndex                =  3;
            this.btnCBUninstall.Text                    =  "To Clipboard";
            this.btnCBUninstall.UseVisualStyleBackColor =  true;
            this.btnCBUninstall.Click                   += new System.EventHandler(this.btnCBUninstall_Click);
            // 
            // txtServUninstall
            // 
            this.txtServUninstall.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServUninstall.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtServUninstall.Location = new System.Drawing.Point(93, 24);
            this.txtServUninstall.Name     = "txtServUninstall";
            this.txtServUninstall.Size     = new System.Drawing.Size(461, 39);
            this.txtServUninstall.TabIndex = 2;
            this.txtServUninstall.Text     = "To uninstall the service run the cmd \r\n{0}\r\n using an elevated command line inter" + "face (cli)";
            // 
            // ServiceInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode        = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize          = new System.Drawing.Size(584, 244);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name        = "ServiceInfoForm";
            this.Text        = "ServiceInfoForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label    txtServInstall;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button   btnCBUninstall;
        private System.Windows.Forms.Label    txtServUninstall;

        private System.Windows.Forms.Button btnCBInstall;

        private System.Windows.Forms.Label    label3;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}