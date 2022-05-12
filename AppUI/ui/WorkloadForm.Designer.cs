using System.ComponentModel;

namespace AppUI.ui
{
    partial class WorkloadForm
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
            this.tabWorkload           = new System.Windows.Forms.TabControl();
            this.tabDetails            = new System.Windows.Forms.TabPage();
            this.dtWlDate              = new System.Windows.Forms.DateTimePicker();
            this.label2                = new System.Windows.Forms.Label();
            this.tbWlName              = new System.Windows.Forms.TextBox();
            this.label1                = new System.Windows.Forms.Label();
            this.tabSchema             = new System.Windows.Forms.TabPage();
            this.groupBox1             = new System.Windows.Forms.GroupBox();
            this.scVocabulary          = new System.Windows.Forms.TextBox();
            this.scSource              = new System.Windows.Forms.TextBox();
            this.scTarget              = new System.Windows.Forms.TextBox();
            this.label10               = new System.Windows.Forms.Label();
            this.label9                = new System.Windows.Forms.Label();
            this.label8                = new System.Windows.Forms.Label();
            this.scPassword            = new System.Windows.Forms.TextBox();
            this.scPort                = new System.Windows.Forms.NumericUpDown();
            this.scUsername            = new System.Windows.Forms.TextBox();
            this.scDb                  = new System.Windows.Forms.TextBox();
            this.scServer              = new System.Windows.Forms.TextBox();
            this.label7                = new System.Windows.Forms.Label();
            this.label6                = new System.Windows.Forms.Label();
            this.label5                = new System.Windows.Forms.Label();
            this.label4                = new System.Windows.Forms.Label();
            this.label3                = new System.Windows.Forms.Label();
            this.tabProgress           = new System.Windows.Forms.TabPage();
            this.lvAnalysis            = new System.Windows.Forms.ListView();
            this.chName                = new System.Windows.Forms.ColumnHeader();
            this.chValue               = new System.Windows.Forms.ColumnHeader();
            this.progressBar1          = new System.Windows.Forms.ProgressBar();
            this.tabChunks             = new System.Windows.Forms.TabPage();
            this.lvChunks              = new System.Windows.Forms.ListView();
            this.chOrdinal             = new System.Windows.Forms.ColumnHeader();
            this.chStart               = new System.Windows.Forms.ColumnHeader();
            this.chEnd                 = new System.Windows.Forms.ColumnHeader();
            this.chDuration            = new System.Windows.Forms.ColumnHeader();
            this.chStatus              = new System.Windows.Forms.ColumnHeader();
            this.numericUpDown1        = new System.Windows.Forms.NumericUpDown();
            this.label12               = new System.Windows.Forms.Label();
            this.comboBox1             = new System.Windows.Forms.ComboBox();
            this.label11               = new System.Windows.Forms.Label();
            this.tabItems              = new System.Windows.Forms.TabPage();
            this.listView3             = new System.Windows.Forms.ListView();
            this.chIChunk              = new System.Windows.Forms.ColumnHeader();
            this.chcName               = new System.Windows.Forms.ColumnHeader();
            this.chIStart              = new System.Windows.Forms.ColumnHeader();
            this.chIEnd                = new System.Windows.Forms.ColumnHeader();
            this.chIDuration           = new System.Windows.Forms.ColumnHeader();
            this.chIStatus             = new System.Windows.Forms.ColumnHeader();
            this.comboBox4             = new System.Windows.Forms.ComboBox();
            this.label16               = new System.Windows.Forms.Label();
            this.comboBox3             = new System.Windows.Forms.ComboBox();
            this.label15               = new System.Windows.Forms.Label();
            this.numericUpDown2        = new System.Windows.Forms.NumericUpDown();
            this.label13               = new System.Windows.Forms.Label();
            this.comboBox2             = new System.Windows.Forms.ComboBox();
            this.label14               = new System.Windows.Forms.Label();
            this.statusStrip1          = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.linkLabel1            = new System.Windows.Forms.LinkLabel();
            this.tabWorkload.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabSchema.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scPort)).BeginInit();
            this.tabProgress.SuspendLayout();
            this.tabChunks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabWorkload
            // 
            this.tabWorkload.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabWorkload.Controls.Add(this.tabDetails);
            this.tabWorkload.Controls.Add(this.tabSchema);
            this.tabWorkload.Controls.Add(this.tabProgress);
            this.tabWorkload.Controls.Add(this.tabChunks);
            this.tabWorkload.Controls.Add(this.tabItems);
            this.tabWorkload.Location      =  new System.Drawing.Point(12, 36);
            this.tabWorkload.Name          =  "tabWorkload";
            this.tabWorkload.SelectedIndex =  0;
            this.tabWorkload.Size          =  new System.Drawing.Size(776, 402);
            this.tabWorkload.TabIndex      =  0;
            this.tabWorkload.Selected      += new System.Windows.Forms.TabControlEventHandler(this.tabWorkload_Selected);
            // 
            // tabDetails
            // 
            this.tabDetails.AutoScroll = true;
            this.tabDetails.Controls.Add(this.dtWlDate);
            this.tabDetails.Controls.Add(this.label2);
            this.tabDetails.Controls.Add(this.tbWlName);
            this.tabDetails.Controls.Add(this.label1);
            this.tabDetails.Location                = new System.Drawing.Point(4, 22);
            this.tabDetails.Name                    = "tabDetails";
            this.tabDetails.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size                    = new System.Drawing.Size(768, 376);
            this.tabDetails.TabIndex                = 0;
            this.tabDetails.Text                    = "Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // dtWlDate
            // 
            this.dtWlDate.Location = new System.Drawing.Point(93, 37);
            this.dtWlDate.Name     = "dtWlDate";
            this.dtWlDate.Size     = new System.Drawing.Size(243, 20);
            this.dtWlDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name     = "label2";
            this.label2.Size     = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 2;
            this.label2.Text     = "Date Released";
            // 
            // tbWlName
            // 
            this.tbWlName.Location = new System.Drawing.Point(96, 9);
            this.tbWlName.Name     = "tbWlName";
            this.tbWlName.Size     = new System.Drawing.Size(240, 20);
            this.tbWlName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name     = "label1";
            this.label1.Size     = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 0;
            this.label1.Text     = "Name";
            // 
            // tabSchema
            // 
            this.tabSchema.AutoScroll = true;
            this.tabSchema.Controls.Add(this.groupBox1);
            this.tabSchema.Controls.Add(this.scPassword);
            this.tabSchema.Controls.Add(this.scPort);
            this.tabSchema.Controls.Add(this.scUsername);
            this.tabSchema.Controls.Add(this.scDb);
            this.tabSchema.Controls.Add(this.scServer);
            this.tabSchema.Controls.Add(this.label7);
            this.tabSchema.Controls.Add(this.label6);
            this.tabSchema.Controls.Add(this.label5);
            this.tabSchema.Controls.Add(this.label4);
            this.tabSchema.Controls.Add(this.label3);
            this.tabSchema.Location                = new System.Drawing.Point(4, 22);
            this.tabSchema.Name                    = "tabSchema";
            this.tabSchema.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabSchema.Size                    = new System.Drawing.Size(768, 376);
            this.tabSchema.TabIndex                = 1;
            this.tabSchema.Text                    = "Schema Connections";
            this.tabSchema.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scVocabulary);
            this.groupBox1.Controls.Add(this.scSource);
            this.groupBox1.Controls.Add(this.scTarget);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(6, 157);
            this.groupBox1.Name     = "groupBox1";
            this.groupBox1.Size     = new System.Drawing.Size(319, 105);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop  = false;
            this.groupBox1.Text     = "Schemas";
            // 
            // scVocabulary
            // 
            this.scVocabulary.Location = new System.Drawing.Point(123, 59);
            this.scVocabulary.Name     = "scVocabulary";
            this.scVocabulary.Size     = new System.Drawing.Size(190, 20);
            this.scVocabulary.TabIndex = 5;
            // 
            // scSource
            // 
            this.scSource.Location = new System.Drawing.Point(123, 36);
            this.scSource.Name     = "scSource";
            this.scSource.Size     = new System.Drawing.Size(190, 20);
            this.scSource.TabIndex = 4;
            // 
            // scTarget
            // 
            this.scTarget.Location = new System.Drawing.Point(123, 13);
            this.scTarget.Name     = "scTarget";
            this.scTarget.Size     = new System.Drawing.Size(190, 20);
            this.scTarget.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 62);
            this.label10.Name     = "label10";
            this.label10.Size     = new System.Drawing.Size(111, 23);
            this.label10.TabIndex = 2;
            this.label10.Text     = "Vocabulary Schema";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name     = "label9";
            this.label9.Size     = new System.Drawing.Size(111, 23);
            this.label9.TabIndex = 1;
            this.label9.Text     = "Source Schema";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name     = "label8";
            this.label8.Size     = new System.Drawing.Size(111, 23);
            this.label8.TabIndex = 0;
            this.label8.Text     = "Target Schema";
            // 
            // scPassword
            // 
            this.scPassword.Location              = new System.Drawing.Point(112, 108);
            this.scPassword.Name                  = "scPassword";
            this.scPassword.PasswordChar          = '*';
            this.scPassword.Size                  = new System.Drawing.Size(213, 20);
            this.scPassword.TabIndex              = 9;
            this.scPassword.UseSystemPasswordChar = true;
            // 
            // scPort
            // 
            this.scPort.Location = new System.Drawing.Point(112, 86);
            this.scPort.Maximum  = new decimal(new int[] {99999, 0, 0, 0});
            this.scPort.Minimum  = new decimal(new int[] {10, 0, 0, 0});
            this.scPort.Name     = "scPort";
            this.scPort.Size     = new System.Drawing.Size(213, 20);
            this.scPort.TabIndex = 8;
            this.scPort.Value    = new decimal(new int[] {5432, 0, 0, 0});
            // 
            // scUsername
            // 
            this.scUsername.Location = new System.Drawing.Point(112, 62);
            this.scUsername.Name     = "scUsername";
            this.scUsername.Size     = new System.Drawing.Size(213, 20);
            this.scUsername.TabIndex = 7;
            // 
            // scDb
            // 
            this.scDb.Location = new System.Drawing.Point(112, 39);
            this.scDb.Name     = "scDb";
            this.scDb.Size     = new System.Drawing.Size(213, 20);
            this.scDb.TabIndex = 6;
            // 
            // scServer
            // 
            this.scServer.Location = new System.Drawing.Point(112, 16);
            this.scServer.Name     = "scServer";
            this.scServer.Size     = new System.Drawing.Size(213, 20);
            this.scServer.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name     = "label7";
            this.label7.Size     = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 4;
            this.label7.Text     = "Password";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 88);
            this.label6.Name     = "label6";
            this.label6.Size     = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 3;
            this.label6.Text     = "Port Number";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name     = "label5";
            this.label5.Size     = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 2;
            this.label5.Text     = "Username";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name     = "label4";
            this.label4.Size     = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 1;
            this.label4.Text     = "Server Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name     = "label3";
            this.label3.Size     = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            this.label3.Text     = "Database Name";
            // 
            // tabProgress
            // 
            this.tabProgress.AutoScroll = true;
            this.tabProgress.Controls.Add(this.lvAnalysis);
            this.tabProgress.Controls.Add(this.progressBar1);
            this.tabProgress.Location                = new System.Drawing.Point(4, 22);
            this.tabProgress.Name                    = "tabProgress";
            this.tabProgress.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabProgress.Size                    = new System.Drawing.Size(768, 376);
            this.tabProgress.TabIndex                = 2;
            this.tabProgress.Text                    = "Progress";
            this.tabProgress.UseVisualStyleBackColor = true;
            // 
            // lvAnalysis
            // 
            this.lvAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAnalysis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chName, this.chValue});
            this.lvAnalysis.FullRowSelect                   = true;
            this.lvAnalysis.GridLines                       = true;
            this.lvAnalysis.Location                        = new System.Drawing.Point(6, 28);
            this.lvAnalysis.Name                            = "lvAnalysis";
            this.lvAnalysis.Size                            = new System.Drawing.Size(756, 342);
            this.lvAnalysis.TabIndex                        = 1;
            this.lvAnalysis.UseCompatibleStateImageBehavior = false;
            this.lvAnalysis.View                            = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text  = "Name";
            this.chName.Width = 397;
            // 
            // chValue
            // 
            this.chValue.Text  = "Value";
            this.chValue.Width = 305;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 6);
            this.progressBar1.Name     = "progressBar1";
            this.progressBar1.Size     = new System.Drawing.Size(756, 16);
            this.progressBar1.TabIndex = 0;
            // 
            // tabChunks
            // 
            this.tabChunks.AutoScroll = true;
            this.tabChunks.Controls.Add(this.lvChunks);
            this.tabChunks.Controls.Add(this.numericUpDown1);
            this.tabChunks.Controls.Add(this.label12);
            this.tabChunks.Controls.Add(this.comboBox1);
            this.tabChunks.Controls.Add(this.label11);
            this.tabChunks.Location                = new System.Drawing.Point(4, 22);
            this.tabChunks.Name                    = "tabChunks";
            this.tabChunks.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabChunks.Size                    = new System.Drawing.Size(768, 376);
            this.tabChunks.TabIndex                = 4;
            this.tabChunks.Text                    = "Chunks\' Status";
            this.tabChunks.UseVisualStyleBackColor = true;
            // 
            // lvChunks
            // 
            this.lvChunks.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChunks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chOrdinal, this.chStart, this.chEnd, this.chDuration, this.chStatus});
            this.lvChunks.FullRowSelect                   = true;
            this.lvChunks.GridLines                       = true;
            this.lvChunks.Location                        = new System.Drawing.Point(6, 32);
            this.lvChunks.Name                            = "lvChunks";
            this.lvChunks.Size                            = new System.Drawing.Size(756, 335);
            this.lvChunks.TabIndex                        = 4;
            this.lvChunks.UseCompatibleStateImageBehavior = false;
            this.lvChunks.View                            = System.Windows.Forms.View.Details;
            // 
            // chOrdinal
            // 
            this.chOrdinal.Text  = "Ordinal";
            this.chOrdinal.Width = 53;
            // 
            // chStart
            // 
            this.chStart.Text  = "Start";
            this.chStart.Width = 110;
            // 
            // chEnd
            // 
            this.chEnd.Text  = "End";
            this.chEnd.Width = 157;
            // 
            // chDuration
            // 
            this.chDuration.Text  = "Duration";
            this.chDuration.Width = 161;
            // 
            // chStatus
            // 
            this.chStatus.Text  = "Status";
            this.chStatus.Width = 224;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(345, 6);
            this.numericUpDown1.Minimum  = new decimal(new int[] {1, 0, 0, -2147483648});
            this.numericUpDown1.Name     = "numericUpDown1";
            this.numericUpDown1.Size     = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(239, 8);
            this.label12.Name     = "label12";
            this.label12.Size     = new System.Drawing.Size(100, 18);
            this.label12.TabIndex = 2;
            this.label12.Text     = "Chunk Ordinal";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {"All", "Queued", "Running", "Completed", "Stopped (Error)"});
            this.comboBox1.Location = new System.Drawing.Point(112, 5);
            this.comboBox1.Name     = "comboBox1";
            this.comboBox1.Size     = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 8);
            this.label11.Name     = "label11";
            this.label11.Size     = new System.Drawing.Size(100, 18);
            this.label11.TabIndex = 0;
            this.label11.Text     = "Status";
            // 
            // tabItems
            // 
            this.tabItems.AutoScroll = true;
            this.tabItems.Controls.Add(this.listView3);
            this.tabItems.Controls.Add(this.comboBox4);
            this.tabItems.Controls.Add(this.label16);
            this.tabItems.Controls.Add(this.comboBox3);
            this.tabItems.Controls.Add(this.label15);
            this.tabItems.Controls.Add(this.numericUpDown2);
            this.tabItems.Controls.Add(this.label13);
            this.tabItems.Controls.Add(this.comboBox2);
            this.tabItems.Controls.Add(this.label14);
            this.tabItems.Location                = new System.Drawing.Point(4, 22);
            this.tabItems.Name                    = "tabItems";
            this.tabItems.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabItems.Size                    = new System.Drawing.Size(768, 376);
            this.tabItems.TabIndex                = 5;
            this.tabItems.Text                    = "Items\' Status";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chIChunk, this.chcName, this.chIStart, this.chIEnd, this.chIDuration, this.chIStatus});
            this.listView3.GridLines                       = true;
            this.listView3.Location                        = new System.Drawing.Point(6, 38);
            this.listView3.Name                            = "listView3";
            this.listView3.Size                            = new System.Drawing.Size(756, 332);
            this.listView3.TabIndex                        = 12;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View                            = System.Windows.Forms.View.Details;
            // 
            // chIChunk
            // 
            this.chIChunk.Text = "Chunk";
            // 
            // chcName
            // 
            this.chcName.Text  = "Name";
            this.chcName.Width = 125;
            // 
            // chIStart
            // 
            this.chIStart.Text  = "Start";
            this.chIStart.Width = 134;
            // 
            // chIEnd
            // 
            this.chIEnd.Text  = "End";
            this.chIEnd.Width = 131;
            // 
            // chIDuration
            // 
            this.chIDuration.Text  = "Duration";
            this.chIDuration.Width = 109;
            // 
            // chIStatus
            // 
            this.chIStatus.Text  = "Status";
            this.chIStatus.Width = 167;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location          = new System.Drawing.Point(616, 11);
            this.comboBox4.Name              = "comboBox4";
            this.comboBox4.Size              = new System.Drawing.Size(146, 21);
            this.comboBox4.TabIndex          = 11;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(566, 14);
            this.label16.Name     = "label16";
            this.label16.Size     = new System.Drawing.Size(44, 18);
            this.label16.TabIndex = 10;
            this.label16.Text     = "Name";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {"Pre-Setup", "Chunk", "Post-Setup", "Indices"});
            this.comboBox3.Location = new System.Drawing.Point(439, 11);
            this.comboBox3.Name     = "comboBox3";
            this.comboBox3.Size     = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(393, 14);
            this.label15.Name     = "label15";
            this.label15.Size     = new System.Drawing.Size(40, 18);
            this.label15.TabIndex = 8;
            this.label15.Text     = "Type";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(267, 12);
            this.numericUpDown2.Minimum  = new decimal(new int[] {3, 0, 0, -2147483648});
            this.numericUpDown2.Name     = "numericUpDown2";
            this.numericUpDown2.Size     = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(180, 14);
            this.label13.Name     = "label13";
            this.label13.Size     = new System.Drawing.Size(81, 18);
            this.label13.TabIndex = 6;
            this.label13.Text     = "Chunk Ordinal:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {"All", "Queued", "Running", "Completed", "Stopped (Error)"});
            this.comboBox2.Location = new System.Drawing.Point(53, 11);
            this.comboBox2.Name     = "comboBox2";
            this.comboBox2.Size     = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 14);
            this.label14.Name     = "label14";
            this.label14.Size     = new System.Drawing.Size(41, 18);
            this.label14.TabIndex = 4;
            this.label14.Text     = "Status";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripStatusLabel1, this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name     = "statusStrip1";
            this.statusStrip1.Size     = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text     = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name      = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size      = new System.Drawing.Size(100, 16);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location    =  new System.Drawing.Point(12, 9);
            this.linkLabel1.Name        =  "linkLabel1";
            this.linkLabel1.Size        =  new System.Drawing.Size(137, 24);
            this.linkLabel1.TabIndex    =  2;
            this.linkLabel1.TabStop     =  true;
            this.linkLabel1.Text        =  "< Back to Work Loads";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // WorkloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabWorkload);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name        = "WorkloadForm";
            this.Text        = "Workload Form";
            this.tabWorkload.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabSchema.ResumeLayout(false);
            this.tabSchema.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scPort)).EndInit();
            this.tabProgress.ResumeLayout(false);
            this.tabChunks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
            this.tabItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.LinkLabel linkLabel1;

        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.ColumnHeader chIChunk;
        private System.Windows.Forms.ColumnHeader chcName;
        private System.Windows.Forms.ColumnHeader chIStart;
        private System.Windows.Forms.ColumnHeader chIEnd;
        private System.Windows.Forms.ColumnHeader chIDuration;
        private System.Windows.Forms.ColumnHeader chIStatus;

        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ListView listView3;

        private System.Windows.Forms.Label label16;

        private System.Windows.Forms.Label    label15;
        private System.Windows.Forms.ComboBox comboBox3;

        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label         label13;
        private System.Windows.Forms.ComboBox      comboBox2;
        private System.Windows.Forms.Label         label14;

        private System.Windows.Forms.ColumnHeader chOrdinal;
        private System.Windows.Forms.ColumnHeader chStart;
        private System.Windows.Forms.ColumnHeader chEnd;
        private System.Windows.Forms.ColumnHeader chDuration;
        private System.Windows.Forms.ColumnHeader chStatus;

        private System.Windows.Forms.ListView lvChunks;

        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.Label    label11;
        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chValue;

        private System.Windows.Forms.ListView lvAnalysis;

        private System.Windows.Forms.GroupBox    groupBox1;
        private System.Windows.Forms.Label       label8;
        private System.Windows.Forms.Label       label9;
        private System.Windows.Forms.Label       label10;
        private System.Windows.Forms.ProgressBar progressBar1;

        private System.Windows.Forms.TextBox       scPassword;
        private System.Windows.Forms.TextBox       scServer;
        private System.Windows.Forms.TextBox       scDb      ;
        private System.Windows.Forms.TextBox       scUsername;
        private System.Windows.Forms.NumericUpDown scPort    ;

        private System.Windows.Forms.Label         label3;
        private System.Windows.Forms.Label         label4;
        private System.Windows.Forms.Label         label5;
        private System.Windows.Forms.Label         label6;
        private System.Windows.Forms.Label         label7;
        private System.Windows.Forms.TextBox       scTarget;
        private System.Windows.Forms.TextBox       scSource;
        private System.Windows.Forms.TextBox       scVocabulary;
        private System.Windows.Forms.NumericUpDown numericUpDown1;

        private System.Windows.Forms.TextBox        tbWlName;
        private System.Windows.Forms.Label          label2;
        private System.Windows.Forms.DateTimePicker dtWlDate;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TabPage tabChunks;
        private System.Windows.Forms.TabPage tabItems;

        private System.Windows.Forms.TabPage    tabProgress;
        private System.Windows.Forms.TabControl tabWorkload;

        private System.Windows.Forms.TabPage tabSchema;

        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage Details;

        #endregion
    }
}