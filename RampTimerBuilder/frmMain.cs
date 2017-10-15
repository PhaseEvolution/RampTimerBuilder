using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RampTimerBuilder
{
    public partial class frmMain : Form
    {

        #region  global variables
        int intSleepTime = 1000;
        int intCurrentInterval;
        int intTotalTimeEllapsed;
        int intTotalRunTime;
        int intCurrentRunTime;
        bool boolStopped = false;
        bool boolPaused = false;
        string AudioFile;
        Thread[] threadPoolIntervals = new Thread[0];
        JukeBox2 jbBGAudio;
        JukeBox2 jbIntervalAudio;
        About about = new About();
        #endregion

        #region delegates
        delegate void DelegateCBOText(ComboBox cbo);
        delegate void DelegateControllAccess();
        delegate void DelegateUpdateControl(Control control, bool enabled);
        public delegate void DelegateSetLabelText(Label label, string text);
        #endregion  

        #region unpack audio files, build form, and populate controls
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //build form
            PopulateAudioDropDown();
            PopulatePresetDropdown();

            //unpack resources
            UnpackResources();
        }

        //unpack to localappdata only if files do not exist
        private static void UnpackResources()
        {
            var outputDir = Environment.GetEnvironmentVariable("LocalAppData") + "\\RampTimerBuilder";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            var soundFiles = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var file in soundFiles)
            {
                if (!file.Contains(".wav") && !file.Contains(".mp3")) continue;
                if (File.Exists(outputDir + "\\" + file)) continue;
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(file))
                {
                    using (FileStream fileStream = new FileStream(Path.Combine(outputDir, file), FileMode.Create))
                    {
                        for (int i = 0; i < stream.Length; i++)
                        {
                            fileStream.WriteByte((byte)stream.ReadByte());
                        }
                        fileStream.Close();
                    }
                }
            }
        }

        private void PopulateAudioDropDown()
        {
            var appDir = Environment.GetEnvironmentVariable("LocalAppData") + "\\RampTimerBuilder";
            if (!Directory.Exists(appDir))
                Directory.CreateDirectory(appDir);

            var soundFiles = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            // No wildcard support with Directory methods, must concat.
            var unpackedFiles = Directory.EnumerateFiles(appDir, "*.wav").Concat(Directory.GetFiles(appDir, "*.mp3"));
            foreach (var file in unpackedFiles)
            {
                var fiFile = new FileInfo(file);
                if (Array.IndexOf(soundFiles, fiFile.Name) > -1) continue;
                Array.Resize(ref soundFiles, soundFiles.Length + 1);
                soundFiles[soundFiles.Length - 1] = fiFile.Name;
            }
            Array.Sort(soundFiles);

            foreach (var file in soundFiles)
            {
                var audioItem = new AudioItem()
                {
                    Name = file.ToString().Replace("RampTimerBuilder.Alarms.", "").Replace("RampTimerBuilder.BGAudio.", ""),
                    Value = appDir + "\\" + file.ToString()
                };

                if (file.ToString().Contains("Alarms"))
                {
                    cboAudioFile.Items.Add(audioItem);
                    cboAudioFile.DisplayMember = "Name";
                }
                else if (file.ToString().Contains("BGAudio"))
                {
                    cboBGAudio.Items.Add(audioItem);
                    cboBGAudio.DisplayMember = "Name";
                }
            }
        }

        private void PopulatePresetDropdown()
        {
            cboSavesAndPresets.Items.Clear();
            var savesAndPresets = Reg.Get_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets");
            if (savesAndPresets == null)
            {
                var presets = new String[] { };
                for (var i = 2; i <= 6; i++)
                {
                    Array.Resize(ref presets, presets.Length + 1);
                    presets[presets.Length - 1] = BaseIntervalBuilder.BuildBaseIntervalString(i);
                }
                Reg.Set_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets", presets, Microsoft.Win32.RegistryValueKind.MultiString);
            }
            savesAndPresets = Reg.Get_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets");

            foreach (var value in savesAndPresets)
            {
                if (value.Split(new char[] { '~' })[0].Trim().Length == 0) continue;
                var presetItem = new PresetItem();
                //presetItem.BuiltIn = int.Parse(value.Split(new char[] { '~' })[5]) == 1;
                cboSavesAndPresets.Items.Add(value.Split(new char[] { '~' })[0]);
            }
            cboSavesAndPresets.Items.Insert(0, "");
        }
        #endregion

        #region add / remove / update intervals
        private void btnNewInterval_Click(object sender, EventArgs e)
        {
            var currentIndex = lbIntervals.SelectedIndex;
            if (txtNewInterval.Value == 0) return;
            if (currentIndex == -1)
            {
                lbIntervals.Items.Add(txtNewInterval.Value);
                lbIntervals.SelectedIndex = lbIntervals.Items.Count - 1;
            }
            else
            {
                lbIntervals.Items.Insert(lbIntervals.SelectedIndex + 1, txtNewInterval.Value);
                lbIntervals.SelectedIndex = currentIndex + 1;
            }

        }

        private void btnRemoveInterval_Click(object sender, EventArgs e)
        {
            var currentIndex = lbIntervals.SelectedIndex;
            if (currentIndex == -1) return;
            lbIntervals.Items.Remove(lbIntervals.SelectedItem);
            if (currentIndex == 0)
            {
                if (lbIntervals.Items.Count > 0)
                    lbIntervals.SelectedIndex = 0;
            }
            else
                lbIntervals.SelectedIndex = currentIndex - 1;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lbIntervals.SelectedIndex < 1) return;
            var selectedItem = lbIntervals.SelectedItem;
            var previousItem = lbIntervals.Items[lbIntervals.SelectedIndex - 1];
            lbIntervals.Items[lbIntervals.SelectedIndex] = previousItem;
            lbIntervals.Items[lbIntervals.SelectedIndex - 1] = selectedItem;
            lbIntervals.SelectedIndex--;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lbIntervals.SelectedIndex >= lbIntervals.Items.Count - 1) return;
            var selectedItem = lbIntervals.SelectedItem;
            var nextItem = lbIntervals.Items[lbIntervals.SelectedIndex + 1];
            lbIntervals.Items[lbIntervals.SelectedIndex] = nextItem;
            lbIntervals.Items[lbIntervals.SelectedIndex + 1] = selectedItem;
            lbIntervals.SelectedIndex++;

        }
        #endregion

        #region browse for audio
        private void btnBrowseForAudio_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd = sender == btnBrowseForAudio ? ofdAlarm : ofdBGAudio;
            var drOpenFile = ofd.ShowDialog();
            if (drOpenFile != DialogResult.OK) return;

            cboAudioFile.Text = sender == btnBrowseForAudio ? ofd.FileName : cboAudioFile.Text;
            cboBGAudio.Text = sender == btnBrowseForBGAudio ? ofd.FileName : cboBGAudio.Text;

            // Add an audio item to the appropriate combobox.
            var comboBox = sender == btnBrowseForBGAudio ? cboBGAudio : cboAudioFile;
            AudioItem item = new AudioItem();
            item.Value = comboBox.Text;
            item.Name = Path.GetFileName(ofd.FileName);

            if (!comboBox.Items.Contains(item))
            {
                comboBox.Items.Add(item);
                comboBox.SelectedItem = item;
            }
        }
        #endregion

        #region play, pause, stop controls
        private void btnPlay_Click(object sender, EventArgs e)
        {
            //make sure that an audio file was selected and that one or more intervals have been created
            if (cboAudioFile.SelectedItem == null) return;
            if (lbIntervals.Items.Count == 0) return;

            //if no intervals selected or stop was clicked, reset to top of interval list
            if (boolStopped || lbIntervals.SelectedIndex == -1)
                lbIntervals.SelectedIndex = 0;

            //store total runtime for label updating
            intTotalRunTime = GetRunTime();

            //reset pause and stop states
            boolPaused = false;
            boolStopped = false;

            //cross-thread calls to enable and disable controls
            //enable pause and stop buttons, disable all other controls while playing
            ToggleControlAccess(btnPause, true);
            ToggleControlAccess(btnStop, true);
            ToggleControlAccess(btnPlay, false);
            ToggleControlAccess(btnBrowseForAudio, false);
            ToggleControlAccess(btnBrowseForBGAudio, false);
            ToggleControlAccess(lbIntervals, false);
            ToggleControlAccess(btnNewInterval, false);
            ToggleControlAccess(btnRemoveInterval, false);
            ToggleControlAccess(optLoop, false);
            ToggleControlAccess(optRepeatFinal, false);
            ToggleControlAccess(optStop, false);
            ToggleControlAccess(cboAudioFile, false);
            ToggleControlAccess(cboBGAudio, false);
            ToggleControlAccess(cboSavesAndPresets, false);
            ToggleControlAccess(txtNewInterval, false);

            if (cboBGAudio.Text.Trim().Length > 0)
            {
                if (jbBGAudio == null || !jbBGAudio.Playing)
                    jbBGAudio = jbBGAudio == null ? new JukeBox2() : jbBGAudio;

                jbBGAudio.FileName = ((AudioItem)cboBGAudio.SelectedItem).Value;
                jbBGAudio.TrackName = "BGAudio";
                jbBGAudio.Play(true);
            }

            PlayInterval(int.Parse(lbIntervals.SelectedItem.ToString()));
            var intervals = lbIntervals.Items;
        }

        private void PlayInterval(int interval)
        {
            try
            {
                for (var i = 0; i < threadPoolIntervals.Length; i++)
                {
                    if (threadPoolIntervals[i] == null) continue;
                    threadPoolIntervals[i].Abort();
                    threadPoolIntervals[i] = null;
                }
                var threadIntervalAudio = new Thread(new ThreadStart(OnTimedEvent));
                Array.Resize(ref threadPoolIntervals, threadPoolIntervals.Length + 1);
                threadPoolIntervals[threadPoolIntervals.Length - 1] = threadIntervalAudio;
                threadIntervalAudio.Start();
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
        }

        private void IncrimentListBox()
        {
            if (lbIntervals.SelectedIndex < lbIntervals.Items.Count - 1)
            {
                lbIntervals.SelectedIndex += 1;
                lbIntervals.Refresh();
                PlayInterval(int.Parse(lbIntervals.SelectedItem.ToString()));
            }
            else
            {
                ResetOrStop();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            boolPaused = true;
            if (btnPlay.InvokeRequired)
                btnPlay.Invoke(new DelegateUpdateControl(ToggleControlAccess), btnPlay, boolPaused);
            else
                ToggleControlAccess(btnPlay, boolPaused);

            if (lbIntervals.InvokeRequired)
                lbIntervals.Invoke(new DelegateUpdateControl(ToggleControlAccess), lbIntervals, boolPaused);
            else
                ToggleControlAccess(lbIntervals, boolPaused);

            StopAudio();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            boolStopped = true;
            boolPaused = false;

            ToggleControlAccess(btnNewInterval, true);
            ToggleControlAccess(btnRemoveInterval, true);
            ToggleControlAccess(btnPlay, true);
            ToggleControlAccess(btnPause, false);
            ToggleControlAccess(btnStop, false);
            ToggleControlAccess(btnBrowseForAudio, true);
            ToggleControlAccess(btnBrowseForBGAudio, true);
            ToggleControlAccess(lbIntervals, true);
            ToggleControlAccess(optLoop, true);
            ToggleControlAccess(optRepeatFinal, true);
            ToggleControlAccess(optStop, true);
            ToggleControlAccess(cboAudioFile, true);
            ToggleControlAccess(cboBGAudio, true);
            ToggleControlAccess(cboSavesAndPresets, true);
            ToggleControlAccess(txtNewInterval, true);

            StopAudio();
        }

        private void StopAudio()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (jbBGAudio != null) jbBGAudio.StopPlaying();
                if (jbIntervalAudio != null) jbIntervalAudio.StopPlaying();
            }));
        }
        #endregion

        #region control reads/updates
        private void ToggleControlAccess(Control control, bool enabled)
        {
            if (control.InvokeRequired)
                control.Invoke(new DelegateUpdateControl(ToggleControlAccess), control, enabled);
            else
                control.Enabled = enabled;
        }


        public void SetText(Label label, string text)
        {
            label.Text = text;
        }

        private void ResetOrStop()
        {
            intCurrentInterval = 0;
            intTotalTimeEllapsed = 0;
            intCurrentRunTime = 0;

            if (lblRemainingRunTime.InvokeRequired)
                lblRemainingRunTime.Invoke(new DelegateSetLabelText(SetText), lblRemainingRunTime, "Total Remaining Time: 00:00:00");
            else
                lblRemainingRunTime.Text = "Total Remaining Time: 00:00:00";

            if (lblIntervalRemainingTime.InvokeRequired)
                lblIntervalRemainingTime.Invoke(new DelegateSetLabelText(SetText), lblIntervalRemainingTime, "Interval Remaining Run Time: 00:00:00");
            else
                lblIntervalRemainingTime.Text = "Interval Remaining Run Time: 00:00:00";

            if (lblCurrentIntervalRunTime.InvokeRequired)
                lblCurrentIntervalRunTime.Invoke(new DelegateSetLabelText(SetText), lblCurrentIntervalRunTime, "Interval Run Time: 00:00:00");
            else
                lblCurrentIntervalRunTime.Text = "Interval Run Time: 00:00:00";

            if (lblProgramRunTime.InvokeRequired)
                lblProgramRunTime.Invoke(new DelegateSetLabelText(SetText), lblProgramRunTime, "Total Run Time: 00:00:00");
            else
                lblProgramRunTime.Text = "Total Run Time: 00:00:00";

            if (lbIntervals.InvokeRequired)
                lbIntervals.Invoke(new DelegateUpdateControl(ToggleControlAccess), lbIntervals, boolStopped);
            else
                ToggleControlAccess(lbIntervals, boolStopped);

            if (boolStopped) return;

            if (optLoop.Checked)
            {
                lbIntervals.SelectedIndex = 0;
                btnPlay_Click(null, null);
            }
            else if (optRepeatFinal.Checked)
            {
                btnPlay_Click(null, null);
            }
            else
            {
                btnStop_Click(null, null);
            }
        }

        private void UpdateLabels()
        {
            TimeSpan totSpan = TimeSpan.FromSeconds(intTotalTimeEllapsed);
            var formattedTotalRunTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    totSpan.Hours,
                                    totSpan.Minutes,
                                    totSpan.Seconds);

            TimeSpan totRemainingSpan = TimeSpan.FromSeconds(intTotalRunTime - intTotalTimeEllapsed);
            var formattedRemainingRunTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    totRemainingSpan.Hours,
                                    totRemainingSpan.Minutes,
                                    totRemainingSpan.Seconds);

            TimeSpan intervalRunSpan = TimeSpan.FromSeconds(intCurrentRunTime);
            string formattedCurrentIntervalRunTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                   intervalRunSpan.Hours,
                                   intervalRunSpan.Minutes,
                                   intervalRunSpan.Seconds);

            TimeSpan remainingIntevalSpan = TimeSpan.FromSeconds(intCurrentInterval * 60 - intCurrentRunTime);
            string formattedRemainingIntervalRunTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    remainingIntevalSpan.Hours,
                                    remainingIntevalSpan.Minutes,
                                    remainingIntevalSpan.Seconds);


            lblProgramRunTime.Text = "Total Run Time: " + formattedTotalRunTime;
            lblRemainingRunTime.Text = "Total Remaining Run Time: " + formattedRemainingRunTime;
            lblCurrentIntervalRunTime.Text = "Interval Run Time: " + formattedCurrentIntervalRunTime;
            lblIntervalRemainingTime.Text = "Interval Remaining Run Time: " + formattedRemainingIntervalRunTime;
            this.Refresh();
        }

        private void GetCBOText(ComboBox cbo)
        {
            if (cbo.InvokeRequired)
            {
                cbo.Invoke(new DelegateCBOText(GetCBOText), cbo);
            }
            else
            {
                AudioFile = ((AudioItem)cbo.SelectedItem).Value;
            }
        }

        private void GetCurrentInterval()
        {
            if (lbIntervals.InvokeRequired)
            {
                lbIntervals.Invoke(new DelegateControllAccess(GetCurrentInterval));
            }
            else
            {
                intCurrentInterval = int.Parse(lbIntervals.SelectedItem.ToString());
            }
        }

        private int GetRunTime()
        {
            var runtime = 0;
            for (var i = lbIntervals.SelectedIndex; i < lbIntervals.Items.Count; i++)
            {
                runtime += int.Parse(lbIntervals.Items[i].ToString());
            }
            return runtime * 60;
        }
        #endregion

        #region worker thread
        private void OnTimedEvent()
        {
            while (!boolPaused && !boolStopped)
            {
                GetCurrentInterval();
                intTotalTimeEllapsed++;
                intCurrentRunTime++;

                if (lblProgramRunTime.InvokeRequired)
                {
                    lblProgramRunTime.Invoke(new DelegateControllAccess(UpdateLabels));
                }
                else
                {
                    UpdateLabels();
                }

                if (intCurrentRunTime >= (intCurrentInterval * 60))
                {
                    intCurrentRunTime = 0;
                    GetCBOText(cboAudioFile);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        jbIntervalAudio = new JukeBox2();
                        jbIntervalAudio.FileName = AudioFile;
                        jbIntervalAudio.TrackName = "IntervalAudio";
                        jbIntervalAudio.Play(false);
                    }));

                    if (lbIntervals.InvokeRequired)
                    {
                        lbIntervals.Invoke(new DelegateControllAccess(IncrimentListBox));
                    }
                    else
                    {
                        IncrimentListBox();
                    }
                }
                Thread.Sleep(intSleepTime);
            }
            if (boolStopped)
            {
                ResetOrStop();
            }
        }
        #endregion

        #region save and select program handlers
        private void cboSavesAndPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavesAndPresets.Text.Trim() == "")
            {
                ClearForm();
                btnDeletePreset.Enabled = false;
                return;
            }

            var savesAndPresets = Reg.Get_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets");
            foreach (var value in savesAndPresets)
            {
                if (value.Split(new char[] { '~' })[0] != cboSavesAndPresets.SelectedItem.ToString()) continue;
                var intervals = value.Split(new char[] { '~' })[1].ToString();
                var replayOption = int.Parse(value.Split(new char[] { '~' })[2].ToString());
                var intervalFile = value.Split(new char[] { '~' })[3].ToString();
                var bgAudioFile = value.Split(new char[] { '~' })[4].ToString();
                btnDeletePreset.Enabled = int.Parse(value.Split(new char[] { '~' })[5].ToString()) == 0;

                lbIntervals.Items.Clear();
                foreach (var number in intervals.Split(new char[] { ',' }))
                {
                    lbIntervals.Items.Add(number);
                }

                optStop.Checked = replayOption == 0;
                optLoop.Checked = replayOption == 1;
                optRepeatFinal.Checked = replayOption == 2;

                cboAudioFile.Text = intervalFile;
                cboBGAudio.Text = bgAudioFile;
            }
        }

        private void ClearForm()
        {
            cboAudioFile.Text = "";
            cboBGAudio.Text = "";
            optStop.Checked = true;
            lbIntervals.Items.Clear();
        }

        private void saveCurrentProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var savesAndPresets = Reg.Get_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets");

            if (lbIntervals.Items.Count == 0)
            {
                MessageBox.Show("You must set at least one interval value for your program", "No Intervals Set", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (cboAudioFile.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must select an audio file to play at the end of each interval", "No Audio File Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            var programName = Interaction.InputBox("Enter a name for your new program:", "");

            if (programName == null || programName.Trim().Length == 0) return;


            //copy bgaudio and interval audio to appdata for future runs
            var appDir = Environment.GetEnvironmentVariable("LocalAppData") + "\\RampTimerBuilder";
            FileInfo fiBGAudio;
            FileInfo fiIntervalAudio;
            if (cboBGAudio.Text.Trim().Length > 0)
            {
                try
                {
                    fiBGAudio = new FileInfo(cboBGAudio.Text.Trim());
                    if (!File.Exists(appDir + "\\RampTimerBuilder.BGAudio." + fiBGAudio.Name))
                        File.Copy(cboBGAudio.Text.Trim(), appDir + "\\RampTimerBuilder.BGAudio." + fiBGAudio.Name);
                }
                catch (FileNotFoundException)
                {
                    Debugger.Break();
                    MessageBox.Show("The background audio file you selected cannot be found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            else
            {
                fiBGAudio = null;
            }

            try
            {
                fiIntervalAudio = new FileInfo(cboAudioFile.Text.Trim());
                if (!File.Exists(appDir + "\\RampTimerBuilder.Alarms." + fiIntervalAudio.Name))
                    File.Copy(cboAudioFile.Text.Trim(), appDir + "\\RampTimerBuilder.Alarms." + fiIntervalAudio.Name);
            }
            catch (FileNotFoundException)
            {
                Debugger.Break();
                MessageBox.Show("The interval audio file you selected cannot be found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            var intervals = "";
            foreach (var item in lbIntervals.Items)
            {
                intervals += item.ToString() + ",";
            }
            intervals = intervals.Remove(intervals.Length - 1, 1);

            var endAction = optStop.Checked ? 0 : optLoop.Checked ? 1 : 2;
            var newProgram = programName + "~" + intervals + "~" + endAction.ToString() + "~" + fiIntervalAudio.Name + "~" + (fiBGAudio == null ? "" : fiBGAudio.Name + "~0") + "~0";

            string[] newPresetArray = new string[] { };
            var programAlreadyExists = false;
            foreach (var preset in savesAndPresets)
            {
                if (preset.Trim().Length == 0) continue;
                Array.Resize(ref newPresetArray, newPresetArray.Length + 1);
                var presetName = preset.Split(new char[] { '~' })[0];
                if (presetName == programName)
                {
                    var saveOverProgram = MessageBox.Show(programName + " already exists. Would you like to save over it?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (saveOverProgram != DialogResult.Yes) return;
                    newPresetArray[newPresetArray.Length - 1] = newProgram;
                    programAlreadyExists = true;
                }
                else
                {
                    newPresetArray[newPresetArray.Length - 1] = preset;
                }
            }

            if (!programAlreadyExists)
            {
                Array.Resize(ref newPresetArray, newPresetArray.Length + 1);
                newPresetArray[newPresetArray.Length - 1] = newProgram;
            }

            Reg.Set_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets", newPresetArray, Microsoft.Win32.RegistryValueKind.MultiString);
            PopulatePresetDropdown();
        }
        #endregion

        #region closing event handlers
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillThreadsAndExit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KillThreadsAndExit();
        }

        private void KillThreadsAndExit()
        {
            foreach (var thread in threadPoolIntervals)
            {
                if (thread == null) continue;
                thread.Abort();
            }
            Environment.Exit(Environment.ExitCode);
        }
        #endregion

        #region about box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }
        #endregion

        #region audio file validation
        private void ValidateFileType(object sender, EventArgs e)
        {
            var cbo = sender as ComboBox;
            if (cbo.Text.Trim().Length == 0) return;

            var appDir = Environment.GetEnvironmentVariable("LocalAppData") + "\\RampTimerBuilder";
            if (!File.Exists(((AudioItem)cbo.SelectedItem).Value) && !File.Exists(appDir + "\\RampTimerBuilder.Alarms." + cbo.Text.Trim()) && !File.Exists(appDir + "\\RampTimerBuilder.BGAudio." + cbo.Text.Trim()))
            {
                Debugger.Break();
                MessageBox.Show("The audio file you selected cannot be found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cbo.Select();
                return;
            }

            var fi = new FileInfo(cbo.Text.Trim());
            var ext = fi.Extension.ToLower();

            if (ext != ".wav" && ext != ".mp3")
            {
                MessageBox.Show("You have selected an invalid file type. You must select a .wav or .mp3 file.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cbo.Select();
                return;
            }
        }
        #endregion

        #region delete saved program
        private void btnDeletePreset_Click(object sender, EventArgs e)
        {
            var deletePrompt = MessageBox.Show("Are you sure you want to delete '" + cboSavesAndPresets.SelectedItem.ToString() + "'?", "Delete Saved Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deletePrompt != DialogResult.Yes) return;

            var savesAndPresets = Reg.Get_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets");
            var newPresetArray = new string[0];
            foreach (var value in savesAndPresets)
            {
                if (value.Split(new char[] { '~' })[0] == cboSavesAndPresets.SelectedItem.ToString() &&
                    int.Parse(value.Split(new char[] { '~' })[5].ToString()) == 0)
                    continue;

                Array.Resize(ref newPresetArray, newPresetArray.Length + 1);
                newPresetArray[newPresetArray.Length - 1] = value;
            }

            Reg.Set_REG_MULTI_SZ(Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\\ML\\RampTimerBuilder", "SavesAndPresets", newPresetArray, Microsoft.Win32.RegistryValueKind.MultiString);
            cboSavesAndPresets.Items.RemoveAt(cboSavesAndPresets.SelectedIndex);
            btnDeletePreset.Enabled = false;
        }
        #endregion
    }
}
