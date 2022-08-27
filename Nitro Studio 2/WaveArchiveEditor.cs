using GotaSoundIO.IO;
using GotaSoundIO.Sound;
using NAudio.Wave;
using NitroFileLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NitroStudio2 {
    /// <summary>
    /// Wave archive editor.
    /// </summary>
    public class WaveArchiveEditor : EditorBase {
        /// <summary>
        /// Determines whether a different SWAV element has been selected, 
        /// since the Wave Player was started.
        /// </summary>
        bool selectionChangedAfterPlaying = false;

        /// <summary>
        /// Stores old selected element. 
        /// Can prevent gui from refreshing when not necessary.
        /// </summary>
        TreeNode oldSelection = null;

        /// <summary>
        /// Wave archive.
        /// </summary>
        public WaveArchive WA => File as WaveArchive;

        /// <summary>
        /// Stream player.
        /// </summary>
        public GotaSoundIO.Sound.Playback.StreamPlayer Player;

        /// <summary>
        /// Position bar free.
        /// </summary>
        public bool PositionBarFree = true;

        /// <summary>
        /// Timer.
        /// </summary>
        public Timer Timer = new Timer();

        /// <summary>
        /// Create a new wave archive editor.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        public WaveArchiveEditor(MainWindow mainWindow) : base(typeof(WaveArchive), "Wave Archive", "war", "Wave Archive Editor", mainWindow) {
            Init();
        }

        /// <summary>
        /// Wave archive editor.
        /// </summary>
        /// <param name="fileToOpen">The file to open.</param>
        public WaveArchiveEditor(string fileToOpen) : base(typeof(WaveArchive), "Wave Archive", "war", "Wave Archive Editor", fileToOpen, null) {
            Init();
        }

        /// <summary>
        /// Wave archive editor.
        /// </summary>
        /// <param name="fileToOpen">File to open.</param>
        /// <param name="mainWindow">Main window.</param>
        /// <param name="fileName">File name.</param>
        public WaveArchiveEditor(IOFile fileToOpen, MainWindow mainWindow, string fileName) : base(typeof(WaveArchive), "Wave Archive", "war", "Wave Archive Editor", fileToOpen, mainWindow, fileName) {
            Init();
        }

        /// <summary>
        /// Initialize the editor.
        /// </summary>
        public void Init() {
            Player = new GotaSoundIO.Sound.Playback.StreamPlayer();
            Icon = Properties.Resources.War;
            tree.Nodes.RemoveAt(0);
            tree.Nodes.Add("root", "Wave Archive", 5, 5);
            UpdateNodes();
            tree.Nodes[0].Expand();

            SampleLoopModeChange(null, null);

            swavLoopLabel.Visible = swavLoopCheckbox.Visible = kermalisLoopBox.Visible = true;


            FormClosing += new FormClosingEventHandler(WAClosing);
            soundPlayerLabel.Text = "Sound Player Deluxe™";
            kermalisPlayButton.Click += new EventHandler(PlayClick);
            kermalisPauseButton.Click += new EventHandler(PauseClick);
            kermalisStopButton.Click += new EventHandler(StopClick);
            kermalisVolumeSlider.ValueChanged += new EventHandler(VolumeChanged);
            swavLoopCheckbox.CheckedChanged += new EventHandler(SampleLoopModeChange);
            kermalisLoopBox.CheckedChanged += new EventHandler(LoopPlaybackChanged);
            kermalisPosition.MouseUp += new MouseEventHandler(PositionMouseUp);
            kermalisPosition.MouseDown += new MouseEventHandler(PositionMouseDown);

            loopStartUpDown.ValueChanged += new EventHandler(LoopStartChanged);
            loopLengthUpDown.ValueChanged += new EventHandler(LoopLengthChanged);

            tree.KeyPress += new KeyPressEventHandler(KeyPress);
            
            Timer.Tick += PositionTick;
            Timer.Interval = 10;
            Timer.Start();
        }

        /// <summary>
        /// Do info stuff.
        /// </summary>
        public override void DoInfoStuff() {

            //Base.
            base.DoInfoStuff();

            //Hide stuff.
            void HideStuff() {
                kermalisSoundPlayerPanel.Hide();
                kermalisSoundPlayerPanel.SendToBack();
            }

            //Not null.
            if (!FileOpen || File == null) {
                return;
            }
            
            if (tree.SelectedNode.Parent == null) {
                HideStuff();
                noInfoPanel.BringToFront();
                noInfoPanel.Show();
                status.Text = "No Valid Info Selected!";
                oldSelection = null;
            } else {
                if (oldSelection != tree.SelectedNode) {
                    if (Player.SoundOut.PlaybackState.Equals(PlaybackState.Playing)) {
                        selectionChangedAfterPlaying = true;
                    }
                }

                if (oldSelection == null) {
                    blankPanel.BringToFront();
                    blankPanel.Show();

                    kermalisSoundPlayerPanel.BringToFront();
                    kermalisSoundPlayerPanel.Show();
                }

                Wave cur = WA.Waves[tree.SelectedNode.Index];

                if (cur != null) {
                    swavLoopCheckbox.Checked = cur.Loops;

                    PcmFormat pcmf = cur.GetPcmFormat();
                    loopStartUpDown.Value = Wave.Sample2Offset(cur.LoopStart, pcmf) / 4;
                    loopLengthUpDown.Value = cur.LoopLength;

                    status.Text = "Wave " + tree.SelectedNode.Index + " Selected. " +
                        cur.Audio.NumSamples + " samples long " + (cur.Loops ? "(Looping)" : "(Not Looping)") +
                        ", " + cur.SampleRate + " Hz" +
                        ", " + MainWindow.GetBytesSize(cur) + ".";
                }

                oldSelection = tree.SelectedNode;
            }
        }

        /// <summary>
        /// Update nodes.
        /// </summary>
        public override void UpdateNodes() {

            //Begin update.
            BeginUpdateNodes();

            //File open and not null.
            if (FileOpen && File != null) {

                //Add waves.
                tree.Nodes[0].ContextMenuStrip = rootMenu;
                for (int i = 0; i < WA.Waves.Count; i++) {
                    tree.Nodes[0].Nodes.Add("wave" + i, "Wave " + i, 14, 14);
                    tree.Nodes[0].Nodes["wave" + i].ContextMenuStrip = nodeMenu;
                }
            } else {

                //Remove context menus.
                foreach (TreeNode n in tree.Nodes) {
                    n.ContextMenuStrip = null;
                }

            }

            //End update.
            EndUpdateNodes();
        }

        /// <summary>
        /// Closing.
        /// </summary>
        public void WAClosing(object sender, FormClosingEventArgs e) {
            Player.Dispose();
        }

        /// <summary>
        /// Play click.
        /// </summary>
        public void PlayClick(object sender, EventArgs e) {
            selectionChangedAfterPlaying = false;

            Player.SoundOut.Stop();
            Player.Stop();
            Player.LoadStream(WA.Waves[tree.SelectedNode.Index]);
            kermalisPosition.Maximum = (int)Player.GetLength();
            kermalisPosition.TickFrequency = kermalisPosition.Maximum / 10;
            kermalisPosition.LargeChange = kermalisPosition.Maximum / 20;
            Player.Play();
        }

        /// <summary>
        /// Pause click.
        /// </summary>
        public void PauseClick(object sender, EventArgs e) {
            Player.SoundOut.Pause();
        }

        /// <summary>
        /// Stop click.
        /// </summary>
        public void StopClick(object sender, EventArgs e) { 
            Player.SoundOut.Stop();
            Player.SetPosition(0);
            PositionTick(sender, e);
        }

        /// <summary>
        /// Volume changed.
        /// </summary>
        public void VolumeChanged(object sender, EventArgs e) {
            Player.SoundOut.Volume = kermalisVolumeSlider.Value / 100f;
        }

        /// <summary>
        /// Loop playback mode changed.
        /// </summary>
        public void LoopPlaybackChanged(object sender, EventArgs e) {
            Player.Loop = kermalisLoopBox.Checked;

            SampleLoopModeChange(sender, e);

            StopClick(sender, e);
        }

        /// <summary>
        /// Sample looping settings changed.
        /// </summary>
        public void SampleLoopModeChange(object sender, EventArgs e) {
            if (swavLoopCheckbox.Checked | kermalisLoopBox.Checked) {
                loopingPanel.BringToFront();
                loopingPanel.Show();
            } else {
                loopingPanel.Visible = false;
                loopingPanel.Hide();
                loopingPanel.SendToBack();
            }
        }

        /// <summary>
        /// Position tick.
        /// </summary>
        public void PositionTick(object sender, EventArgs e) {
            if (Player != null && PositionBarFree) {
                uint pos = Player.GetPosition();
                kermalisPosition.Value = pos > kermalisPosition.Maximum ? kermalisPosition.Maximum : (int)pos;
            }
        }

        /// <summary>
        /// Mouse down.
        /// </summary>
        public void PositionMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                PositionBarFree = false;
            }
        }

        /// <summary>
        /// Mouse up.
        /// </summary>
        public void PositionMouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && Player != null) {
                Player.SetPosition((uint)kermalisPosition.Value);
                PositionBarFree = true;
            }
        }

        /// <summary>
        /// Up-Down numeric value changed.
        /// </summary>
        public void LoopStartChanged(object sender, EventArgs e) {
            Wave cur = WA.Waves[tree.SelectedNode.Index];
            cur.LoopStart = Wave.Offset2Samples((uint)(sender as NumericUpDown).Value * 4, cur.GetPcmFormat());
            
            if (Player.SoundOut.PlaybackState.Equals(PlaybackState.Playing)) {
                PlayClick(sender, e);
            }
        }

        /// <summary>
        /// Up-Down numeric value changed.
        /// </summary>
        public void LoopLengthChanged(object sender, EventArgs e) {
            Wave cur = WA.Waves[tree.SelectedNode.Index];
            cur.LoopLength = (uint)(sender as NumericUpDown).Value;
            cur.UpdateLoopEnd(cur.GetPcmFormat());

            if (Player.SoundOut.PlaybackState.Equals(PlaybackState.Playing)) {
                PlayClick(sender, e);
            }
        }


        /// <summary>
        /// Add a wave at an index.
        /// </summary>
        /// <param name="index">The index to add the wave at.</param>
        public void AddWave(int index) {

            //Get the file.
            OpenFileDialog o = new OpenFileDialog {
                Filter = "Supported Audio Files|*.wav;*.swav;*.strm",
                RestoreDirectory = true
            };
            o.ShowDialog();

            //If valid.
            if (o.FileName != "") {

                //Swav file.
                Wave w = new Wave();
                switch (Path.GetExtension(o.FileName)) {
                    case ".wav":
                        RiffWave r = new RiffWave(o.FileName);
                        w.FromOtherStreamFile(r);
                        break;
                    case ".swav":
                        w.Read(o.FileName);
                        break;
                    case ".strm":
                        NitroFileLoader.Stream s = new NitroFileLoader.Stream();
                        s.Read(o.FileName);
                        w.FromOtherStreamFile(s);
                        break;
                    default:
                        MessageBox.Show("Unsupported file format!");
                        return;
                }

                //Add the wave.
                WA.Waves.Insert(index, w);
                UpdateNodes();
                DoInfoStuff();

            }

        }

        /// <summary>
        /// Add a wave to the list.
        /// </summary>
        public override void RootAdd() {
            AddWave(WA.Waves.Count);
        }

        /// <summary>
        /// Add above.
        /// </summary>
        public override void NodeAddAbove() {
            AddWave(tree.SelectedNode.Index);
        }

        /// <summary>
        /// Add below.
        /// </summary>
        public override void NodeAddBelow() {
            AddWave(tree.SelectedNode.Index + 1);
        }

        /// <summary>
        /// Move up.
        /// </summary>
        public override void NodeMoveUp() {
            if (Swap(WA.Waves, tree.SelectedNode.Index, tree.SelectedNode.Index - 1)) {
                tree.SelectedNode = tree.Nodes[0].Nodes[tree.SelectedNode.Index - 1];
                UpdateNodes();
                DoInfoStuff();
            }
        }

        /// <summary>
        /// Move down.
        /// </summary>
        public override void NodeMoveDown() {
            if (Swap(WA.Waves, tree.SelectedNode.Index, tree.SelectedNode.Index + 1)) {
                tree.SelectedNode = tree.Nodes[0].Nodes[tree.SelectedNode.Index + 1];
                UpdateNodes();
                DoInfoStuff();
            }
        }

        /// <summary>
        /// Replace the wave.
        /// </summary>
        public override void NodeReplace() {

            //Get the file.
            OpenFileDialog o = new OpenFileDialog {
                Filter = "Supported Audio Files|*.wav;*.swav;*.strm",
                RestoreDirectory = true
            };
            o.ShowDialog();

            //If valid.
            if (o.FileName != "") {

                //Swav file.
                Wave w = new Wave();
                switch (Path.GetExtension(o.FileName)) {
                    case ".wav":
                        RiffWave r = new RiffWave(o.FileName);
                        w.FromOtherStreamFile(r);
                        break;
                    case ".swav":
                        w.Read(o.FileName);
                        break;
                    case ".strm":
                        NitroFileLoader.Stream s = new NitroFileLoader.Stream();
                        s.Read(o.FileName);
                        w.FromOtherStreamFile(s);
                        break;
                    default:
                        MessageBox.Show("Unsupported file format!");
                        return;
                }

                //Add the wave.
                WA.Waves[tree.SelectedNode.Index] = w;
                UpdateNodes();
                DoInfoStuff();

            }

        }

        /// <summary>
        /// Export the wave.
        /// </summary>
        public override void NodeExport() {

            //Get the file.
            SaveFileDialog s = new SaveFileDialog {
                Filter = "Supported Audio Files|*.wav;*.swav;*.strm|Wave|*.wav|Sound Wave|*.swav|Sound Stream|*.strm",
                RestoreDirectory = true,
                FileName = "Wave " + tree.SelectedNode.Index + ".swav"
            };
            s.ShowDialog();

            //If valid.
            if (s.FileName != "") {

                //Wave.
                Wave w = WA.Waves[tree.SelectedNode.Index];

                //Switch type.
                switch (Path.GetExtension(s.FileName)) {
                    case ".wav":
                        RiffWave r = new RiffWave();
                        r.FromOtherStreamFile(w);
                        r.Write(s.FileName);
                        break;
                    case ".swav":
                        w.Write(s.FileName);
                        break;
                    case ".strm":
                        NitroFileLoader.Stream stm = new NitroFileLoader.Stream();
                        stm.FromOtherStreamFile(w);
                        stm.Write(s.FileName);
                        break;
                    default:
                        MessageBox.Show("Unsupported file format!");
                        return;
                }

            }

        }

        /// <summary>
        /// Delete the wave.
        /// </summary>
        public override void NodeDelete() {
            WA.Waves.RemoveAt(tree.SelectedNode.Index);
            UpdateNodes();
            DoInfoStuff();
        }

        /// <summary>
        /// Key press.
        /// </summary>
        public void KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == ' ' && tree.SelectedNode.Parent != null) {
                if (!selectionChangedAfterPlaying && Player.SoundOut.PlaybackState.Equals(PlaybackState.Playing)) {
                    StopClick(sender, e);
                } else {
                    PlayClick(sender, e);
                }
            }
        }

    }

}
