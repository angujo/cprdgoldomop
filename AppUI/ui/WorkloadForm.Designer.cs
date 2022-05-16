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
            this.dgvProgress           = new System.Windows.Forms.DataGridView();
            this.clmPName              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPValue             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPTimer              = new System.Windows.Forms.ComboBox();
            this.progressBar1          = new System.Windows.Forms.ProgressBar();
            this.tabChunks             = new System.Windows.Forms.TabPage();
            this.dgvChunks             = new System.Windows.Forms.DataGridView();
            this.clcOrdinal            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcStart              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcEnd                = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcDuration           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcStatus             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcError              = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnChunkFilter        = new System.Windows.Forms.Button();
            this.nmCOrdinal            = new System.Windows.Forms.NumericUpDown();
            this.label12               = new System.Windows.Forms.Label();
            this.cbCStatuses           = new System.Windows.Forms.ComboBox();
            this.label11               = new System.Windows.Forms.Label();
            this.tabItems              = new System.Windows.Forms.TabPage();
            this.groupBox2             = new System.Windows.Forms.GroupBox();
            this.btnItemsFielter       = new System.Windows.Forms.Button();
            this.cbIStatuses           = new System.Windows.Forms.ComboBox();
            this.label14               = new System.Windows.Forms.Label();
            this.cbINames              = new System.Windows.Forms.ComboBox();
            this.nmIOrdinal            = new System.Windows.Forms.NumericUpDown();
            this.label16               = new System.Windows.Forms.Label();
            this.label13               = new System.Windows.Forms.Label();
            this.cbITypes              = new System.Windows.Forms.ComboBox();
            this.label15               = new System.Windows.Forms.Label();
            this.dgvItems              = new System.Windows.Forms.DataGridView();
            this.clmChunk              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName               = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStart              = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEnd                = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDur                = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmError              = new System.Windows.Forms.DataGridViewLinkColumn();
            this.statusStrip1          = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar         = new System.Windows.Forms.ToolStripProgressBar();
            this.linkLabel1            = new System.Windows.Forms.LinkLabel();
            this.tabWorkload.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabSchema.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.scPort)).BeginInit();
            this.tabProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvProgress)).BeginInit();
            this.tabChunks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgvChunks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.nmCOrdinal)).BeginInit();
            this.tabItems.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nmIOrdinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvItems)).BeginInit();
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
            this.tabWorkload.Deselected    += new System.Windows.Forms.TabControlEventHandler(this.tabWorkload_Deselected);
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
            this.tabProgress.Controls.Add(this.dgvProgress);
            this.tabProgress.Controls.Add(this.cbPTimer);
            this.tabProgress.Controls.Add(this.progressBar1);
            this.tabProgress.Location                = new System.Drawing.Point(4, 22);
            this.tabProgress.Name                    = "tabProgress";
            this.tabProgress.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabProgress.Size                    = new System.Drawing.Size(768, 376);
            this.tabProgress.TabIndex                = 2;
            this.tabProgress.Text                    = "Progress";
            this.tabProgress.UseVisualStyleBackColor = true;
            // 
            // dgvProgress
            // 
            this.dgvProgress.AllowUserToAddRows          = false;
            this.dgvProgress.AllowUserToDeleteRows       = false;
            this.dgvProgress.Anchor                      = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.clmPName, this.clmPValue});
            this.dgvProgress.Location = new System.Drawing.Point(6, 33);
            this.dgvProgress.Name     = "dgvProgress";
            this.dgvProgress.ReadOnly = true;
            this.dgvProgress.Size     = new System.Drawing.Size(756, 334);
            this.dgvProgress.TabIndex = 3;
            // 
            // clmPName
            // 
            this.clmPName.HeaderText = "Item";
            this.clmPName.Name       = "clmPName";
            this.clmPName.ReadOnly   = true;
            this.clmPName.Width      = 300;
            // 
            // clmPValue
            // 
            this.clmPValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPValue.HeaderText   = "";
            this.clmPValue.Name         = "clmPValue";
            this.clmPValue.ReadOnly     = true;
            // 
            // cbPTimer
            // 
            this.cbPTimer.DropDownStyle        =  System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPTimer.FormattingEnabled    =  true;
            this.cbPTimer.Location             =  new System.Drawing.Point(6, 6);
            this.cbPTimer.Name                 =  "cbPTimer";
            this.cbPTimer.Size                 =  new System.Drawing.Size(108, 21);
            this.cbPTimer.TabIndex             =  2;
            this.cbPTimer.SelectedIndexChanged += new System.EventHandler(this.cbPTimer_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(120, 11);
            this.progressBar1.Name     = "progressBar1";
            this.progressBar1.Size     = new System.Drawing.Size(642, 16);
            this.progressBar1.TabIndex = 0;
            // 
            // tabChunks
            // 
            this.tabChunks.AutoScroll = true;
            this.tabChunks.Controls.Add(this.dgvChunks);
            this.tabChunks.Controls.Add(this.btnChunkFilter);
            this.tabChunks.Controls.Add(this.nmCOrdinal);
            this.tabChunks.Controls.Add(this.label12);
            this.tabChunks.Controls.Add(this.cbCStatuses);
            this.tabChunks.Controls.Add(this.label11);
            this.tabChunks.Location                = new System.Drawing.Point(4, 22);
            this.tabChunks.Name                    = "tabChunks";
            this.tabChunks.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabChunks.Size                    = new System.Drawing.Size(768, 376);
            this.tabChunks.TabIndex                = 4;
            this.tabChunks.Text                    = "Chunks\' Status";
            this.tabChunks.UseVisualStyleBackColor = true;
            // 
            // dgvChunks
            // 
            this.dgvChunks.AllowUserToAddRows          = false;
            this.dgvChunks.AllowUserToDeleteRows       = false;
            this.dgvChunks.Anchor                      = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChunks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChunks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.clcOrdinal, this.clcStart, this.clcEnd, this.clcDuration, this.clcStatus, this.clcError});
            this.dgvChunks.Location = new System.Drawing.Point(6, 32);
            this.dgvChunks.Name     = "dgvChunks";
            this.dgvChunks.ReadOnly = true;
            this.dgvChunks.Size     = new System.Drawing.Size(756, 335);
            this.dgvChunks.TabIndex = 6;
            // 
            // clcOrdinal
            // 
            this.clcOrdinal.HeaderText = "Ordinal";
            this.clcOrdinal.Name       = "clcOrdinal";
            this.clcOrdinal.ReadOnly   = true;
            // 
            // clcStart
            // 
            this.clcStart.HeaderText = "Start";
            this.clcStart.Name       = "clcStart";
            this.clcStart.ReadOnly   = true;
            // 
            // clcEnd
            // 
            this.clcEnd.HeaderText = "End";
            this.clcEnd.Name       = "clcEnd";
            this.clcEnd.ReadOnly   = true;
            // 
            // clcDuration
            // 
            this.clcDuration.HeaderText = "Duration";
            this.clcDuration.Name       = "clcDuration";
            this.clcDuration.ReadOnly   = true;
            // 
            // clcStatus
            // 
            this.clcStatus.HeaderText = "Status";
            this.clcStatus.Name       = "clcStatus";
            this.clcStatus.ReadOnly   = true;
            // 
            // clcError
            // 
            this.clcError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clcError.HeaderText   = "Error";
            this.clcError.Name         = "clcError";
            this.clcError.ReadOnly     = true;
            // 
            // btnChunkFilter
            // 
            this.btnChunkFilter.Location                =  new System.Drawing.Point(420, 3);
            this.btnChunkFilter.Name                    =  "btnChunkFilter";
            this.btnChunkFilter.Size                    =  new System.Drawing.Size(75, 23);
            this.btnChunkFilter.TabIndex                =  5;
            this.btnChunkFilter.Text                    =  "Filter";
            this.btnChunkFilter.UseVisualStyleBackColor =  true;
            this.btnChunkFilter.Click                   += new System.EventHandler(this.btnChunkFilter_Click);
            // 
            // nmCOrdinal
            // 
            this.nmCOrdinal.Location = new System.Drawing.Point(294, 6);
            this.nmCOrdinal.Minimum  = new decimal(new int[] {1, 0, 0, -2147483648});
            this.nmCOrdinal.Name     = "nmCOrdinal";
            this.nmCOrdinal.Size     = new System.Drawing.Size(120, 20);
            this.nmCOrdinal.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(205, 8);
            this.label12.Name     = "label12";
            this.label12.Size     = new System.Drawing.Size(83, 18);
            this.label12.TabIndex = 2;
            this.label12.Text     = "Chunk Ordinal";
            // 
            // cbCStatuses
            // 
            this.cbCStatuses.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCStatuses.FormattingEnabled = true;
            this.cbCStatuses.Items.AddRange(new object[] {"All", "Queued", "Running", "Completed", "Stopped (Error)"});
            this.cbCStatuses.Location = new System.Drawing.Point(78, 5);
            this.cbCStatuses.Name     = "cbCStatuses";
            this.cbCStatuses.Size     = new System.Drawing.Size(121, 21);
            this.cbCStatuses.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 8);
            this.label11.Name     = "label11";
            this.label11.Size     = new System.Drawing.Size(66, 18);
            this.label11.TabIndex = 0;
            this.label11.Text     = "Status";
            // 
            // tabItems
            // 
            this.tabItems.AutoScroll = true;
            this.tabItems.Controls.Add(this.groupBox2);
            this.tabItems.Controls.Add(this.dgvItems);
            this.tabItems.Location                = new System.Drawing.Point(4, 22);
            this.tabItems.Name                    = "tabItems";
            this.tabItems.Padding                 = new System.Windows.Forms.Padding(3);
            this.tabItems.Size                    = new System.Drawing.Size(768, 376);
            this.tabItems.TabIndex                = 5;
            this.tabItems.Text                    = "Items\' Status";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnItemsFielter);
            this.groupBox2.Controls.Add(this.cbIStatuses);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbINames);
            this.groupBox2.Controls.Add(this.nmIOrdinal);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cbITypes);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name     = "groupBox2";
            this.groupBox2.Size     = new System.Drawing.Size(756, 70);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop  = false;
            this.groupBox2.Text     = "Filter";
            // 
            // btnItemsFielter
            // 
            this.btnItemsFielter.Location                =  new System.Drawing.Point(553, 37);
            this.btnItemsFielter.Name                    =  "btnItemsFielter";
            this.btnItemsFielter.Size                    =  new System.Drawing.Size(88, 23);
            this.btnItemsFielter.TabIndex                =  12;
            this.btnItemsFielter.Text                    =  "Filter";
            this.btnItemsFielter.UseVisualStyleBackColor =  true;
            this.btnItemsFielter.Click                   += new System.EventHandler(this.btnItemsFilter_Click);
            // 
            // cbIStatuses
            // 
            this.cbIStatuses.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIStatuses.FormattingEnabled = true;
            this.cbIStatuses.Items.AddRange(new object[] {"All", "Queued", "Running", "Completed", "Stopped (Error)"});
            this.cbIStatuses.Location = new System.Drawing.Point(94, 13);
            this.cbIStatuses.Name     = "cbIStatuses";
            this.cbIStatuses.Size     = new System.Drawing.Size(176, 21);
            this.cbIStatuses.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 16);
            this.label14.Name     = "label14";
            this.label14.Size     = new System.Drawing.Size(41, 18);
            this.label14.TabIndex = 4;
            this.label14.Text     = "Status";
            // 
            // cbINames
            // 
            this.cbINames.FormattingEnabled = true;
            this.cbINames.Location          = new System.Drawing.Point(350, 39);
            this.cbINames.Name              = "cbINames";
            this.cbINames.Size              = new System.Drawing.Size(184, 21);
            this.cbINames.TabIndex          = 11;
            // 
            // nmIOrdinal
            // 
            this.nmIOrdinal.Location = new System.Drawing.Point(94, 40);
            this.nmIOrdinal.Minimum  = new decimal(new int[] {3, 0, 0, -2147483648});
            this.nmIOrdinal.Name     = "nmIOrdinal";
            this.nmIOrdinal.Size     = new System.Drawing.Size(176, 20);
            this.nmIOrdinal.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(300, 42);
            this.label16.Name     = "label16";
            this.label16.Size     = new System.Drawing.Size(44, 18);
            this.label16.TabIndex = 10;
            this.label16.Text     = "Name";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(7, 42);
            this.label13.Name     = "label13";
            this.label13.Size     = new System.Drawing.Size(81, 18);
            this.label13.TabIndex = 6;
            this.label13.Text     = "Chunk Ordinal:";
            // 
            // cbITypes
            // 
            this.cbITypes.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbITypes.FormattingEnabled = true;
            this.cbITypes.Items.AddRange(new object[] {"Pre-Setup", "Chunk", "Post-Setup", "Indices"});
            this.cbITypes.Location = new System.Drawing.Point(350, 13);
            this.cbITypes.Name     = "cbITypes";
            this.cbITypes.Size     = new System.Drawing.Size(184, 21);
            this.cbITypes.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(300, 16);
            this.label15.Name     = "label15";
            this.label15.Size     = new System.Drawing.Size(40, 18);
            this.label15.TabIndex = 8;
            this.label15.Text     = "Type";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows          = false;
            this.dgvItems.AllowUserToDeleteRows       = false;
            this.dgvItems.Anchor                      = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.clmChunk, this.clmName, this.clmStart, this.clmEnd, this.clmDur, this.clmStatus, this.clmError});
            this.dgvItems.Location = new System.Drawing.Point(6, 82);
            this.dgvItems.Name     = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size     = new System.Drawing.Size(756, 285);
            this.dgvItems.TabIndex = 12;
            // 
            // clmChunk
            // 
            this.clmChunk.HeaderText = "Chunk";
            this.clmChunk.Name       = "clmChunk";
            this.clmChunk.ReadOnly   = true;
            this.clmChunk.Width      = 60;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name       = "clmName";
            this.clmName.ReadOnly   = true;
            // 
            // clmStart
            // 
            this.clmStart.HeaderText = "Start";
            this.clmStart.Name       = "clmStart";
            this.clmStart.ReadOnly   = true;
            // 
            // clmEnd
            // 
            this.clmEnd.HeaderText = "End";
            this.clmEnd.Name       = "clmEnd";
            this.clmEnd.ReadOnly   = true;
            // 
            // clmDur
            // 
            this.clmDur.HeaderText = "Duration";
            this.clmDur.Name       = "clmDur";
            this.clmDur.ReadOnly   = true;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name       = "clmStatus";
            this.clmStatus.ReadOnly   = true;
            // 
            // clmError
            // 
            this.clmError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmError.HeaderText   = "Error";
            this.clmError.MinimumWidth = 100;
            this.clmError.Name         = "clmError";
            this.clmError.ReadOnly     = true;
            this.clmError.Resizable    = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripStatusLabel1, this.tsProgressBar});
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
            // tsProgressBar
            // 
            this.tsProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProgressBar.Name      = "tsProgressBar";
            this.tsProgressBar.Size      = new System.Drawing.Size(100, 16);
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
            ((System.ComponentModel.ISupportInitialize) (this.dgvProgress)).EndInit();
            this.tabChunks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgvChunks)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.nmCOrdinal)).EndInit();
            this.tabItems.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.nmIOrdinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dgvItems)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn clmPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPValue;

        private System.Windows.Forms.DataGridView dgvProgress;

        private System.Windows.Forms.ComboBox cbPTimer;

        private System.Windows.Forms.DataGridViewTextBoxColumn clcOrdinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clcStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clcEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn clcDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clcStatus;
        private System.Windows.Forms.DataGridViewLinkColumn    clcError;

        private System.Windows.Forms.DataGridView dgvChunks;

        private System.Windows.Forms.Button btnChunkFilter;

        private System.Windows.Forms.DataGridViewTextBoxColumn clmDur;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button   btnItemsFielter;

        private System.Windows.Forms.DataGridViewTextBoxColumn clmChunk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewLinkColumn    clmError;

        private System.Windows.Forms.DataGridView dgvItems;

        private System.Windows.Forms.LinkLabel linkLabel1;

        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.ComboBox cbINames;

        private System.Windows.Forms.Label label16;

        private System.Windows.Forms.Label    label15;
        private System.Windows.Forms.ComboBox cbITypes;

        private System.Windows.Forms.NumericUpDown nmIOrdinal;
        private System.Windows.Forms.Label         label13;
        private System.Windows.Forms.ComboBox      cbIStatuses;
        private System.Windows.Forms.Label         label14;

        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.Label    label11;
        private System.Windows.Forms.ComboBox cbCStatuses;

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
        private System.Windows.Forms.NumericUpDown nmCOrdinal;

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