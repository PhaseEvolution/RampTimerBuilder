namespace RampTimerBuilder
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbIntervals = new System.Windows.Forms.ListBox();
            this.btnNewInterval = new System.Windows.Forms.Button();
            this.ofdAlarm = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowseForAudio = new System.Windows.Forms.Button();
            this.optStop = new System.Windows.Forms.RadioButton();
            this.optRepeatFinal = new System.Windows.Forms.RadioButton();
            this.optLoop = new System.Windows.Forms.RadioButton();
            this.lblProgramRunTime = new System.Windows.Forms.Label();
            this.txtNewInterval = new System.Windows.Forms.NumericUpDown();
            this.btnRemoveInterval = new System.Windows.Forms.Button();
            this.grpAlarmFile = new System.Windows.Forms.GroupBox();
            this.cboAudioFile = new System.Windows.Forms.ComboBox();
            this.grpCompleteAction = new System.Windows.Forms.GroupBox();
            this.grpIntervals = new System.Windows.Forms.GroupBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.grpRampProgress = new System.Windows.Forms.GroupBox();
            this.lblCurrentIntervalRunTime = new System.Windows.Forms.Label();
            this.lblIntervalRemainingTime = new System.Windows.Forms.Label();
            this.lblRemainingRunTime = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSavesAndPresets = new System.Windows.Forms.ComboBox();
            this.grpSavedPrograms = new System.Windows.Forms.GroupBox();
            this.btnDeletePreset = new System.Windows.Forms.Button();
            this.grpPlayControls = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.grpBackgroundAudio = new System.Windows.Forms.GroupBox();
            this.cboBGAudio = new System.Windows.Forms.ComboBox();
            this.btnBrowseForBGAudio = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ofdBGAudio = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewInterval)).BeginInit();
            this.grpAlarmFile.SuspendLayout();
            this.grpCompleteAction.SuspendLayout();
            this.grpIntervals.SuspendLayout();
            this.grpRampProgress.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpSavedPrograms.SuspendLayout();
            this.grpPlayControls.SuspendLayout();
            this.grpBackgroundAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbIntervals
            // 
            this.lbIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIntervals.FormattingEnabled = true;
            this.lbIntervals.ItemHeight = 20;
            this.lbIntervals.Location = new System.Drawing.Point(13, 28);
            this.lbIntervals.Name = "lbIntervals";
            this.lbIntervals.Size = new System.Drawing.Size(101, 284);
            this.lbIntervals.TabIndex = 0;
            // 
            // btnNewInterval
            // 
            this.btnNewInterval.FlatAppearance.BorderSize = 0;
            this.btnNewInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewInterval.Image = ((System.Drawing.Image)(resources.GetObject("btnNewInterval.Image")));
            this.btnNewInterval.Location = new System.Drawing.Point(13, 348);
            this.btnNewInterval.Name = "btnNewInterval";
            this.btnNewInterval.Size = new System.Drawing.Size(75, 73);
            this.btnNewInterval.TabIndex = 1;
            this.btnNewInterval.UseVisualStyleBackColor = true;
            this.btnNewInterval.Click += new System.EventHandler(this.btnNewInterval_Click);
            // 
            // ofdAlarm
            // 
            this.ofdAlarm.Filter = "wav files (*.wav)|*.wav";
            // 
            // btnBrowseForAudio
            // 
            this.btnBrowseForAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseForAudio.FlatAppearance.BorderSize = 0;
            this.btnBrowseForAudio.Location = new System.Drawing.Point(510, 25);
            this.btnBrowseForAudio.Name = "btnBrowseForAudio";
            this.btnBrowseForAudio.Size = new System.Drawing.Size(48, 35);
            this.btnBrowseForAudio.TabIndex = 10;
            this.btnBrowseForAudio.Text = "...";
            this.btnBrowseForAudio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowseForAudio.UseVisualStyleBackColor = true;
            this.btnBrowseForAudio.Click += new System.EventHandler(this.btnBrowseForAudio_Click);
            // 
            // optStop
            // 
            this.optStop.AutoSize = true;
            this.optStop.Checked = true;
            this.optStop.Location = new System.Drawing.Point(16, 31);
            this.optStop.Name = "optStop";
            this.optStop.Size = new System.Drawing.Size(68, 24);
            this.optStop.TabIndex = 11;
            this.optStop.TabStop = true;
            this.optStop.Text = "Stop";
            this.optStop.UseVisualStyleBackColor = true;
            // 
            // optRepeatFinal
            // 
            this.optRepeatFinal.AutoSize = true;
            this.optRepeatFinal.Location = new System.Drawing.Point(16, 91);
            this.optRepeatFinal.Name = "optRepeatFinal";
            this.optRepeatFinal.Size = new System.Drawing.Size(181, 24);
            this.optRepeatFinal.TabIndex = 12;
            this.optRepeatFinal.Text = "Repeat Final Interval";
            this.optRepeatFinal.UseVisualStyleBackColor = true;
            // 
            // optLoop
            // 
            this.optLoop.AutoSize = true;
            this.optLoop.Location = new System.Drawing.Point(16, 61);
            this.optLoop.Name = "optLoop";
            this.optLoop.Size = new System.Drawing.Size(91, 24);
            this.optLoop.TabIndex = 13;
            this.optLoop.Text = "Loop All";
            this.optLoop.UseVisualStyleBackColor = true;
            // 
            // lblProgramRunTime
            // 
            this.lblProgramRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgramRunTime.AutoSize = true;
            this.lblProgramRunTime.Location = new System.Drawing.Point(20, 35);
            this.lblProgramRunTime.Name = "lblProgramRunTime";
            this.lblProgramRunTime.Size = new System.Drawing.Size(186, 20);
            this.lblProgramRunTime.TabIndex = 16;
            this.lblProgramRunTime.Text = "Total Run Time: 00:00:00";
            // 
            // txtNewInterval
            // 
            this.txtNewInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewInterval.Location = new System.Drawing.Point(13, 316);
            this.txtNewInterval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtNewInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNewInterval.Name = "txtNewInterval";
            this.txtNewInterval.Size = new System.Drawing.Size(101, 26);
            this.txtNewInterval.TabIndex = 17;
            this.txtNewInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRemoveInterval
            // 
            this.btnRemoveInterval.FlatAppearance.BorderSize = 0;
            this.btnRemoveInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveInterval.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveInterval.Image")));
            this.btnRemoveInterval.Location = new System.Drawing.Point(94, 348);
            this.btnRemoveInterval.Name = "btnRemoveInterval";
            this.btnRemoveInterval.Size = new System.Drawing.Size(75, 73);
            this.btnRemoveInterval.TabIndex = 18;
            this.btnRemoveInterval.UseVisualStyleBackColor = true;
            this.btnRemoveInterval.Click += new System.EventHandler(this.btnRemoveInterval_Click);
            // 
            // grpAlarmFile
            // 
            this.grpAlarmFile.Controls.Add(this.cboAudioFile);
            this.grpAlarmFile.Controls.Add(this.btnBrowseForAudio);
            this.grpAlarmFile.Location = new System.Drawing.Point(12, 113);
            this.grpAlarmFile.Name = "grpAlarmFile";
            this.grpAlarmFile.Size = new System.Drawing.Size(569, 78);
            this.grpAlarmFile.TabIndex = 19;
            this.grpAlarmFile.TabStop = false;
            this.grpAlarmFile.Text = "Alarm File:";
            // 
            // cboAudioFile
            // 
            this.cboAudioFile.FormattingEnabled = true;
            this.cboAudioFile.Location = new System.Drawing.Point(6, 27);
            this.cboAudioFile.Name = "cboAudioFile";
            this.cboAudioFile.Size = new System.Drawing.Size(498, 28);
            this.cboAudioFile.TabIndex = 11;
            this.cboAudioFile.Leave += new System.EventHandler(this.ValidateFileType);
            // 
            // grpCompleteAction
            // 
            this.grpCompleteAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCompleteAction.Controls.Add(this.optStop);
            this.grpCompleteAction.Controls.Add(this.optRepeatFinal);
            this.grpCompleteAction.Controls.Add(this.optLoop);
            this.grpCompleteAction.Location = new System.Drawing.Point(215, 463);
            this.grpCompleteAction.Name = "grpCompleteAction";
            this.grpCompleteAction.Size = new System.Drawing.Size(366, 143);
            this.grpCompleteAction.TabIndex = 20;
            this.grpCompleteAction.TabStop = false;
            this.grpCompleteAction.Text = "Action on Complete:";
            // 
            // grpIntervals
            // 
            this.grpIntervals.Controls.Add(this.btnMoveDown);
            this.grpIntervals.Controls.Add(this.btnMoveUp);
            this.grpIntervals.Controls.Add(this.lbIntervals);
            this.grpIntervals.Controls.Add(this.txtNewInterval);
            this.grpIntervals.Controls.Add(this.btnNewInterval);
            this.grpIntervals.Controls.Add(this.btnRemoveInterval);
            this.grpIntervals.Location = new System.Drawing.Point(12, 281);
            this.grpIntervals.Name = "grpIntervals";
            this.grpIntervals.Size = new System.Drawing.Size(182, 431);
            this.grpIntervals.TabIndex = 21;
            this.grpIntervals.TabStop = false;
            this.grpIntervals.Text = "Intervals (In Minutes)";
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.FlatAppearance.BorderSize = 0;
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(120, 191);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(54, 102);
            this.btnMoveDown.TabIndex = 20;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.FlatAppearance.BorderSize = 0;
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(120, 66);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(54, 102);
            this.btnMoveUp.TabIndex = 19;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // grpRampProgress
            // 
            this.grpRampProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRampProgress.Controls.Add(this.lblCurrentIntervalRunTime);
            this.grpRampProgress.Controls.Add(this.lblIntervalRemainingTime);
            this.grpRampProgress.Controls.Add(this.lblRemainingRunTime);
            this.grpRampProgress.Controls.Add(this.lblProgramRunTime);
            this.grpRampProgress.Location = new System.Drawing.Point(215, 281);
            this.grpRampProgress.Name = "grpRampProgress";
            this.grpRampProgress.Size = new System.Drawing.Size(366, 176);
            this.grpRampProgress.TabIndex = 22;
            this.grpRampProgress.TabStop = false;
            this.grpRampProgress.Text = "Ramp Progress:";
            // 
            // lblCurrentIntervalRunTime
            // 
            this.lblCurrentIntervalRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentIntervalRunTime.AutoSize = true;
            this.lblCurrentIntervalRunTime.Location = new System.Drawing.Point(20, 103);
            this.lblCurrentIntervalRunTime.Name = "lblCurrentIntervalRunTime";
            this.lblCurrentIntervalRunTime.Size = new System.Drawing.Size(203, 20);
            this.lblCurrentIntervalRunTime.TabIndex = 19;
            this.lblCurrentIntervalRunTime.Text = "Interval Run Time: 00:00:00";
            // 
            // lblIntervalRemainingTime
            // 
            this.lblIntervalRemainingTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIntervalRemainingTime.AutoSize = true;
            this.lblIntervalRemainingTime.Location = new System.Drawing.Point(20, 137);
            this.lblIntervalRemainingTime.Name = "lblIntervalRemainingTime";
            this.lblIntervalRemainingTime.Size = new System.Drawing.Size(283, 20);
            this.lblIntervalRemainingTime.TabIndex = 18;
            this.lblIntervalRemainingTime.Text = "Interval Remaining Run Time: 00:00:00";
            // 
            // lblRemainingRunTime
            // 
            this.lblRemainingRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainingRunTime.AutoSize = true;
            this.lblRemainingRunTime.Location = new System.Drawing.Point(20, 69);
            this.lblRemainingRunTime.Name = "lblRemainingRunTime";
            this.lblRemainingRunTime.Size = new System.Drawing.Size(266, 20);
            this.lblRemainingRunTime.TabIndex = 17;
            this.lblRemainingRunTime.Text = "Total Remaining Run Time: 00:00:00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 33);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCurrentProgramToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveCurrentProgramToolStripMenuItem
            // 
            this.saveCurrentProgramToolStripMenuItem.Name = "saveCurrentProgramToolStripMenuItem";
            this.saveCurrentProgramToolStripMenuItem.Size = new System.Drawing.Size(270, 30);
            this.saveCurrentProgramToolStripMenuItem.Text = "Save Current Program";
            this.saveCurrentProgramToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentProgramToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cboSavesAndPresets
            // 
            this.cboSavesAndPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavesAndPresets.FormattingEnabled = true;
            this.cboSavesAndPresets.Location = new System.Drawing.Point(6, 29);
            this.cboSavesAndPresets.Name = "cboSavesAndPresets";
            this.cboSavesAndPresets.Size = new System.Drawing.Size(498, 28);
            this.cboSavesAndPresets.TabIndex = 24;
            this.cboSavesAndPresets.SelectedIndexChanged += new System.EventHandler(this.cboSavesAndPresets_SelectedIndexChanged);
            // 
            // grpSavedPrograms
            // 
            this.grpSavedPrograms.Controls.Add(this.btnDeletePreset);
            this.grpSavedPrograms.Controls.Add(this.cboSavesAndPresets);
            this.grpSavedPrograms.Location = new System.Drawing.Point(12, 36);
            this.grpSavedPrograms.Name = "grpSavedPrograms";
            this.grpSavedPrograms.Size = new System.Drawing.Size(569, 72);
            this.grpSavedPrograms.TabIndex = 25;
            this.grpSavedPrograms.TabStop = false;
            this.grpSavedPrograms.Text = "Presets and Saved Programs:";
            // 
            // btnDeletePreset
            // 
            this.btnDeletePreset.Enabled = false;
            this.btnDeletePreset.FlatAppearance.BorderSize = 0;
            this.btnDeletePreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePreset.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePreset.Image")));
            this.btnDeletePreset.Location = new System.Drawing.Point(510, 18);
            this.btnDeletePreset.Name = "btnDeletePreset";
            this.btnDeletePreset.Size = new System.Drawing.Size(53, 48);
            this.btnDeletePreset.TabIndex = 25;
            this.btnDeletePreset.UseVisualStyleBackColor = true;
            this.btnDeletePreset.Click += new System.EventHandler(this.btnDeletePreset_Click);
            // 
            // grpPlayControls
            // 
            this.grpPlayControls.Controls.Add(this.btnStop);
            this.grpPlayControls.Controls.Add(this.btnPause);
            this.grpPlayControls.Controls.Add(this.btnPlay);
            this.grpPlayControls.Location = new System.Drawing.Point(215, 612);
            this.grpPlayControls.Name = "grpPlayControls";
            this.grpPlayControls.Size = new System.Drawing.Size(366, 100);
            this.grpPlayControls.TabIndex = 26;
            this.grpPlayControls.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(245, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 68);
            this.btnStop.TabIndex = 11;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.Location = new System.Drawing.Point(125, 22);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(98, 68);
            this.btnPause.TabIndex = 10;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(9, 22);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(98, 68);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // grpBackgroundAudio
            // 
            this.grpBackgroundAudio.Controls.Add(this.cboBGAudio);
            this.grpBackgroundAudio.Controls.Add(this.btnBrowseForBGAudio);
            this.grpBackgroundAudio.Location = new System.Drawing.Point(12, 197);
            this.grpBackgroundAudio.Name = "grpBackgroundAudio";
            this.grpBackgroundAudio.Size = new System.Drawing.Size(569, 78);
            this.grpBackgroundAudio.TabIndex = 20;
            this.grpBackgroundAudio.TabStop = false;
            this.grpBackgroundAudio.Text = "Background Audio:";
            // 
            // cboBGAudio
            // 
            this.cboBGAudio.FormattingEnabled = true;
            this.cboBGAudio.Location = new System.Drawing.Point(6, 27);
            this.cboBGAudio.Name = "cboBGAudio";
            this.cboBGAudio.Size = new System.Drawing.Size(498, 28);
            this.cboBGAudio.TabIndex = 11;
            this.cboBGAudio.Leave += new System.EventHandler(this.ValidateFileType);
            // 
            // btnBrowseForBGAudio
            // 
            this.btnBrowseForBGAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseForBGAudio.FlatAppearance.BorderSize = 0;
            this.btnBrowseForBGAudio.Location = new System.Drawing.Point(510, 25);
            this.btnBrowseForBGAudio.Name = "btnBrowseForBGAudio";
            this.btnBrowseForBGAudio.Size = new System.Drawing.Size(48, 35);
            this.btnBrowseForBGAudio.TabIndex = 10;
            this.btnBrowseForBGAudio.Text = "...";
            this.btnBrowseForBGAudio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowseForBGAudio.UseVisualStyleBackColor = true;
            this.btnBrowseForBGAudio.Click += new System.EventHandler(this.btnBrowseForAudio_Click);
            // 
            // ofdBGAudio
            // 
            this.ofdBGAudio.Filter = "wav files (*.wav)|*.wav";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 719);
            this.Controls.Add(this.grpBackgroundAudio);
            this.Controls.Add(this.grpPlayControls);
            this.Controls.Add(this.grpSavedPrograms);
            this.Controls.Add(this.grpRampProgress);
            this.Controls.Add(this.grpIntervals);
            this.Controls.Add(this.grpCompleteAction);
            this.Controls.Add(this.grpAlarmFile);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Ramp Timer Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNewInterval)).EndInit();
            this.grpAlarmFile.ResumeLayout(false);
            this.grpCompleteAction.ResumeLayout(false);
            this.grpCompleteAction.PerformLayout();
            this.grpIntervals.ResumeLayout(false);
            this.grpRampProgress.ResumeLayout(false);
            this.grpRampProgress.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpSavedPrograms.ResumeLayout(false);
            this.grpPlayControls.ResumeLayout(false);
            this.grpBackgroundAudio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbIntervals;
        private System.Windows.Forms.Button btnNewInterval;
        private System.Windows.Forms.OpenFileDialog ofdAlarm;
        private System.Windows.Forms.Button btnBrowseForAudio;
        private System.Windows.Forms.RadioButton optStop;
        private System.Windows.Forms.RadioButton optRepeatFinal;
        private System.Windows.Forms.RadioButton optLoop;
        private System.Windows.Forms.Label lblProgramRunTime;
        private System.Windows.Forms.NumericUpDown txtNewInterval;
        private System.Windows.Forms.Button btnRemoveInterval;
        private System.Windows.Forms.GroupBox grpAlarmFile;
        private System.Windows.Forms.GroupBox grpCompleteAction;
        private System.Windows.Forms.GroupBox grpIntervals;
        private System.Windows.Forms.GroupBox grpRampProgress;
        private System.Windows.Forms.Label lblCurrentIntervalRunTime;
        private System.Windows.Forms.Label lblIntervalRemainingTime;
        private System.Windows.Forms.Label lblRemainingRunTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboSavesAndPresets;
        private System.Windows.Forms.GroupBox grpSavedPrograms;
        private System.Windows.Forms.GroupBox grpPlayControls;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ComboBox cboAudioFile;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.GroupBox grpBackgroundAudio;
        private System.Windows.Forms.ComboBox cboBGAudio;
        private System.Windows.Forms.Button btnBrowseForBGAudio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog ofdBGAudio;
        private System.Windows.Forms.Button btnDeletePreset;
    }
}

