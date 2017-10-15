//using System;
//using System.Text;
//using System.Windows.Forms;
//using System.IO;
//using System.Runtime.InteropServices;
//using System.Threading;

//namespace RampTimerBuilder
//{
//    class JukeBox
//    { 
//        public bool IsBeingPlayed = false;
//        private bool IsLooping = false;
//        public string FileName;
//        public string TrackName;
//        private long lngVolume = 500; //between 0-1000

//        private void PlayWorker()
//        {
//            StringBuilder sb = new StringBuilder();
//            int result = mciSendString("open \"" + FileName + "\" type waveaudio  alias " + this.TrackName, sb, 0, IntPtr.Zero);
//            mciSendString("play " + this.TrackName, sb, 0, IntPtr.Zero);
//            IsBeingPlayed = true;
//            //loop
//            sb = new StringBuilder();
//            mciSendString("status " + this.TrackName + " length", sb, 255, IntPtr.Zero);
//            int length = Convert.ToInt32(sb.ToString());
//            int pos = 0;
//            long oldvol = lngVolume;

//            while (IsBeingPlayed)
//            {
//                sb = new StringBuilder();
//                mciSendString("status " + this.TrackName + " position", sb, 255, IntPtr.Zero);
//                pos = Convert.ToInt32(sb.ToString());
//                if (pos >= length)
//                {
//                    if (!IsLooping)
//                    {
//                        IsBeingPlayed = false;
//                        break;
//                    }
//                    else
//                    {
//                        mciSendString("play " + this.TrackName + " from 0", sb, 0, IntPtr.Zero);
//                    }
//                }

//                if (oldvol != lngVolume) //volume is changed by user
//                {
//                    sb = new StringBuilder("................................................................................................................................");
//                    string cmd = "setaudio " + this.TrackName + " volume to " + lngVolume.ToString();
//                    long err = mciSendString(cmd, sb, sb.Length, IntPtr.Zero);
//                    System.Diagnostics.Debug.Print(cmd);
//                    if (err != 0)
//                    {
//                        System.Diagnostics.Debug.Print("ERror " + err);
//                    }
//                    else
//                    {
//                        System.Diagnostics.Debug.Print("No errors!");
//                    }
//                    oldvol = lngVolume;
//                }
//                Application.DoEvents();
//            }
//            mciSendString("stop " + this.TrackName, sb, 0, IntPtr.Zero);
//            mciSendString("close " + this.TrackName, sb, 0, IntPtr.Zero);
//        }

//        //volume between 0-10
//        public int GetVolume()
//        {
//            return (int)this.lngVolume / 100;
//        }

//        //volume between 0-10
//        public void SetVolume(int newvolume)
//        {
//            this.lngVolume = newvolume * 100;
//        }

//        public void Play(bool Looping)
//        {
//            try
//            {
//                if (IsBeingPlayed)
//                    return;
//                if (!File.Exists(FileName))
//                {
//                    IsBeingPlayed = true;
//                    return;
//                }
//                this.IsLooping = Looping;
//                ThreadStart ts = new ThreadStart(PlayWorker);
//                Thread WorkerThread = new Thread(ts);
//                WorkerThread.Start();
//            }
//            catch (Exception ex)
//            {
//                var m = ex.Message;
//            }
//        }

//        public void StopPlaying()
//        {
//            IsBeingPlayed = false;
//        }

//        //sound api functions
//        [DllImport("winmm.dll")]
//        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

//        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
//        static extern bool PlaySound(
//            string pszSound,
//            IntPtr hMod,
//            SoundFlags sf);

//        [Flags]
//        public enum SoundFlags : int
//        {
//            SND_SYNC = 0x0000,  // play synchronously (default) 
//            SND_ASYNC = 0x0001,  // play asynchronously 
//            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
//            SND_MEMORY = 0x0004,  // pszSound points to a memory file
//            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
//            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
//            SND_PURGE = 0x40, // <summary>Stop Playing Wave</summary>
//            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
//            SND_ALIAS = 0x00010000, // name is a registry alias 
//            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
//            SND_FILENAME = 0x00020000, // name is file name 
//            SND_RESOURCE = 0x00040004  // name is resource name or atom 
//        }

//    }
//}










//using System;
//using System.Media;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace RampTimerBuilder
//{
//    class JukeBox
//    {
//        public string AudioFile { get; set; }

//        //System.Media.SoundPlayer Player;
//        //WMPLib.WindowsMediaPlayer Player;
//        public bool IsBeingPlayed = false;
//        private bool IsLooping = false;
//        public string FileName;
//        public string TrackName;
//        //private int Timer = 0;//in minutes
//        //BackgroundWorker Player;
//        private long lngVolume = 500; //between 0-1000

//        [DllImport("winmm.dll")]
//        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

//        public void PlaySound()
//        {

//            StringBuilder sb = new StringBuilder();
//            mciSendString("open \"" + FileName + "\" alias " + this.TrackName, sb, 0, IntPtr.Zero);
//            mciSendString("play " + this.TrackName, sb, 0, IntPtr.Zero);
//            IsBeingPlayed = true;


//            //SoundPlayer player = new SoundPlayer();
//            //if (AudioFile == null) return;

//            //if (AudioFile.Contains("RampTimerBuilder."))
//            //{
//            //    var a = Assembly.GetExecutingAssembly();
//            //    var s = a.GetManifestResourceStream(AudioFile);

//            //    player.Stream = s;
//            //    player.LoadAsync();
//            //    if (AudioFile.Contains("BGAudio"))
//            //        player.PlaySync();
//            //    else 
//            //        player.PlaySync();
//            //}
//            ////else if (AudioFile.ToLower().Contains(".mp3"))
//            ////{
//            ////    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

//            ////    wplayer.URL = AudioFile;
//            ////    wplayer.controls.play();
//            ////}
//            //else if (AudioFile.ToLower().Contains(".wav"))
//            //{
//            //    player.SoundLocation = AudioFile;
//            //    player.Load();
//            //    player.Play();
//            //}
//        }

//        public void StopSound(SoundPlayer player)
//        {
//            if(AudioFile == null) return;

//            if (AudioFile.Contains("RampTimerBuilder."))
//            {
//                //var a = Assembly.GetExecutingAssembly();
//                //var s = a.GetManifestResourceStream(AudioFile);
//                //SoundPlayer player = new SoundPlayer(s);
//                player.Stop();
//            }
//            else if (AudioFile.ToLower().Contains(".mp3"))
//            {
//                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

//                wplayer.URL = AudioFile;
//                wplayer.controls.stop();
//            }
//            else if (AudioFile.ToLower().Contains(".wav"))
//            {
//                //var player = new SoundPlayer();
//                //player.SoundLocation = AudioFile;
//                //player.Load();
//                player.Stop();
//            }
//        }
//    }
//}
