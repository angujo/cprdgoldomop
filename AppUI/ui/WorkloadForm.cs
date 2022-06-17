using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppUI.models;
using DBMS;
using DBMS.models;
using Util;
using SchemaType = DBMS.SchemaType;
using Timer = System.Windows.Forms.Timer;

namespace AppUI.ui
{
    public partial class WorkloadForm : Form
    {
        private WorkLoad   _workLoad;
        private UIWorkLoad _uiWorkLoad;
        private UIDbSchema _uiDbSchema;
        private UIItems    _uiItems;
        private UIChunks   _uiChunks;
        private UIAnalysis _uiAnalysis;
        public  Form       parent;

        private CancelTokenSource tsAnalysis = new CancelTokenSource();
        private CancellationToken ctAnalysis;
        private int               analysisSleep = 0;

        public WorkloadForm() : this(null)
        {
        }

        public WorkloadForm(WorkLoad workLoad)
        {
            InitializeComponent();
            _workLoad = workLoad ?? new WorkLoad
            {
                Name = Guid.NewGuid().ToString(),
                //  Fileslocked     = false,
                // Sourceprocessed = false,
                Cdmloaded    = false,
                Chunkssetup  = false,
                Chunksloaded = false,
                Cdmprocessed = false,
                Isrunning    = false,
                Maxparallels = 3,
            };
            nmCOrdinal.Maximum = nmIOrdinal.Maximum = ndChunkSize.Maximum = int.MaxValue;

            DetailsTab();
        }

        private void DetailsTab()
        {
            if (null == _uiWorkLoad) _uiWorkLoad = new UIWorkLoad(_workLoad);
            if (!(_workLoad.Chunkssetup || _workLoad.Isrunning))
            {
                ndParallels.DataBindings.Clear();
                ndChunkSize.DataBindings.Clear();
                ndParallels.DataBindings.Add("Value", _uiWorkLoad, "MaxParallels");
                ndChunkSize.DataBindings.Add("Value", _uiWorkLoad, "ChunkSize");
            }
            else
            {
                ndParallels.Enabled = ndChunkSize.Enabled = false;
                ndParallels.Value   = _uiWorkLoad.MaxParallels;
                ndChunkSize.Value   = _uiWorkLoad.ChunkSize;
            }

            btnQueue.Enabled = !(_workLoad.Isrunning || _workLoad.Cdmprocessed);
            btnStop.Enabled  = _workLoad.Isrunning && !_workLoad.Cdmprocessed;

            tbWlName.DataBindings.Clear();
            dtWlDate.DataBindings.Clear();

            tbWlName.DataBindings.Add("Text", _uiWorkLoad, "Name");
            dtWlDate.DataBindings.Add("Value", _uiWorkLoad, "ReleaseDate");

            txtFull.Text      = _workLoad.Cdmprocessed.ToString();   //
            txtIdx.Text       = _workLoad.indices_loaded.ToString(); //
            txtRun.Text       = _workLoad.Isrunning.ToString();      //
            txtChunkLoad.Text = _workLoad.Chunksloaded.ToString();   //
            txtPsChunk.Text   = _workLoad.post_chunk_loaded.ToString();
            txtPChunk.Text    = _workLoad.Cdmloaded.ToString();
            txtChunkSet.Text  = _workLoad.Chunkssetup.ToString();
        }

