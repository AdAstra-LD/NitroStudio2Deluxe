namespace NitroStudio2 {
    partial class SF2ExportDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.samplesGroupBox = new System.Windows.Forms.GroupBox();
            this.resampleCheckBox = new System.Windows.Forms.CheckBox();
            this.sampleRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sampleRateLabel = new System.Windows.Forms.Label();
            this.quantizeCheckBox = new System.Windows.Forms.CheckBox();
            this.bitDepthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bitDepthLabel = new System.Windows.Forms.Label();
            this.envelopeGroupBox = new System.Windows.Forms.GroupBox();
            this.envelopeLabel = new System.Windows.Forms.Label();
            this.namesGroupBox = new System.Windows.Forms.GroupBox();
            this.namesCheckBox = new System.Windows.Forms.CheckBox();
            this.namesPathTextBox = new System.Windows.Forms.TextBox();
            this.namesBrowseButton = new System.Windows.Forms.Button();
            this.namesHintLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.samplesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitDepthNumericUpDown)).BeginInit();
            this.envelopeGroupBox.SuspendLayout();
            this.namesGroupBox.SuspendLayout();
            this.SuspendLayout();
            //
            // samplesGroupBox
            //
            this.samplesGroupBox.Controls.Add(this.resampleCheckBox);
            this.samplesGroupBox.Controls.Add(this.sampleRateNumericUpDown);
            this.samplesGroupBox.Controls.Add(this.sampleRateLabel);
            this.samplesGroupBox.Controls.Add(this.quantizeCheckBox);
            this.samplesGroupBox.Controls.Add(this.bitDepthNumericUpDown);
            this.samplesGroupBox.Controls.Add(this.bitDepthLabel);
            this.samplesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.samplesGroupBox.Name = "samplesGroupBox";
            this.samplesGroupBox.Size = new System.Drawing.Size(440, 82);
            this.samplesGroupBox.TabIndex = 0;
            this.samplesGroupBox.TabStop = false;
            this.samplesGroupBox.Text = "Sample processing";
            //
            // resampleCheckBox
            //
            this.resampleCheckBox.AutoSize = true;
            this.resampleCheckBox.Location = new System.Drawing.Point(12, 24);
            this.resampleCheckBox.Name = "resampleCheckBox";
            this.resampleCheckBox.Size = new System.Drawing.Size(86, 17);
            this.resampleCheckBox.TabIndex = 0;
            this.resampleCheckBox.Text = "Resample to";
            this.resampleCheckBox.UseVisualStyleBackColor = true;
            this.resampleCheckBox.CheckedChanged += new System.EventHandler(this.resampleCheckBox_CheckedChanged);
            //
            // sampleRateNumericUpDown
            //
            this.sampleRateNumericUpDown.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.sampleRateNumericUpDown.Location = new System.Drawing.Point(110, 22);
            this.sampleRateNumericUpDown.Maximum = new decimal(new int[] { 192000, 0, 0, 0 });
            this.sampleRateNumericUpDown.Minimum = new decimal(new int[] { 4000, 0, 0, 0 });
            this.sampleRateNumericUpDown.Name = "sampleRateNumericUpDown";
            this.sampleRateNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.sampleRateNumericUpDown.TabIndex = 1;
            this.sampleRateNumericUpDown.Value = new decimal(new int[] { 48000, 0, 0, 0 });
            //
            // sampleRateLabel
            //
            this.sampleRateLabel.AutoSize = true;
            this.sampleRateLabel.Location = new System.Drawing.Point(196, 25);
            this.sampleRateLabel.Name = "sampleRateLabel";
            this.sampleRateLabel.Size = new System.Drawing.Size(200, 13);
            this.sampleRateLabel.TabIndex = 2;
            this.sampleRateLabel.Text = "Hz (zero-order hold, upsample only)";
            //
            // quantizeCheckBox
            //
            this.quantizeCheckBox.AutoSize = true;
            this.quantizeCheckBox.Location = new System.Drawing.Point(12, 52);
            this.quantizeCheckBox.Name = "quantizeCheckBox";
            this.quantizeCheckBox.Size = new System.Drawing.Size(82, 17);
            this.quantizeCheckBox.TabIndex = 3;
            this.quantizeCheckBox.Text = "Quantize to";
            this.quantizeCheckBox.UseVisualStyleBackColor = true;
            this.quantizeCheckBox.CheckedChanged += new System.EventHandler(this.quantizeCheckBox_CheckedChanged);
            //
            // bitDepthNumericUpDown
            //
            this.bitDepthNumericUpDown.Location = new System.Drawing.Point(110, 50);
            this.bitDepthNumericUpDown.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            this.bitDepthNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.bitDepthNumericUpDown.Name = "bitDepthNumericUpDown";
            this.bitDepthNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.bitDepthNumericUpDown.TabIndex = 4;
            this.bitDepthNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            //
            // bitDepthLabel
            //
            this.bitDepthLabel.AutoSize = true;
            this.bitDepthLabel.Location = new System.Drawing.Point(196, 53);
            this.bitDepthLabel.Name = "bitDepthLabel";
            this.bitDepthLabel.Size = new System.Drawing.Size(180, 13);
            this.bitDepthLabel.TabIndex = 5;
            this.bitDepthLabel.Text = "bits (stored as 16-bit PCM)";
            //
            // envelopeGroupBox
            //
            this.envelopeGroupBox.Controls.Add(this.envelopeLabel);
            this.envelopeGroupBox.Location = new System.Drawing.Point(12, 100);
            this.envelopeGroupBox.Name = "envelopeGroupBox";
            this.envelopeGroupBox.Size = new System.Drawing.Size(440, 60);
            this.envelopeGroupBox.TabIndex = 1;
            this.envelopeGroupBox.TabStop = false;
            this.envelopeGroupBox.Text = "Envelope";
            //
            // envelopeLabel
            //
            this.envelopeLabel.Location = new System.Drawing.Point(12, 18);
            this.envelopeLabel.Name = "envelopeLabel";
            this.envelopeLabel.Size = new System.Drawing.Size(420, 36);
            this.envelopeLabel.TabIndex = 0;
            this.envelopeLabel.Text = "Attack, decay, sustain and release are converted with the DS envelope tables " +
                "(attack time, dB/ms decay and release speed, sustain level in dB).";
            //
            // namesGroupBox
            //
            this.namesGroupBox.Controls.Add(this.namesCheckBox);
            this.namesGroupBox.Controls.Add(this.namesPathTextBox);
            this.namesGroupBox.Controls.Add(this.namesBrowseButton);
            this.namesGroupBox.Controls.Add(this.namesHintLabel);
            this.namesGroupBox.Location = new System.Drawing.Point(12, 166);
            this.namesGroupBox.Name = "namesGroupBox";
            this.namesGroupBox.Size = new System.Drawing.Size(440, 96);
            this.namesGroupBox.TabIndex = 2;
            this.namesGroupBox.TabStop = false;
            this.namesGroupBox.Text = "Instrument names";
            //
            // namesCheckBox
            //
            this.namesCheckBox.AutoSize = true;
            this.namesCheckBox.Location = new System.Drawing.Point(12, 22);
            this.namesCheckBox.Name = "namesCheckBox";
            this.namesCheckBox.Size = new System.Drawing.Size(220, 17);
            this.namesCheckBox.TabIndex = 0;
            this.namesCheckBox.Text = "Embed instrument names from a text file";
            this.namesCheckBox.UseVisualStyleBackColor = true;
            this.namesCheckBox.CheckedChanged += new System.EventHandler(this.namesCheckBox_CheckedChanged);
            //
            // namesPathTextBox
            //
            this.namesPathTextBox.Location = new System.Drawing.Point(12, 46);
            this.namesPathTextBox.Name = "namesPathTextBox";
            this.namesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.namesPathTextBox.TabIndex = 1;
            //
            // namesBrowseButton
            //
            this.namesBrowseButton.Location = new System.Drawing.Point(394, 44);
            this.namesBrowseButton.Name = "namesBrowseButton";
            this.namesBrowseButton.Size = new System.Drawing.Size(34, 23);
            this.namesBrowseButton.TabIndex = 2;
            this.namesBrowseButton.Text = "...";
            this.namesBrowseButton.UseVisualStyleBackColor = true;
            this.namesBrowseButton.Click += new System.EventHandler(this.namesBrowseButton_Click);
            //
            // namesHintLabel
            //
            this.namesHintLabel.AutoSize = true;
            this.namesHintLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.namesHintLabel.Location = new System.Drawing.Point(12, 72);
            this.namesHintLabel.Name = "namesHintLabel";
            this.namesHintLabel.Size = new System.Drawing.Size(400, 13);
            this.namesHintLabel.TabIndex = 3;
            this.namesHintLabel.Text = "One instrument per line: \"index: name\" or \"index; bank; name\" (max 20 characters).";
            //
            // exportButton
            //
            this.exportButton.Location = new System.Drawing.Point(296, 274);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            //
            // cancelButton
            //
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(377, 274);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            //
            // SF2ExportDialog
            //
            this.AcceptButton = this.exportButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 309);
            this.Controls.Add(this.samplesGroupBox);
            this.Controls.Add(this.envelopeGroupBox);
            this.Controls.Add(this.namesGroupBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF2ExportDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SoundFont Export Options";
            this.samplesGroupBox.ResumeLayout(false);
            this.samplesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitDepthNumericUpDown)).EndInit();
            this.envelopeGroupBox.ResumeLayout(false);
            this.namesGroupBox.ResumeLayout(false);
            this.namesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox samplesGroupBox;
        private System.Windows.Forms.CheckBox resampleCheckBox;
        private System.Windows.Forms.NumericUpDown sampleRateNumericUpDown;
        private System.Windows.Forms.Label sampleRateLabel;
        private System.Windows.Forms.CheckBox quantizeCheckBox;
        private System.Windows.Forms.NumericUpDown bitDepthNumericUpDown;
        private System.Windows.Forms.Label bitDepthLabel;
        private System.Windows.Forms.GroupBox envelopeGroupBox;
        private System.Windows.Forms.Label envelopeLabel;
        private System.Windows.Forms.GroupBox namesGroupBox;
        private System.Windows.Forms.CheckBox namesCheckBox;
        private System.Windows.Forms.TextBox namesPathTextBox;
        private System.Windows.Forms.Button namesBrowseButton;
        private System.Windows.Forms.Label namesHintLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
