using GotaSoundIO.Sound;
using System;
using System.IO;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class LoopPointsDialog : Form {
        private bool disableHandlers = false;

        public bool useLoop { private set; get; }

        public uint originalLoopStart { private set; get; }
        public uint originalLoopLength { private set; get; }
        public uint originalLoopEnd { private set; get; }

        public uint loopStart { private set; get; }
        public uint loopLength { private set; get; }
        public uint loopEnd { private set; get; }
        public LoopPointsDialog() {
            InitializeComponent();
        }
        public LoopPointsDialog(RiffWave r) : this (r.Loops, r.LoopStart, r.LoopEnd, r.LoopLength) { }
        public LoopPointsDialog(bool looping, uint loopStart, uint loopEnd, uint loopLength = 0) : this(){
            bool backupDisableHandlers = disableHandlers;
            this.disableHandlers = true;

            if (loopStart == 0 && loopEnd == 0 && loopLength == 0) {
                if (looping) {
                    useLoopRadioButton.Checked = true;
                    discardLoopRadioButton.Checked = false;
                    this.Text = "Unused loop points detected";
                } else {
                    useLoopRadioButton.Checked = false;
                    discardLoopRadioButton.Checked = true;
                    this.Text = "You can choose to set loop points";
                }
            }

            if (loopStart > loopEnd) {
                Console.WriteLine($"Loop start position ({loopStart}) can't be greater than Loop end position ({loopEnd}).");
                loopEnd = loopStart + loopLength;
            } else if (loopLength > 0) {
                Console.WriteLine($"loopLength is set to 0. Recalculating based on loopStart ({loopStart}) and loopEnd ({loopEnd}).");
                loopLength = loopEnd - loopStart;
            } else if (loopLength + loopStart != loopEnd) {
                Console.WriteLine($"loopStart ({loopStart}) + loopLength ({loopLength}) = {loopStart + loopLength} does not equal loopEnd ({loopEnd}).\n" +
                    $"Priority will be given to loopEnd. loopLength will be recalculated.");
                loopLength = loopEnd - loopStart;
            }
            
            loopStartNumericUpDown.Value = this.originalLoopStart = this.loopStart = loopStart;
            loopEndNumericUpDown.Value = this.originalLoopEnd = this.loopEnd = loopEnd;
            loopLengthNumericUpDown.Value = this.originalLoopLength = this.loopLength = loopLength;

            this.disableHandlers = backupDisableHandlers;
        }

        private void confirmButton_Click(object sender, EventArgs e) {
            confirmButton.DialogResult = useLoop ? DialogResult.Yes : DialogResult.No;
            this.Close();
        }

        private void updateUseLoop() {
            loopStartNumericUpDown.Enabled = loopEndNumericUpDown.Enabled = 
            loopLengthNumericUpDown.Enabled = useLoop = useLoopRadioButton.Checked;
        }
        private void useLoopRadioButton_CheckedChanged(object sender, EventArgs e) {
            updateUseLoop();
        }
        private void discardLoopRadioButton_CheckedChanged(object sender, EventArgs e) {
            updateUseLoop();
        }

        private void loopStartNumericUpDown_ValueChanged(object sender, EventArgs e) {
            loopStart = (uint)loopStartNumericUpDown.Value;

            bool backupDisableHandlers = disableHandlers;
            disableHandlers = true;

            loopEnd = (uint)(loopEndNumericUpDown.Value = loopStart + loopLength);

            disableHandlers = backupDisableHandlers;
        }

        private void loopLengthNumericUpDown_ValueChanged(object sender, EventArgs e) {
            loopLength = (uint)loopLengthNumericUpDown.Value;

            bool backupDisableHandlers = disableHandlers;
            disableHandlers = true;

            loopEndNumericUpDown.Value = loopEnd = loopStart + loopLength;

            disableHandlers = backupDisableHandlers;
        }

        private void loopEndNumericUpDown_ValueChanged(object sender, EventArgs e) {
            loopEnd = (uint)loopEndNumericUpDown.Value;

            bool backupDisableHandlers = disableHandlers;
            disableHandlers = true;

            loopLengthNumericUpDown.Value = loopLength = loopEnd - loopStart;

            disableHandlers = backupDisableHandlers;
        }
    }
}