        private void SchemaTab()
        {
            if (null == _uiDbSchema) _uiDbSchema = new UIDbSchema(_workLoad.Id);
            if (!(_workLoad.Cdmprocessed || _workLoad.Isrunning || _workLoad.Chunksloaded || _workLoad.Chunkssetup ||
                  _workLoad.indices_loaded || _workLoad.post_chunk_loaded || _workLoad.Cdmloaded))
            {
                scServer.DataBindings.Clear();
                scDb.DataBindings.Clear();
                scUsername.DataBindings.Clear();
                scPort.DataBindings.Clear();
                scPassword.DataBindings.Clear();
                scTarget.DataBindings.Clear();
                scSource.DataBindings.Clear();
                scVocabulary.DataBindings.Clear();

                scServer.DataBindings.Add("Text", _uiDbSchema, "server");
                scDb.DataBindings.Add("Text", _uiDbSchema, "dbname");
                scUsername.DataBindings.Add("Text", _uiDbSchema, "user");
                scPort.DataBindings.Add("Text", _uiDbSchema, "portnumber");
                scPassword.DataBindings.Add("Text", _uiDbSchema, "password");
                scTarget.DataBindings.Add("Text", _uiDbSchema, "target_schemaname");
                scSource.DataBindings.Add("Text", _uiDbSchema, "source_schemaname");
                scVocabulary.DataBindings.Add("Text", _uiDbSchema, "vocab_schemaname");
            }
            else
            {
                scServer.Enabled = scDb.Enabled = scUsername.Enabled = scPort.Enabled =
                    scPassword.Enabled = scTarget.Enabled = scSource.Enabled = scVocabulary.Enabled = false;
                scServer.Text     = _uiDbSchema.server;
                scDb.Text         = _uiDbSchema.dbname;
                scUsername.Text   = _uiDbSchema.user;
                scPort.Text       = _uiDbSchema.portnumber.ToString();
                scPassword.Text   = @"****************************";
                scTarget.Text     = _uiDbSchema.target_schemaname;
                scSource.Text     = _uiDbSchema.source_schemaname;
                scVocabulary.Text = _uiDbSchema.vocab_schemaname;
            }
        }

        private void AnalysisTab(bool tabCall = false)
        {
            if (null == _uiAnalysis) _uiAnalysis = new UIAnalysis(_workLoad.Id);
            if (cbPTimer.Items.Count <= 0)
            {
                cbPTimer.Items.Add(new KeyValuePair<int, string>(0, "Paused"));
                cbPTimer.Items.Add(new KeyValuePair<int, string>(2000, "Every 2 Seconds"));
                cbPTimer.Items.Add(new KeyValuePair<int, string>(5000, "Every 5 Seconds"));
                cbPTimer.Items.Add(new KeyValuePair<int, string>(60000, "Every 1 Minute"));

                cbPTimer.ValueMember   = "Key";
                cbPTimer.DisplayMember = "Value";
                cbPTimer.SelectedIndex = 0;
            }

            if (tabCall) AnalysisContent();
            if (0 >= analysisSleep) return;
            tsAnalysis = new CancelTokenSource();
            ctAnalysis = tsAnalysis.Token;

            try
            {
                Log.Info("Start Analysis!!");
                Task.Run(async () =>
                {
                    ctAnalysis.ThrowIfCancellationRequested();
                    while (true)
                    {
                        if (ctAnalysis.IsCancellationRequested) ctAnalysis.ThrowIfCancellationRequested();

                        await SleepProgress(analysisSleep, tsAnalysis.Token);
                        AnalysisContent();
                    }
                }, tsAnalysis.Token);
            }
            catch (Exception exc)
            {
                Log.Error(exc);
            }
        }

        private void AnalysisContent()
        {
            dgvProgress.Invoke(new Action(delegate
            {
                dgvProgress.Rows.Clear();
                _uiAnalysis.LoadAnalysis(
                    lv => dgvProgress.Rows.Add(lv),
                    pb => pbItems.Value = (int) pb);
            }));
        }

        private void ChunksTab()
        {
            if (default != _uiChunks) return;

            Log.Info("Loading Chunks Tab");
            _uiChunks = new UIChunks(_workLoad.Id);

            cbCStatuses.DataSource    = new BindingSource(_uiChunks.statuses, null);
            cbCStatuses.ValueMember   = "Key";
            cbCStatuses.DisplayMember = "Value";
            cbCStatuses.SelectedValue = _uiChunks.status  = -1;
            nmCOrdinal.Value          = _uiChunks.chunkId = -1;
            ChunksContent();
        }

