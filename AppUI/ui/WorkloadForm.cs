﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppUI.models;
using DBMS.models;
using Util;
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
                Name            = Guid.NewGuid().ToString(),
                FilesLocked     = false,
                SourceProcessed = false,
                CdmLoaded       = false,
                ChunksSetup     = false,
                ChunksLoaded    = false,
                CdmProcessed    = false,
                IsRunning       = false,
                MaxParallels    = 3,
            };
            nmCOrdinal.Maximum = nmIOrdinal.Maximum = int.MaxValue;

            DetailsTab();
        }

        private void DetailsTab()
        {
            _uiWorkLoad = new UIWorkLoad(_workLoad);
            tbWlName.DataBindings.Clear();
            dtWlDate.DataBindings.Clear();

            tbWlName.DataBindings.Add("Text", _uiWorkLoad, "Name");
            dtWlDate.DataBindings.Add("Value", _uiWorkLoad, "ReleaseDate");
        }

        private void SchemaTab()
        {
            _uiDbSchema = new UIDbSchema(_workLoad.Id);
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

        private void AnalysisTab(bool tabCall = false)
        {
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
                    Log.Info("Start Analysis Loop!!");
                    ctAnalysis.ThrowIfCancellationRequested();
                    while (true)
                    {
                        //TsProgressIncr(0);
                        if (ctAnalysis.IsCancellationRequested) ctAnalysis.ThrowIfCancellationRequested();

                        // TsProgressIncr(50);
                        Log.Info("Start sleeper!");
                        await SleepProgress(analysisSleep, tsAnalysis.Token);
                        Log.Info("Am awake again!!");
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
                UIAnalysis.LoadAnalysis(lv => dgvProgress.Rows.Add(lv));
            }));
        }

        private void ChunksTab()
        {
            if (default != _uiChunks) return;

            Log.Info("Loading Chunks Tab");
            _uiChunks = new UIChunks();

            cbCStatuses.DataSource    = new BindingSource(_uiChunks.statuses, null);
            cbCStatuses.ValueMember   = "Key";
            cbCStatuses.DisplayMember = "Value";
            cbCStatuses.SelectedValue = _uiChunks.status  = -1;
            nmCOrdinal.Value          = _uiChunks.chunkId = -1;
            ChunksContent();
        }

        private void ChunksContent()
        {
            dgvChunks.Rows.Clear();
            cbCStatuses.DataBindings.Clear();
            nmCOrdinal.DataBindings.Clear();

            cbCStatuses.DataBindings.Add("SelectedValue", _uiChunks, "status");
            nmCOrdinal.DataBindings.Add("Value", _uiChunks, "chunkId");
            _uiChunks.LoadChunks(lv => dgvChunks.Rows.Add(lv));
        }

        private void ItemsTab()
        {
            if (default != _uiItems) return;

            Log.Info("Loading Items Tab");
            _uiItems = new UIItems();

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
            cbINames.DataBindings.Clear();
            cbIStatuses.DataBindings.Clear();
            cbITypes.DataBindings.Clear();
            nmIOrdinal.DataBindings.Clear();

            cbINames.DataBindings.Add("SelectedValue", _uiItems, "name");
            cbIStatuses.DataBindings.Add("SelectedValue", _uiItems, "status");
            cbITypes.DataBindings.Add("SelectedValue", _uiItems, "type");
            nmIOrdinal.DataBindings.Add("Value", _uiItems, "chunkId");

            dgvItems.Rows.Clear();
            _uiItems.LoadItems(lv => dgvItems.Rows.Add(lv));
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
                    tsAnalysis.Cancel();
                    tsAnalysis.Dispose();
                    break;
            }
        }

        private void cbPTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tsAnalysis.IsDisposed)
            {
                tsAnalysis.Cancel();
                tsAnalysis.Dispose();
            }

            if (0 >= (analysisSleep =
                    (cbPTimer.SelectedItem is KeyValuePair<int, string> item ? item : default).Key)) return;
            AnalysisTab();
        }

        private void TsProgressIncr(int v = 1, int max = 0)
        {
            Log.Info("Am Ticking!");
            Invoke(new Action(delegate
            {
                if (0 < max) tsProgressBar.Maximum = max;
                if (0 == v) tsProgressBar.Value =  0;
                else tsProgressBar.Value        += v;
            }));
        }

        private async Task SleepProgress(int milliseconds, CancellationToken token)
        {
            if (0 >= milliseconds) return;
            int tick            = Math.Abs(milliseconds / 100);
            if (10 > tick) tick = 10;
            var timer           = new Timer();
            timer.Enabled = true;
            timer.Start();
            timer.Interval = tick;
            Log.Info("Start Ticker! Tick: {tick}", tick);
            timer.Tick += (s, e) => Log.Info("Am ticking!");// TsProgressIncr();
            await Task.Delay(milliseconds, token);
        }
    }
}