﻿using GotaSoundIO.Sound;
using NitroFileLoader;
using System;
using System.IO;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class AudioConverter : Form {
        string TextBackup;
        /// <summary>
        /// User-loaded sound file.
        /// </summary>
        SoundFile inp;

        public AudioConverter() {
            InitializeComponent();
            TextBackup = this.Text;
            outputFormatComboBox.SelectedIndex = 2;
        }

        private void impFileButton_Click(object sender, EventArgs e) {
            OpenFileDialog open = new OpenFileDialog {
                RestoreDirectory = true,
                Filter = "Supported Sound Files|*.wav;*.swav;*.strm"
            };

            open.ShowDialog();

            if (string.IsNullOrWhiteSpace(open.FileName)) {
                return;
            }

            impFileBox.Text = open.FileName;
            impFileBox.SelectionStart = outFileBox.Text.Length;
            impFileBox.ScrollToCaret();
            impFileBox.Refresh();

            //Switch input file.
            bool streamFlag = false;
            switch (Path.GetExtension(impFileBox.Text)) {
                case ".swav":
                    inp = new Wave();
                    break;
                case ".strm":
                    streamFlag = true;
                    inp = new NitroFileLoader.Stream();
                    loopingTableLayoutPanel.Enabled = false;
                    break;
                default:
                    inp = new RiffWave();
                    break;
            }
            inp.Read(open.FileName);


            if (!streamFlag) {
                bool backupDisableHandlers = disableHandlers;
                disableHandlers = true;

                if (inp.LoopStart == 0 && inp.LoopEnd == 0 && inp.LoopLength == 0) {
                    if (inp.Loops) {
                        useLoopRadioButton.Checked = true;
                        discardLoopRadioButton.Checked = false;
                        this.Text = TextBackup + " - " + "Unused loop points detected";
                    } else {
                        useLoopRadioButton.Checked = false;
                        discardLoopRadioButton.Checked = true;
                        this.Text = TextBackup + " - " + "You can set loop points";
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
            SaveFileDialog save = new SaveFileDialog {
                RestoreDirectory = true,
                Filter = "Supported Sound Files|*.wav;*.swav"
            };

            save.ShowDialog();

            if (!string.IsNullOrWhiteSpace(save.FileName)) {
                if (save.FileName.Equals(impFileBox.Text)) {
                    MessageBox.Show("Input and output paths must be different!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Path.GetExtension(save.FileName).Equals(".wav")) {
                    outputFormatComboBox.Enabled = formatLabel.Enabled = false;
                }

                outFileBox.Text = save.FileName;
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

            //Get conversion type.
            Type convType;
            switch (outputFormatComboBox.SelectedIndex) {
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

            bool LoopsBackup = inp.Loops;
            uint LoopStartBackup = inp.LoopStart;
            uint LoopEndBackup = inp.LoopEnd;
            uint LoopLengthBackup = inp.LoopLength;

            if (discardLoopRadioButton.Checked) {
                inp.Loops = false;
                inp.LoopStart = originalLoopStart;
                inp.LoopEnd = originalLoopEnd;
                inp.LoopLength = originalLoopLength;
            }

            //Output Sound file.
            SoundFile output;
            switch (Path.GetExtension(outFileBox.Text)) {
                case ".swav":
                    output = new Wave();

                    if (convType.Equals(inp.Audio.EncodingType)) {
                        output.FromOtherStreamFile(inp);
                    } else {
                        //Convert the file.
                        output.FromOtherStreamFile(inp, convType);
                    }
                    break;
                case ".strm":
                    output = new NitroFileLoader.Stream();

                    //Convert the file.
                    output.FromOtherStreamFile(inp, convType);
                    break;
                case ".wav":
                    output = new RiffWave();

                    //Convert the file.
                    output.FromOtherStreamFile(inp);
                    break;
                default:
                    throw new Exception("Unrecognized operation mode!");
            }

            if (discardLoopRadioButton.Checked) {
                inp.Loops = LoopsBackup;
                inp.LoopStart = LoopStartBackup;
                inp.LoopEnd = LoopEndBackup;
                inp.LoopLength = LoopLengthBackup;
            }

            //Save the file.
            output.Write(outFileBox.Text);

            MessageBox.Show("File has been written.", "Operation completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
