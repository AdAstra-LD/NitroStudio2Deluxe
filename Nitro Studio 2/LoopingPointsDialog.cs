using GotaSoundIO.Sound;
using System;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class LoopPointsDialog : Form {
        private bool disableHandlers;
        private uint sampleLimit = uint.MaxValue;
        public bool useLoop { private set; get; }
        public uint originalLoopStart { private set; get; }
        public uint originalLoopLength { private set; get; }
        public uint originalLoopEnd { private set; get; }
        public uint loopStart { private set; get; }
        public uint loopLength { private set; get; }
        public uint loopEnd { private set; get; }

        public LoopPointsDialog() {
            InitializeComponent();
            confirmButton.DialogResult = DialogResult.None;
            loopStartNumericUpDown.Maximum = uint.MaxValue;
            loopEndNumericUpDown.Maximum = uint.MaxValue;
            loopLengthNumericUpDown.Maximum = uint.MaxValue;
        }

        public LoopPointsDialog(RiffWave wave) : this(wave.Loops, wave.LoopStart, wave.LoopEnd, wave.LoopLength) {
            sampleLimit = (uint)wave.Audio.NumSamples;
            if (!wave.Loops && loopEnd == 0) loopEnd = sampleLimit;
            SetPoints(Math.Min(loopStart, sampleLimit), Math.Min(loopEnd, sampleLimit));
        }

        public LoopPointsDialog(bool looping, uint start, uint end, uint length = 0) : this() {
            if (end == 0 && length > 0) end = (uint)Math.Min(uint.MaxValue, (ulong)start + length);
            originalLoopStart = start;
            originalLoopEnd = end;
            originalLoopLength = end >= start ? end - start : 0;
            disableHandlers = true;
            useLoopRadioButton.Checked = looping;
            discardLoopRadioButton.Checked = !looping;
            disableHandlers = false;
            SetPoints(start, Math.Max(start, end));
            updateUseLoop();
        }

        private void SetPoints(uint start, uint end) {
            disableHandlers = true;
            loopStart = start;
            loopEnd = end;
            loopLength = end >= start ? end - start : 0;
            loopStartNumericUpDown.Value = start;
            loopEndNumericUpDown.Value = end;
            loopLengthNumericUpDown.Value = loopLength;
            disableHandlers = false;
        }

        private void confirmButton_Click(object sender, EventArgs e) {
            if (useLoop && (loopStart >= loopEnd || loopEnd > sampleLimit)) {
                MessageBox.Show(this, "The loop must have a positive length and fit within the sample.", "Invalid loop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = useLoop ? DialogResult.Yes : DialogResult.No;
            Close();
        }

        private void updateUseLoop() {
            useLoop = useLoopRadioButton.Checked;
            loopStartNumericUpDown.Enabled = loopEndNumericUpDown.Enabled = loopLengthNumericUpDown.Enabled = useLoop;
        }
        private void useLoopRadioButton_CheckedChanged(object sender, EventArgs e) { if (!disableHandlers) updateUseLoop(); }
        private void discardLoopRadioButton_CheckedChanged(object sender, EventArgs e) { if (!disableHandlers) updateUseLoop(); }
        private void loopStartNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if (disableHandlers) return;
            uint start = (uint)loopStartNumericUpDown.Value;
            SetPoints(start, (uint)Math.Min(uint.MaxValue, (ulong)start + loopLength));
        }
        private void loopLengthNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if (disableHandlers) return;
            SetPoints(loopStart, (uint)Math.Min(uint.MaxValue, (ulong)loopStart + (uint)loopLengthNumericUpDown.Value));
        }
        private void loopEndNumericUpDown_ValueChanged(object sender, EventArgs e) {
            if (disableHandlers) return;
            SetPoints(loopStart, (uint)loopEndNumericUpDown.Value);
        }
    }
}
