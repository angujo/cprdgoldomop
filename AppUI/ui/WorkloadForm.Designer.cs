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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabWorkload       = new System.Windows.Forms.TabControl();
            this.tabDetails        = new System.Windows.Forms.TabPage();
            this.groupBox5         = new System.Windows.Forms.GroupBox();
            this.label33           = new System.Windows.Forms.Label();
            this.ndParallels       = new System.Windows.Forms.NumericUpDown();
            this.ndChunkSize       = new System.Windows.Forms.NumericUpDown();
            this.label32           = new System.Windows.Forms.Label();
            this.label31           = new System.Windows.Forms.Label();
            this.groupBox4         = new System.Windows.Forms.GroupBox();
            this.btnStop           = new System.Windows.Forms.Button();
            this.btnQueue          = new System.Windows.Forms.Button();
            this.groupBox3         = new System.Windows.Forms.GroupBox();
            this.txtFull           = new System.Windows.Forms.Label();
            this.txtIdx            = new System.Windows.Forms.Label();
            this.txtPsChunk        = new System.Windows.Forms.Label();
            this.txtChunkLoad      = new System.Windows.Forms.Label();
            this.txtChunkSet       = new System.Windows.Forms.Label();
            this.txtPChunk         = new System.Windows.Forms.Label();
            this.txtRun            = new System.Windows.Forms.Label();
            this.label29           = new System.Windows.Forms.Label();
            this.label27           = new System.Windows.Forms.Label();
            this.label25           = new System.Windows.Forms.Label();
            this.label23           = new System.Windows.Forms.Label();
            this.label21           = new System.Windows.Forms.Label();
            this.label19           = new System.Windows.Forms.Label();
            this.label17           = new System.Windows.Forms.Label();
            this.dtWlDate          = new System.Windows.Forms.DateTimePicker();
            this.label2            = new System.Windows.Forms.Label();
            this.tbWlName          = new System.Windows.Forms.TextBox();
            this.label1            = new System.Windows.Forms.Label();
            this.tabSchema         = new System.Windows.Forms.TabPage();
            this.groupBox1         = new System.Windows.Forms.GroupBox();
            this.btnVocabularyTest = new System.Windows.Forms.Button();
            this.btnSourceTest     = new System.Windows.Forms.Button();
            this.btnTargetTest     = new System.Windows.Forms.Button();
            this.scVocabulary      = new System.Windows.Forms.TextBox();
            this.scSource          = new System.Windows.Forms.TextBox();
            this.scTarget          = new System.Windows.Forms.TextBox();
            this.label10           = new System.Windows.Forms.Label();
            this.label9            = new System.Windows.Forms.Label();
            this.label8            = new System.Windows.Forms.Label();
            this.scPassword        = new System.Windows.Forms.TextBox();
            this.scPort            = new System.Windows.Forms.NumericUpDown();
            this.scUsername        = new System.Windows.Forms.TextBox();
            this.scDb              = new System.Windows.Forms.TextBox();
            this.scServer          = new System.Windows.Forms.TextBox();
            this.label7            = new System.Windows.Forms.Label();
            this.label6            = new System.Windows.Forms.Label();
            this.label5            = new System.Windows.Forms.Label();
            this.label4            = new System.Windows.Forms.Label();
            this.label3            = new System.Windows.Forms.Label();
            this.tabProgress       = new System.Windows.Forms.TabPage();
            this.dgvProgress       = new System.Windows.Forms.DataGridView();
            this.clmPName          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPValue         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbPTimer          = new System.Windows.Forms.ComboBox();
            this.pbItems           = new System.Windows.Forms.ProgressBar();
            this.tabChunks         = new System.Windows.Forms.TabPage();
            this.dgvChunks         = new System.Windows.Forms.DataGridView();
            this.clcOrdinal        = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcStart          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcEnd            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcDuration       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcStatus         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clcError          = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnChunkFilter    = new System.Windows.Forms.Button();
            this.nmCOrdinal        = new System.Windows.Forms.NumericUpDown();
            this.label12           = new System.Windows.Forms.Label();
            this.cbCStatuses       = new System.Windows.Forms.ComboBox();
            this.label11           = new System.Windows.Forms.Label();
            this.tabItems          = new System.Windows.Forms.TabPage();
            this.groupBox2         = new System.Windows.Forms.GroupBox();
            this.btnItemsFielter   = new System.Windows.Forms.Button();
            this.cbIStatuses       = new System.Windows.Forms.ComboBox();
            this.label14           = new System.Windows.Forms.Label();
            this.cbINames          = new System.Windows.Forms.ComboBox();
            this.nmIOrdinal        = new System.Windows.Forms.NumericUpDown();
            this.label16           = new System.Windows.Forms.Label();
            this.label13           = new System.Windows.Forms.Label();
            this.cbITypes          = new System.Windows.Forms.ComboBox();
            this.label15           = new System.Windows.Forms.Label();
            this.dgvItems          = new System.Windows.Forms.DataGridView();
            this.clmChunk          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStart          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEnd            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDur            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus         = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmError          = new System.Windows.Forms.DataGridViewLinkColumn();
            this.statusStrip1      = new System.Windows.Forms.StatusStrip();
            this.tsProgressBar     = new System.Windows.Forms.ToolStripProgressBar();
            this.linkLabel1        = new System.Windows.Forms.LinkLabel();
            this.tabWorkload.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ndParallels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ndChunkSize)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabDetails.Controls.Add(this.groupBox5);
            this.tabDetails.Controls.Add(this.groupBox4);
            this.tabDetails.Controls.Add(this.groupBox3);
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.ndParallels);
            this.groupBox5.Controls.Add(this.ndChunkSize);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Location = new System.Drawing.Point(6, 63);
            this.groupBox5.Name     = "groupBox5";
            this.groupBox5.Size     = new System.Drawing.Size(330, 91);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop  = false;
            this.groupBox5.Text     = "Settings";
            // 
            // label33
            // 
            this.label33.Font      = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label33.Location  = new System.Drawing.Point(112, 60);
            this.label33.Name      = "label33";
            this.label33.Size      = new System.Drawing.Size(212, 23);
            this.label33.TabIndex  = 2;
            this.label33.Text      = "Set to 0 (Zero) for system selection";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ndParallels
            // 
            this.ndParallels.Location = new System.Drawing.Point(112, 37);
            this.ndParallels.Maximum  = new decimal(new int[] {1000, 0, 0, 0});
            this.ndParallels.Name     = "ndParallels";
            this.ndParallels.Size     = new System.Drawing.Size(212, 20);
            this.ndParallels.TabIndex = 1;
            // 
            // ndChunkSize
            // 
            this.ndChunkSize.Location = new System.Drawing.Point(112, 14);
            this.ndChunkSize.Minimum  = new decimal(new int[] {1, 0, 0, 0});
            this.ndChunkSize.Name     = "ndChunkSize";
            this.ndChunkSize.Size     = new System.Drawing.Size(212, 20);
            this.ndChunkSize.TabIndex = 1;
            this.ndChunkSize.Value    = new decimal(new int[] {1, 0, 0, 0});
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(6, 39);
            this.label32.Name     = "label32";
            this.label32.Size     = new System.Drawing.Size(100, 23);
            this.label32.TabIndex = 0;
            this.label32.Text     = "Max Parralellism";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(6, 16);
            this.label31.Name     = "label31";
            this.label31.Size     = new System.Drawing.Size(100, 23);
            this.label31.TabIndex = 0;
            this.label31.Text     = "Chunk Size";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStop);
            this.groupBox4.Controls.Add(this.btnQueue);
            this.groupBox4.Location = new System.Drawing.Point(6, 160);
            this.groupBox4.Name     = "groupBox4";
            this.groupBox4.Size     = new System.Drawing.Size(330, 88);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop  = false;
            this.groupBox4.Text     = "Actions";
            // 
            // btnStop
            // 
            this.btnStop.Location                =  new System.Drawing.Point(6, 51);
            this.btnStop.Name                    =  "btnStop";
            this.btnStop.Size                    =  new System.Drawing.Size(148, 23);
            this.btnStop.TabIndex                =  0;
            this.btnStop.Text                    =  "Schedule Stop";
            this.btnStop.UseVisualStyleBackColor =  true;
            this.btnStop.Click                   += new System.EventHandler(this.btnStop_Click);
            // 
            // btnQueue
            // 
            this.btnQueue.Location                =  new System.Drawing.Point(6, 22);
            this.btnQueue.Name                    =  "btnQueue";
            this.btnQueue.Size                    =  new System.Drawing.Size(148, 23);
            this.btnQueue.TabIndex                =  0;
            this.btnQueue.Text                    =  "Send To Queue";
            this.btnQueue.UseVisualStyleBackColor =  true;
            this.btnQueue.Click                   += new System.EventHandler(this.btnQueue_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFull);
            this.groupBox3.Controls.Add(this.txtIdx);
            this.groupBox3.Controls.Add(this.txtPsChunk);
            this.groupBox3.Controls.Add(this.txtChunkLoad);
            this.groupBox3.Controls.Add(this.txtChunkSet);
            this.groupBox3.Controls.Add(this.txtPChunk);
            this.groupBox3.Controls.Add(this.txtRun);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Location = new System.Drawing.Point(342, 6);
            this.groupBox3.Name     = "groupBox3";
            this.groupBox3.Size     = new System.Drawing.Size(420, 190);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop  = false;
            this.groupBox3.Text     = "Status";
            // 
            // txtFull
            // 
            this.txtFull.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtFull.Location = new System.Drawing.Point(133, 154);
            this.txtFull.Name     = "txtFull";
            this.txtFull.Size     = new System.Drawing.Size(100, 23);
            this.txtFull.TabIndex = 1;
            this.txtFull.Text     = "No";
            // 
            // txtIdx
            // 
            this.txtIdx.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtIdx.Location = new System.Drawing.Point(133, 131);
            this.txtIdx.Name     = "txtIdx";
            this.txtIdx.Size     = new System.Drawing.Size(100, 23);
            this.txtIdx.TabIndex = 1;
            this.txtIdx.Text     = "No";
            // 
            // txtPsChunk
            // 
            this.txtPsChunk.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPsChunk.Location = new System.Drawing.Point(133, 108);
            this.txtPsChunk.Name     = "txtPsChunk";
            this.txtPsChunk.Size     = new System.Drawing.Size(100, 23);
            this.txtPsChunk.TabIndex = 1;
            this.txtPsChunk.Text     = "No";
            // 
            // txtChunkLoad
            // 
            this.txtChunkLoad.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtChunkLoad.Location = new System.Drawing.Point(133, 85);
            this.txtChunkLoad.Name     = "txtChunkLoad";
            this.txtChunkLoad.Size     = new System.Drawing.Size(100, 23);
            this.txtChunkLoad.TabIndex = 1;
            this.txtChunkLoad.Text     = "No";
            // 
            // txtChunkSet
            // 
            this.txtChunkSet.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtChunkSet.Location = new System.Drawing.Point(133, 62);
            this.txtChunkSet.Name     = "txtChunkSet";
            this.txtChunkSet.Size     = new System.Drawing.Size(100, 23);
            this.txtChunkSet.TabIndex = 1;
            this.txtChunkSet.Text     = "No";
            // 
            // txtPChunk
            // 
            this.txtPChunk.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPChunk.Location = new System.Drawing.Point(133, 39);
            this.txtPChunk.Name     = "txtPChunk";
            this.txtPChunk.Size     = new System.Drawing.Size(100, 23);
            this.txtPChunk.TabIndex = 1;
            this.txtPChunk.Text     = "No";
            // 
            // txtRun
            // 
            this.txtRun.Font     = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtRun.Location = new System.Drawing.Point(133, 16);
            this.txtRun.Name     = "txtRun";
            this.txtRun.Size     = new System.Drawing.Size(100, 23);
            this.txtRun.TabIndex = 1;
            this.txtRun.Text     = "No";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(6, 154);
            this.label29.Name     = "label29";
            this.label29.Size     = new System.Drawing.Size(121, 23);
            this.label29.TabIndex = 0;
            this.label29.Text     = "Fully Loaded";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(6, 131);
            this.label27.Name     = "label27";
            this.label27.Size     = new System.Drawing.Size(121, 23);
            this.label27.TabIndex = 0;
            this.label27.Text     = "Indices Loaded";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(6, 108);
            this.label25.Name     = "label25";
            this.label25.Size     = new System.Drawing.Size(121, 23);
            this.label25.TabIndex = 0;
            this.label25.Text     = "Post-Chunk Loaded";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(6, 85);
            this.label23.Name     = "label23";
            this.label23.Size     = new System.Drawing.Size(121, 23);
            this.label23.TabIndex = 0;
            this.label23.Text     = "Chunks Loaded";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(6, 62);
            this.label21.Name     = "label21";
            this.label21.Size     = new System.Drawing.Size(121, 23);
            this.label21.TabIndex = 0;
            this.label21.Text     = "Chunk Setup";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 39);
            this.label19.Name     = "label19";
            this.label19.Size     = new System.Drawing.Size(121, 23);
            this.label19.TabIndex = 0;
            this.label19.Text     = "Pre-Chunk Setup";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name     = "label17";
            this.label17.Size     = new System.Drawing.Size(121, 23);
            this.label17.TabIndex = 0;
            this.label17.Text     = "Running";
            // 
            // dtWlDate
            // 
            this.dtWlDate.Location = new System.Drawing.Point(96, 37);
            this.dtWlDate.Name     = "dtWlDate";
            this.dtWlDate.Size     = new System.Drawing.Size(240, 20);
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
            this.groupBox1.Controls.Add(this.btnVocabularyTest);
            this.groupBox1.Controls.Add(this.btnSourceTest);
            this.groupBox1.Controls.Add(this.btnTargetTest);
            this.groupBox1.Controls.Add(this.scVocabulary);
            this.groupBox1.Controls.Add(this.scSource);
            this.groupBox1.Controls.Add(this.scTarget);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(6, 157);
            this.groupBox1.Name     = "groupBox1";
            this.groupBox1.Size     = new System.Drawing.Size(371, 105);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop  = false;
            this.groupBox1.Text     = "Schemas";
            // 
            // btnVocabularyTest
            // 
            this.btnVocabularyTest.Location                =  new System.Drawing.Point(319, 57);
            this.btnVocabularyTest.Name                    =  "btnVocabularyTest";
            this.btnVocabularyTest.Size                    =  new System.Drawing.Size(42, 23);
            this.btnVocabularyTest.TabIndex                =  11;
            this.btnVocabularyTest.Text                    =  "Test";
            this.btnVocabularyTest.UseVisualStyleBackColor =  true;
            this.btnVocabularyTest.Click                   += new System.EventHandler(this.btnVocabTest_Click);
            // 
            // btnSourceTest
            // 
            this.btnSourceTest.Location                =  new System.Drawing.Point(319, 34);
            this.btnSourceTest.Name                    =  "btnSourceTest";
            this.btnSourceTest.Size                    =  new System.Drawing.Size(42, 23);
            this.btnSourceTest.TabIndex                =  11;
            this.btnSourceTest.Text                    =  "Test";
            this.btnSourceTest.UseVisualStyleBackColor =  true;
            this.btnSourceTest.Click                   += new System.EventHandler(this.btnSourceTest_Click);
            // 
            // btnTargetTest
            // 
            this.btnTargetTest.Location                =  new System.Drawing.Point(319, 11);
            this.btnTargetTest.Name                    =  "btnTargetTest";
            this.btnTargetTest.Size                    =  new System.Drawing.Size(42, 23);
            this.btnTargetTest.TabIndex                =  11;
            this.btnTargetTest.Text                    =  "Test";
            this.btnTargetTest.UseVisualStyleBackColor =  true;
            this.btnTargetTest.Click                   += new System.EventHandler(this.btnTargetTest_Click);
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
            this.scPassword.Size                  = new System.Drawing.Size(265, 20);
            this.scPassword.TabIndex              = 9;
            this.scPassword.UseSystemPasswordChar = true;
            // 
            // scPort
            // 
            this.scPort.Location = new System.Drawing.Point(112, 86);
            this.scPort.Maximum  = new decimal(new int[] {99999, 0, 0, 0});
            this.scPort.Minimum  = new decimal(new int[] {10, 0, 0, 0});
            this.scPort.Name     = "scPort";
            this.scPort.Size     = new System.Drawing.Size(265, 20);
            this.scPort.TabIndex = 8;
            this.scPort.Value    = new decimal(new int[] {5432, 0, 0, 0});
            // 
            // scUsername
            // 
            this.scUsername.Location = new System.Drawing.Point(112, 62);
            this.scUsername.Name     = "scUsername";
            this.scUsername.Size     = new System.Drawing.Size(265, 20);
            this.scUsername.TabIndex = 7;
            // 
            // scDb
            // 
            this.scDb.Location = new System.Drawing.Point(112, 39);
            this.scDb.Name     = "scDb";
            this.scDb.Size     = new System.Drawing.Size(265, 20);
            this.scDb.TabIndex = 6;
            // 
            // scServer
            // 
            this.scServer.Location = new System.Drawing.Point(112, 16);
            this.scServer.Name     = "scServer";
            this.scServer.Size     = new System.Drawing.Size(265, 20);
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
            this.tabProgress.Controls.Add(this.pbItems);
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
            this.dgvProgress.AllowUserToAddRows            = false;
            this.dgvProgress.AllowUserToDeleteRows         = false;
            this.dgvProgress.Anchor                        = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment               = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor               = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font                    = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor               = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor      = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor      = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode                = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgress.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProgress.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.clmPName, this.clmPValue});
            dataGridViewCellStyle2.Alignment            = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor            = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font                 = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle2.ForeColor            = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor   = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor   = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode             = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProgress.DefaultCellStyle           = dataGridViewCellStyle2;
            this.dgvProgress.Location                   = new System.Drawing.Point(6, 33);
            this.dgvProgress.Name                       = "dgvProgress";
            this.dgvProgress.ReadOnly                   = true;
            dataGridViewCellStyle3.Alignment            = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor            = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font                 = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle3.ForeColor            = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor   = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor   = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode             = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgress.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProgress.Size                       = new System.Drawing.Size(756, 334);
            this.dgvProgress.TabIndex                   = 3;
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
            // pbItems
            // 
            this.pbItems.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItems.Location = new System.Drawing.Point(120, 11);
            this.pbItems.Name     = "pbItems";
            this.pbItems.Size     = new System.Drawing.Size(642, 16);
            this.pbItems.TabIndex = 0;
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
            this.dgvChunks.AllowUserToAddRows            = false;
            this.dgvChunks.AllowUserToDeleteRows         = false;
            this.dgvChunks.Anchor                        = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment             = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor             = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font                  = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle4.ForeColor             = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor    = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor    = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode              = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChunks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChunks.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChunks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.clcOrdinal, this.clcStart, this.clcEnd, this.clcDuration, this.clcStatus, this.clcError});
            dataGridViewCellStyle5.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor          = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font               = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle5.ForeColor          = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode           = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChunks.DefaultCellStyle           = dataGridViewCellStyle5;
            this.dgvChunks.Location                   = new System.Drawing.Point(6, 32);
            this.dgvChunks.Name                       = "dgvChunks";
            this.dgvChunks.ReadOnly                   = true;
            dataGridViewCellStyle6.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor          = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font               = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle6.ForeColor          = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode           = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChunks.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChunks.Size                       = new System.Drawing.Size(756, 335);
            this.dgvChunks.TabIndex                   = 6;
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
            this.dgvItems.AllowUserToAddRows            = false;
            this.dgvItems.AllowUserToDeleteRows         = false;
            this.dgvItems.Anchor                        = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment            = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor            = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font                 = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle7.ForeColor            = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor   = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor   = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode             = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvItems.ColumnHeadersHeightSizeMode   = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.clmChunk, this.clmName, this.clmStart, this.clmEnd, this.clmDur, this.clmStatus, this.clmError});
            dataGridViewCellStyle8.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor          = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font               = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle8.ForeColor          = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode           = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle            = dataGridViewCellStyle8;
            this.dgvItems.Location                    = new System.Drawing.Point(6, 82);
            this.dgvItems.Name                        = "dgvItems";
            this.dgvItems.ReadOnly                    = true;
            dataGridViewCellStyle9.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor          = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font               = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle9.ForeColor          = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode           = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle  = dataGridViewCellStyle9;
            this.dgvItems.Size                        = new System.Drawing.Size(756, 285);
            this.dgvItems.TabIndex                    = 12;
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
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.tsProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name     = "statusStrip1";
            this.statusStrip1.Size     = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text     = "statusStrip1";
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
            this.BackColor           = System.Drawing.SystemColors.Control;
            this.ClientSize          = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabWorkload);
            this.Location    = new System.Drawing.Point(15, 15);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name        = "WorkloadForm";
            this.Text        = "Workload Form";
            this.tabWorkload.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ndParallels)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ndChunkSize)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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

        private System.Windows.Forms.Label label33;

        private System.Windows.Forms.NumericUpDown ndChunkSize;
        private System.Windows.Forms.NumericUpDown ndParallels;
        private System.Windows.Forms.Button        btnQueue;
        private System.Windows.Forms.Button        btnStop;

        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;

        private System.Windows.Forms.GroupBox groupBox5;

        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.Button btnTargetTest;
        private System.Windows.Forms.Button btnSourceTest;
        private System.Windows.Forms.Button btnVocabularyTest;

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label txtRun;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label txtPChunk;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label txtChunkSet;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label txtChunkLoad;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label txtPsChunk;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label txtIdx;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label txtFull;

        private System.Windows.Forms.GroupBox groupBox3;

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
        private System.Windows.Forms.ProgressBar pbItems;

        private System.Windows.Forms.TextBox       scPassword;
        private System.Windows.Forms.TextBox       scServer;
        private System.Windows.Forms.TextBox       scDb;
        private System.Windows.Forms.TextBox       scUsername;
        private System.Windows.Forms.NumericUpDown scPort;

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
        // private System.Windows.Forms.TabPage Details;

        #endregion
    }
}