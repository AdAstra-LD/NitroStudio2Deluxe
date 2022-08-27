using GotaSoundIO.Sound;
using NitroFileLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class CreateStreamTool : Form {

        /// <summary>
        /// Swav mode.
        /// </summary>
        bool SwavMode;

        /// <summary>
        /// User-loaded sound file.
        /// </summary>
        SoundFile inp;


        public CreateStreamTool(bool swavMode) {
            InitializeComponent();
            outputFormat.SelectedIndex = 2;
            SwavMode = swavMode;
            if (SwavMode) {
                Text = "Create Wave";
                Icon = Properties.Resources.Wav;
                loopingTableLayoutPanel.Enabled = true;
            }
        }

        private void impFileButton_Click(object sender, EventArgs e) {
            OpenFileDialog o = new OpenFileDialog {
                RestoreDirectory = true,
                Filter = "Supported Sound Files|*.wav;*.swav;*.strm"
            };
            o.ShowDialog();
            if (!string.IsNullOrWhiteSpace(o.FileName)) {
                impFileBox.Text = o.FileName;
                impFileBox.SelectionStart = outFileBox.Text.Length;
                impFileBox.ScrollToCaret();
                impFileBox.Refresh();
            }

            if (SwavMode && Path.GetExtension(o.FileName).ToLowerInvariant().Equals(".swav")) {
                inp = new Wave();
                inp.Read(o.FileName);

                bool backupDisableHandlers = disableHandlers;
                disableHandlers = true;

                if (inp.LoopStart == 0 && inp.LoopEnd == 0 && inp.LoopLength == 0) {
                    if (inp.Loops) {
                        useLoopRadioButton.Checked = true;
                        discardLoopRadioButton.Checked = false;
                        this.Text = "Unused loop points detected";
                    } else {
                        useLoopRadioButton.Checked = false;
                        discardLoopRadioButton.Checked = true;
                        this.Text = "You can choose to set loop points";
                    }
                }

                if (inp.LoopStart > inp.LoopEnd) {
                    Console.WriteLine($"Loop start position ({inp.LoopStart}) can't be greater than Loop end position ({inp.LoopEnd}).");
                    inp.LoopEnd = inp.LoopStart + inp.LoopLength;
                } else if (inp.LoopLength == 0) {
                    Console.WriteLine($"loopLength is set to 0. Recalculating based on loopStart ({inp.LoopStart}) and loopEnd ({inp.LoopEnd}).");
                    inp.LoopLength = inp.LoopEnd - inp.LoopStart;
                } else if (inp.LoopLength + inp.LoopStart != inp.LoopEnd) {
                    Console.WriteLine($"loopStart ({inp.LoopStart}) + loopLength ({inp.LoopLength}) = {inp.LoopStart + inp.LoopLength} does not equal loopEnd ({inp.LoopEnd}).\n" +
                        $"Priority will be given to loopEnd. loopLength will be recalculated.");
                    inp.LoopLength = inp.LoopEnd - inp.LoopStart;
                }

                loopStartNumericUpDown.Value = this.originalLoopStart = inp.LoopStart;
                loopEndNumericUpDown.Value = this.originalLoopEnd = inp.LoopEnd;
                loopLengthNumericUpDown.Value = this.originalLoopLength = inp.LoopLength;

                this.disableHandlers = backupDisableHandlers;
            }
        }

        private void outFileButton_Click(object sender, EventArgs e) {
            SaveFileDialog s = new SaveFileDialog {
                RestoreDirectory = true,
                Filter = SwavMode ? "Sound Wave|*.swav" : "Sound Stream|*.strm"
            };
            s.ShowDialog();

            if (!string.IsNullOrWhiteSpace(s.FileName)) {
                outFileBox.Text = s.FileName;
                outFileBox.SelectionStart = outFileBox.Text.Length;
                outFileBox.ScrollToCaret();
                outFileBox.Refresh();
            }
        }

        private void exportButton_Click(object sender, EventArgs e) {
            if (impFileBox.Text.Equals("")) {
                MessageBox.Show("No Input File Selected!");
                return;
            }
            if (outFileBox.Text.Equals("")) {
                MessageBox.Show("No Output File Selected!");
                return;
            }

            //Switch input file.
            if (inp is null) {
                switch (Path.GetExtension(impFileBox.Text)) {
                    case ".swav":
                        inp = new Wave();
                        break;
                    case ".strm":
                        inp = new NitroFileLoader.Stream();
                        break;
                    default:
                        inp = new RiffWave();
                        break;
                }
                inp.Read(impFileBox.Text);
            }

            //Get conversion type.
            Type convType;
            switch (outputFormat.SelectedIndex) {
                case 0:
                    convType = typeof(PCM8Signed);
                    break;
                case 1:
                    convType = typeof(PCM16);
                    break;
                default:
                    convType = typeof(ImaAdpcm);
                    break;
            }

            //Sound file.
            SoundFile s;
            if (SwavMode) {
                s = new Wave();
            } else {
                s = new NitroFileLoader.Stream();
            }

            //Convert the file.
            s.FromOtherStreamFile(inp, convType);

            //Save the file.
            s.Write(outFileBox.Text);
        }

        private bool disableHandlers = false;


        public uint originalLoopStart { private set; get; }
        public uint originalLoopLength { private set; get; }
        public uint originalLoopEnd { private set; get; }


        private void updateUseLoop() {
            loopStartNumericUpDown.Enabled = loopEndNumericUpDown.Enabled =
            loopLengthNumericUpDown.Enabled = inp.Loops = useLoopRadioButton.Checked;
        }
        private void useLoopRadioButton_CheckedChanged(object sender, EventArgs e) {
            updateUseLoop();
        }
        private void discardLoopRadioButton_CheckedChanged(object sender, EventArgs e) {
            updateUseLoop();
        }

        private void loopStartNumericUpDown_ValueChanged(object sender, EventArgs e) {
            inp.LoopStart = (uint)loopStartNumericUpDown.Value;

            bool backupDisableHandlers = disableHandlers;
            disableHandlers = true;

            inp.LoopEnd = (uint)(loopEndNumericUpDown.Value = inp.LoopStart + inp.LoopLength);

            disableHandlers = backupDisableHandlers;
        }

        private void loopLengthNumericUpDown_ValueChanged(object sender, EventArgs e) {
            inp.LoopLength = (uint)loopLengthNumericUpDown.Value;

            bool backupDisableHandlers = disableHandlers;
            disableHandlers = true;

            loopEndNumericUpDown.Value = inp.LoopEnd = inp.LoopStart + inp.LoopLength;

            disableHandlers = backupDisableHandlers;
        }

        private void loopEndNumericUpDown_ValueChanged(object sender, EventArgs e) {
            inp.LoopEnd = (uint)loopEndNumericUpDown.Value;

            bool backupDisableHandlers = disableHandlers;
            disableHandlers = true;

            loopLengthNumericUpDown.Value = inp.LoopLength = inp.LoopEnd - inp.LoopStart;

            disableHandlers = backupDisableHandlers;
        }
    }
}
