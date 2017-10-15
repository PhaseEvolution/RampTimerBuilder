using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RampTimerBuilder
{
    class JukeBox2 : IDisposable
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private bool loop;

        public bool Playing { get; private set; }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                if (fileName != value)
                {
                    fileName = value;

                    if (mediaPlayer.Source != null)
                    {
                        mediaPlayer.Close();
                    }

                    mediaPlayer.Open(new Uri(fileName));
                }
            }
        }

        public string TrackName { get; set; }

        public double Volume
        {
            get { return mediaPlayer.Volume; }
            set { mediaPlayer.Volume = value; }
        }

        public JukeBox2()
        {
            mediaPlayer.MediaEnded += delegate
            {
                if (loop)
                {
                    // Magic to restart the track from the beginning (track keeps playing for some reason).
                    mediaPlayer.Position = TimeSpan.Zero;
                }
                else
                {
                    // Resets the position to 0 without starting playback.
                    mediaPlayer.Stop();
                    Playing = false;
                }
            };
        }

        public void StopPlaying()
        {
            mediaPlayer.Stop();
        }

        public void Play(bool loop = false)
        {
            this.loop = loop;
            Playing = true;
            mediaPlayer.Play();
        }

        public void Dispose()
        {
            mediaPlayer.Close();
        }
    }
}