        private void ChunksContent()
        {
            TsProgressIndeterminate(() =>
            {
                // dgvChunks.Rows.Clear();
                dgvChunks.Columns.Clear();
                cbCStatuses.DataBindings.Clear();
                nmCOrdinal.DataBindings.Clear();

                cbCStatuses.DataBindings.Add("SelectedValue", _uiChunks, "status");
                nmCOrdinal.DataBindings.Add("Value", _uiChunks, "chunkId");

                var dataTable = new DataTable();
                dataTable.Columns.Add("Chunk", typeof(int));
                dataTable.Columns.Add("Start", typeof(DateTime));
                dataTable.Columns.Add("End", typeof(DateTime));
                dataTable.Columns.Add("Duration", typeof(TimeSpan));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Error", typeof(string));

                //_uiChunks.LoadChunks(lv => dgvChunks.Rows.Add(lv));
                _uiChunks.LoadChunks(lv => dataTable.Rows.Add(lv));
                dgvChunks.DataSource = new DataView(dataTable);
            });
        }

        private void ItemsTab()
        {
            if (default != _uiItems) return;

            Log.Info("Loading Items Tab");
            _uiItems = new UIItems(_workLoad.Id);

            cbINames.DataSource    = new BindingSource(_uiItems.names, null);
            cbINames.ValueMember   = "Key";
            cbINames.DisplayMember = "Value";

            cbIStatuses.DataSource    = new BindingSource(_uiItems.statuses, null);
            cbIStatuses.ValueMember   = "Key";
            cbIStatuses.DisplayMember = "Value";

            cbITypes.DataSource    = new BindingSource(_uiItems.types, null);
            cbITypes.ValueMember   = "Key";
            cbITypes.DisplayMember = "Value";


            cbIStatuses.SelectedValue = _uiItems.status  = -1;
            cbINames.SelectedValue    = _uiItems.name    = "*";
            cbITypes.SelectedValue    = _uiItems.type    = -99;
            nmIOrdinal.Value          = _uiItems.chunkId = -1;

            ItemsContent();
        }

        private void ItemsContent()
        {
            TsProgressIndeterminate(() =>
            {
                cbINames.DataBindings.Clear();
                cbIStatuses.DataBindings.Clear();
                cbITypes.DataBindings.Clear();
                nmIOrdinal.DataBindings.Clear();

                cbINames.DataBindings.Add("SelectedValue", _uiItems, "name");
                cbIStatuses.DataBindings.Add("SelectedValue", _uiItems, "status");
                cbITypes.DataBindings.Add("SelectedValue", _uiItems, "type");
                nmIOrdinal.DataBindings.Add("Value", _uiItems, "chunkId");

                // dgvItems.Rows.Clear();
                dgvItems.Columns.Clear();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Chunk", typeof(int));
                dataTable.Columns.Add("Name", typeof(string));
                dataTable.Columns.Add("Start", typeof(DateTime));
                dataTable.Columns.Add("End", typeof(DateTime));
                dataTable.Columns.Add("Duration", typeof(TimeSpan));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Error", typeof(string));

                _uiItems.LoadItems(lv => dataTable.Rows.Add(lv));
                dgvItems.DataSource = new DataView(dataTable);
                // _uiItems.LoadItems(lv => dgvItems.Rows.Add(lv));
            });
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (null == parent)
            {
                Close();
                return;
            }

            Hide();
            parent.Show();
        }

