// Adapted from LandonAndEmma's NAudio stream preview:
// https://github.com/NitroShellMKDS/NitroStudio2Deluxe/commit/814bfc86e63175a41c7a769b7e650407e8316092
using GotaSoundIO.Sound;
using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class StreamPlayer : Form {
        private WaveOutEvent output;
        private WaveFileReader reader;
        private MemoryStream audio;
        private readonly Timer timer = new Timer { Interval = 100 };
        private readonly TrackBar position = new TrackBar { Minimum = 0, Maximum = 1000, TickStyle = TickStyle.None, Dock = DockStyle.Fill };
        private readonly Label elapsed = new Label { AutoSize = true, Text = "0:00 / 0:00" };
        private bool seeking;

        public StreamPlayer(MainWindow owner, SoundFile source, string name) {
            InitializeComponent();
            Text = "Stream Player - " + name;
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), ColumnCount = 1, RowCount = 3 };
            var controls = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
            var play = new Button { Text = "Play", AutoSize = true };
            var pause = new Button { Text = "Pause", AutoSize = true };
            var stop = new Button { Text = "Stop", AutoSize = true };
            var volume = new TrackBar { Minimum = 0, Maximum = 100, Value = 75, TickStyle = TickStyle.None, Width = 110 };
            controls.Controls.AddRange(new Control[] { play, pause, stop, new Label { Text = "Volume", AutoSize = true, Padding = new Padding(0, 8, 0, 0) }, volume });
            layout.Controls.Add(position);
            layout.Controls.Add(elapsed);
            layout.Controls.Add(controls);
            Controls.Add(layout);
            PlaybackIcons.Apply(this);
            play.Click += (s, e) => { if (reader != null && reader.Position >= reader.Length) reader.Position = 0; output?.Play(); };
            pause.Click += (s, e) => output?.Pause();
            stop.Click += (s, e) => { output?.Stop(); if (reader != null) reader.Position = 0; };
            volume.ValueChanged += (s, e) => { if (output != null) output.Volume = volume.Value / 100f; };
            position.MouseDown += (s, e) => seeking = true;
            position.MouseUp += (s, e) => { Seek(); seeking = false; };
            position.KeyUp += (s, e) => Seek();
            timer.Tick += (s, e) => {
                if (reader == null || seeking) return;
                position.Value = reader.Length == 0 ? 0 : (int)Math.Min(1000, reader.Position * 1000 / reader.Length);
                elapsed.Text = reader.CurrentTime.ToString(@"m\:ss") + " / " + reader.TotalTime.ToString(@"m\:ss");
            };
            try {
                var wave = new RiffWave();
                wave.FromOtherStreamFile(source);
                audio = new MemoryStream(wave.Write(), false);
                reader = new WaveFileReader(audio);
                output = new WaveOutEvent { Volume = .75f };
                output.Init(reader);
                output.Play();
                timer.Start();
            } catch (Exception ex) {
                DisposePlayback();
                layout.Enabled = false;
                MessageBox.Show(owner, ex.Message, "Cannot preview stream", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seek() {
            if (output == null || reader == null) return;
            bool playing = output.PlaybackState == PlaybackState.Playing;
            output.Stop();
            long offset = reader.Length * position.Value / 1000;
            reader.Position = offset - offset % reader.WaveFormat.BlockAlign;
            if (playing) output.Play();
        }

        private void DisposePlayback() {
            timer.Stop();
            // One owner releases the output before its source; no temp files or delete threads.
            try { output?.Dispose(); }
            finally {
                output = null;
                reader?.Dispose(); reader = null;
                audio?.Dispose(); audio = null;
            }
        }
    }
}
