using NitroFileLoader;
using System;
using System.IO;
using System.Windows.Forms;

namespace NitroStudio2 {

    /// <summary>
    /// Options dialog shown before exporting a bank as a SoundFont 2 file.
    /// </summary>
    public partial class SF2ExportDialog : Form {

        /// <summary>
        /// Options chosen the last time the dialog was confirmed, reused as defaults.
        /// </summary>
        private static SF2ExportOptions lastOptions = null;

        /// <summary>
        /// The options selected by the user. Valid after the dialog returned OK.
        /// </summary>
        public SF2ExportOptions Options { get; private set; }

        public SF2ExportDialog() {
            InitializeComponent();
            var defaults = lastOptions ?? new SF2ExportOptions();
            resampleCheckBox.Checked = defaults.Resample;
            sampleRateNumericUpDown.Value = Math.Max(sampleRateNumericUpDown.Minimum, Math.Min(sampleRateNumericUpDown.Maximum, defaults.TargetSampleRate));
            quantizeCheckBox.Checked = defaults.Quantize;
            hardwareCheckBox.Checked = defaults.BoostHardwareSamples;
            bitDepthNumericUpDown.Value = Math.Max(bitDepthNumericUpDown.Minimum, Math.Min(bitDepthNumericUpDown.Maximum, defaults.BitDepth));
            namesCheckBox.Checked = defaults.EmbedInstrumentNames;
            namesPathTextBox.Text = defaults.InstrumentNamesPath ?? "";
            UpdateEnabledState();
        }

        private void UpdateEnabledState() {
            sampleRateNumericUpDown.Enabled = resampleCheckBox.Checked;
            bitDepthNumericUpDown.Enabled = quantizeCheckBox.Checked;
            namesPathTextBox.Enabled = namesBrowseButton.Enabled = namesCheckBox.Checked;
        }

        private void resampleCheckBox_CheckedChanged(object sender, EventArgs e) {
            UpdateEnabledState();
        }

        private void quantizeCheckBox_CheckedChanged(object sender, EventArgs e) {
            UpdateEnabledState();
        }

        private void namesCheckBox_CheckedChanged(object sender, EventArgs e) {
            UpdateEnabledState();
        }

        private void namesBrowseButton_Click(object sender, EventArgs e) {
            using (OpenFileDialog o = new OpenFileDialog() { Filter = "Text File|*.txt|All Files|*.*", Title = "Select instrument names file" }) {
                if (!string.IsNullOrEmpty(namesPathTextBox.Text) && File.Exists(namesPathTextBox.Text)) {
                    o.InitialDirectory = Path.GetDirectoryName(namesPathTextBox.Text);
                }
                if (o.ShowDialog(this) == DialogResult.OK) {
                    namesPathTextBox.Text = o.FileName;
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e) {
            SF2ExportOptions options = new SF2ExportOptions() {
                Resample = resampleCheckBox.Checked,
                TargetSampleRate = (uint)sampleRateNumericUpDown.Value,
                Quantize = quantizeCheckBox.Checked,
                BitDepth = (int)bitDepthNumericUpDown.Value,
                BoostHardwareSamples = hardwareCheckBox.Checked,
                EmbedInstrumentNames = namesCheckBox.Checked,
                InstrumentNamesPath = namesPathTextBox.Text
            };
            if (options.EmbedInstrumentNames) {
                if (string.IsNullOrWhiteSpace(options.InstrumentNamesPath) || !File.Exists(options.InstrumentNamesPath)) {
                    MessageBox.Show("Select an existing instrument names text file, or untick the option.", "Instrument names", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try {
                    options.LoadInstrumentNames(options.InstrumentNamesPath);
                } catch (Exception ex) {
                    MessageBox.Show("Could not read the instrument names file:\n" + ex.Message, "Instrument names", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (options.InstrumentNames.Count == 0) {
                    MessageBox.Show("No instrument names were found in the file.\nExpected one instrument per line, e.g. \"0: Piano\" or \"0; 0; Piano\".", "Instrument names", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Options = options;
            lastOptions = options;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }

}