        private void tabWorkload_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name.ToLower())
            {
                case "tabschema":
                    SchemaTab();
                    break;
                case "tabdetails":
                    DetailsTab();
                    break;
                case "tabprogress":
                    AnalysisTab(true);
                    break;
                case "tabchunks":
                    ChunksTab();
                    break;
                case "tabitems":
                    ItemsTab();
                    break;
            }
        }

        private void btnItemsFilter_Click(object sender, EventArgs e)
        {
            ItemsContent();
        }

        private void btnChunkFilter_Click(object sender, EventArgs e)
        {
            ChunksContent();
        }

        private void tabWorkload_Deselected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name.ToLower())
            {
                case "tabprogress":
                    if (tsAnalysis.IsDisposed) break;
                    tsAnalysis.Cancel();
                    tsAnalysis.Dispose();
                    TsProgressIncr(0);
                    break;
            }
        }

        private void cbPTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tsAnalysis.IsDisposed)
            {
                tsAnalysis.Cancel();
                tsAnalysis.Dispose();
                TsProgressIncr(0);
            }

            if (0 >= (analysisSleep =
                    (cbPTimer.SelectedItem is KeyValuePair<int, string> item ? item : default).Key)) return;
            AnalysisTab();
        }

        private void TsProgressIncr(int v = 1, int max = 0) =>
            Invoke(new Action(delegate
            {
                if (tsProgressBar.Style != ProgressBarStyle.Blocks) tsProgressBar.Style = ProgressBarStyle.Blocks;

                if (0 < max) tsProgressBar.Maximum = max;
                if (0 != v && tsProgressBar.Value == tsProgressBar.Maximum) return;
                if (0 == v) tsProgressBar.Value =  0;
                else tsProgressBar.Value        += v;
            }));

        private void TsProgressIndeterminate(Action action = null) => Invoke(new Action(async delegate
        {
            if (null != action)
            {
                TsProgressIndeterminate();
                await Task.Run(() => Invoke(action));
                TsProgressIndeterminate();
                return;
            }

            if (tsProgressBar.Style != ProgressBarStyle.Marquee)
            {
                tsProgressBar.Style                 = ProgressBarStyle.Marquee;
                tsProgressBar.MarqueeAnimationSpeed = 60;
            }
            else
            {
                tsProgressBar.Style                 = ProgressBarStyle.Blocks;
                tsProgressBar.MarqueeAnimationSpeed = 0;
            }
        }));

        private async Task SleepProgress(int milliseconds, CancellationToken token)
        {
            TsProgressIncr(0);
            if (0 >= milliseconds) return;
            var tick            = Convert.ToInt32(Math.Floor((double) Math.Abs(milliseconds / tsProgressBar.Maximum)));
            if (10 > tick) tick = 10;
            for (var i = 0; i < tsProgressBar.Maximum; i++)
            {
                TsProgressIncr();
                await Task.Delay(tick, token);
            }
        }

        private void btnTargetTest_Click(object sender, EventArgs e) => ConnectionTest(() => _uiDbSchema.TestTarget());

        private void btnSourceTest_Click(object sender, EventArgs e) => ConnectionTest(() => _uiDbSchema.TestSource());

        private void btnVocabTest_Click(object sender, EventArgs e) =>
            ConnectionTest(() => _uiDbSchema.TestVocabulary());

        private static void ConnectionTest(Action action)
        {
            try
            {
                action();
                MessageBox.Show(@"Connection Successful!", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // throw;
            }
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            SchemaType[] schemas = {SchemaType.SOURCE, SchemaType.TARGET, SchemaType.VOCABULARY};
            if (schemas.Length !=
                DB.Internal.Scalar<Dbschema, int>(@"count(1)",
                                                  @"Where workloadid = @wlid AND testsuccess = true AND schematype = ANY(@types)",
                                                  new
                                                  {
                                                      wlid  = _workLoad.Id,
                                                      types = schemas.Select(s => s.GetStringValue()).ToArray()
                                                  }))
            {
                MessageBox.Show(@"Schemas need to be set and tested!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }

            _workLoad.Cdmprocessed = _workLoad.Isrunning = _workLoad.intervene = false;
            _workLoad.Status       = Status.SCHEDULED;
            _workLoad.Save();
            btnQueue.Enabled = false;
            btnStop.Enabled  = true;
            MessageBox.Show(@"Workload Scheduled!", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show(
                    @"Are you sure you wish to stop the workload from being executed?",
                    @"Stop", MessageBoxButtons.OK, MessageBoxIcon.Question)) return;
            _workLoad.intervene = btnQueue.Enabled = true;
            btnStop.Enabled     = false;
            _workLoad.Save();
        }
    }
}