﻿namespace AppUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.button1                         = new System.Windows.Forms.Button();
            this.lvWorkplans                     = new System.Windows.Forms.ListView();
            this.chName                          = new System.Windows.Forms.ColumnHeader();
            this.chRelease                       = new System.Windows.Forms.ColumnHeader();
            this.chStatus                        = new System.Windows.Forms.ColumnHeader();
            this.groupBox1                       = new System.Windows.Forms.GroupBox();
            this.btnServInstall                  = new System.Windows.Forms.Button();
            this.button3                         = new System.Windows.Forms.Button();
            this.button2                         = new System.Windows.Forms.Button();
            this.txtServName                     = new System.Windows.Forms.Label();
            this.txtServLast                     = new System.Windows.Forms.Label();
            this.txtSrvStatus                    = new System.Windows.Forms.Label();
            this.label3                          = new System.Windows.Forms.Label();
            this.label2                          = new System.Windows.Forms.Label();
            this.label1                          = new System.Windows.Forms.Label();
            this.statusStrip1                    = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1           = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1                      = new System.Windows.Forms.MenuStrip();
            this.reloadToolStripMenuItem         = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem           = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem          = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2                       = new System.Windows.Forms.GroupBox();
            this.label4                          = new System.Windows.Forms.Label();
            this.txtServTick                     = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location                =  new System.Drawing.Point(6, 19);
            this.button1.Name                    =  "button1";
            this.button1.Size                    =  new System.Drawing.Size(106, 23);
            this.button1.TabIndex                =  0;
            this.button1.Text                    =  "New Work Load";
            this.button1.UseVisualStyleBackColor =  true;
            this.button1.Click                   += new System.EventHandler(this.button1_Click);
            // 
            // lvWorkplans
            // 
            this.lvWorkplans.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvWorkplans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chName, this.chRelease, this.chStatus});
            this.lvWorkplans.FullRowSelect                   =  true;
            this.lvWorkplans.GridLines                       =  true;
            this.lvWorkplans.Location                        =  new System.Drawing.Point(12, 175);
            this.lvWorkplans.MultiSelect                     =  false;
            this.lvWorkplans.Name                            =  "lvWorkplans";
            this.lvWorkplans.Size                            =  new System.Drawing.Size(776, 263);
            this.lvWorkplans.TabIndex                        =  1;
            this.lvWorkplans.UseCompatibleStateImageBehavior =  false;
            this.lvWorkplans.View                            =  System.Windows.Forms.View.Details;
            this.lvWorkplans.DoubleClick                     += new System.EventHandler(this.lvWorkplans_DoubleClick);
            // 
            // chName
            // 
            this.chName.Text  = "Name";
            this.chName.Width = 189;
            // 
            // chRelease
            // 
            this.chRelease.Text  = "Release Date";
            this.chRelease.Width = 201;
            // 
            // chStatus
            // 
            this.chStatus.Text  = "Status";
            this.chStatus.Width = 143;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtServName);
            this.groupBox1.Controls.Add(this.txtServTick);
            this.groupBox1.Controls.Add(this.txtServLast);
            this.groupBox1.Controls.Add(this.txtSrvStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name     = "groupBox1";
            this.groupBox1.Size     = new System.Drawing.Size(412, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop  = false;
            this.groupBox1.Text     = "Service";
            // 
            // btnServInstall
            // 
            this.btnServInstall.Location                =  new System.Drawing.Point(118, 19);
            this.btnServInstall.Name                    =  "btnServInstall";
            this.btnServInstall.Size                    =  new System.Drawing.Size(106, 23);
            this.btnServInstall.TabIndex                =  7;
            this.btnServInstall.Text                    =  "Install";
            this.btnServInstall.UseVisualStyleBackColor =  true;
            this.btnServInstall.Click                   += new System.EventHandler(this.btnServInstall_Click);
            // 
            // button3
            // 
            this.button3.Location                = new System.Drawing.Point(118, 48);
            this.button3.Name                    = "button3";
            this.button3.Size                    = new System.Drawing.Size(106, 23);
            this.button3.TabIndex                = 6;
            this.button3.Text                    = "Start Service";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location                = new System.Drawing.Point(6, 48);
            this.button2.Name                    = "button2";
            this.button2.Size                    = new System.Drawing.Size(106, 23);
            this.button2.TabIndex                = 5;
            this.button2.Text                    = "Stop Service";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtServName
            // 
            this.txtServName.Location = new System.Drawing.Point(112, 16);
            this.txtServName.Name     = "txtServName";
            this.txtServName.Size     = new System.Drawing.Size(140, 23);
            this.txtServName.TabIndex = 4;
            this.txtServName.Text     = "Service 101";
            // 
            // txtServLast
            // 
            this.txtServLast.Location = new System.Drawing.Point(112, 62);
            this.txtServLast.Name     = "txtServLast";
            this.txtServLast.Size     = new System.Drawing.Size(140, 23);
            this.txtServLast.TabIndex = 3;
            this.txtServLast.Text     = "[Unknown]";
            // 
            // txtSrvStatus
            // 
            this.txtSrvStatus.Location = new System.Drawing.Point(112, 39);
            this.txtSrvStatus.Name     = "txtSrvStatus";
            this.txtSrvStatus.Size     = new System.Drawing.Size(140, 23);
            this.txtSrvStatus.TabIndex = 3;
            this.txtSrvStatus.Text     = "Running";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name     = "label3";
            this.label3.Size     = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text     = "Last Run";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name     = "label2";
            this.label2.Size     = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text     = "Status";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name     = "label1";
            this.label1.Size     = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text     = "Name";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name     = "statusStrip1";
            this.statusStrip1.Size     = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text     = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.reloadToolStripMenuItem, this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name     = "menuStrip1";
            this.menuStrip1.Size     = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text     = "menuStrip1";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name  =  "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size  =  new System.Drawing.Size(55, 20);
            this.reloadToolStripMenuItem.Text  =  "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.closeToolStripMenuItem, this.minimizeToTrayToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.infoToolStripMenuItem.Text = "? Info";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name  =  "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size  =  new System.Drawing.Size(162, 22);
            this.closeToolStripMenuItem.Text  =  "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name  =  "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size  =  new System.Drawing.Size(162, 22);
            this.minimizeToTrayToolStripMenuItem.Text  =  "Minimize To Tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTrayToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnServInstall);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(430, 28);
            this.groupBox2.Name     = "groupBox2";
            this.groupBox2.Size     = new System.Drawing.Size(358, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop  = false;
            this.groupBox2.Text     = "Actions";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name     = "label4";
            this.label4.Size     = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text     = "Tick";
            // 
            // txtServTick
            // 
            this.txtServTick.Location = new System.Drawing.Point(112, 85);
            this.txtServTick.Name     = "txtServTick";
            this.txtServTick.Size     = new System.Drawing.Size(140, 23);
            this.txtServTick.TabIndex = 3;
            this.txtServTick.Text     = "[Unknown]";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvWorkplans);
            this.MainMenuStrip = this.menuStrip1;
            this.Name          = "MainForm";
            this.Text          = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label    label4;
        private System.Windows.Forms.Label    txtServTick;

        private System.Windows.Forms.Button btnServInstall;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtServLast;

        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;

        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chRelease;
        private System.Windows.Forms.ColumnHeader chStatus;

        private System.Windows.Forms.ListView lvWorkplans;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label    label1;
        private System.Windows.Forms.Label    label2;
        private System.Windows.Forms.Label    txtSrvStatus;
        private System.Windows.Forms.Label    txtServName;
        private System.Windows.Forms.Button   button2;
        private System.Windows.Forms.Button   button3;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}

