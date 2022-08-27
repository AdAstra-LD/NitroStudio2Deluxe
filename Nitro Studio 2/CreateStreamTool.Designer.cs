namespace NitroStudio2 {
    partial class CreateStreamTool {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateStreamTool));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.impFileBox = new System.Windows.Forms.TextBox();
            this.impFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.outFileBox = new System.Windows.Forms.TextBox();
            this.outFileButton = new System.Windows.Forms.Button();
            this.outputFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.loopingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loopEndLabel = new System.Windows.Forms.Label();
            this.loopEndNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.loopLengthLabel = new System.Windows.Forms.Label();
            this.loopStartLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.discardLoopRadioButton = new System.Windows.Forms.RadioButton();
            this.useLoopRadioButton = new System.Windows.Forms.RadioButton();
            this.loopLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.loopStartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.loopingTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopEndNumericUpDown)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopStartNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.7971F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2029F));
            this.tableLayoutPanel1.Controls.Add(this.impFileBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.impFileButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // impFileBox
            // 
            this.impFileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.impFileBox.Location = new System.Drawing.Point(3, 3);
            this.impFileBox.Name = "impFileBox";
            this.impFileBox.ReadOnly = true;
            this.impFileBox.Size = new System.Drawing.Size(317, 20);
            this.impFileBox.TabIndex = 0;
            // 
            // impFileButton
            // 
            this.impFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.impFileButton.Location = new System.Drawing.Point(326, 3);
            this.impFileButton.Name = "impFileButton";
            this.impFileButton.Size = new System.Drawing.Size(48, 23);
            this.impFileButton.TabIndex = 1;
            this.impFileButton.Text = "...";
            this.impFileButton.UseVisualStyleBackColor = true;
            this.impFileButton.Click += new System.EventHandler(this.impFileButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output File:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.7971F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2029F));
            this.tableLayoutPanel2.Controls.Add(this.outFileBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.outFileButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 80);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(377, 29);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // outFileBox
            // 
            this.outFileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outFileBox.Location = new System.Drawing.Point(3, 3);
            this.outFileBox.Name = "outFileBox";
            this.outFileBox.ReadOnly = true;
            this.outFileBox.Size = new System.Drawing.Size(317, 20);
            this.outFileBox.TabIndex = 0;
            // 
            // outFileButton
            // 
            this.outFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outFileButton.Location = new System.Drawing.Point(326, 3);
            this.outFileButton.Name = "outFileButton";
            this.outFileButton.Size = new System.Drawing.Size(48, 23);
            this.outFileButton.TabIndex = 1;
            this.outFileButton.Text = "...";
            this.outFileButton.UseVisualStyleBackColor = true;
            this.outFileButton.Click += new System.EventHandler(this.outFileButton_Click);
            // 
            // outputFormat
            // 
            this.outputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputFormat.FormattingEnabled = true;
            this.outputFormat.Items.AddRange(new object[] {
            "PCM8",
            "PCM16",
            "IMA-ADPCM"});
            this.outputFormat.Location = new System.Drawing.Point(12, 240);
            this.outputFormat.Name = "outputFormat";
            this.outputFormat.Size = new System.Drawing.Size(377, 21);
            this.outputFormat.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(12, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(377, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Format:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(12, 267);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(377, 43);
            this.exportButton.TabIndex = 6;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // loopingTableLayoutPanel
            // 
            this.loopingTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loopingTableLayoutPanel.ColumnCount = 3;
            this.loopingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.loopingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.loopingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.loopingTableLayoutPanel.Controls.Add(this.loopEndLabel, 2, 0);
            this.loopingTableLayoutPanel.Controls.Add(this.loopEndNumericUpDown, 2, 1);
            this.loopingTableLayoutPanel.Controls.Add(this.loopLengthLabel, 1, 0);
            this.loopingTableLayoutPanel.Controls.Add(this.loopStartLabel, 0, 0);
            this.loopingTableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.loopingTableLayoutPanel.Controls.Add(this.loopLengthNumericUpDown, 1, 1);
            this.loopingTableLayoutPanel.Controls.Add(this.loopStartNumericUpDown, 0, 1);
            this.loopingTableLayoutPanel.Enabled = false;
            this.loopingTableLayoutPanel.Location = new System.Drawing.Point(12, 121);
            this.loopingTableLayoutPanel.Name = "loopingTableLayoutPanel";
            this.loopingTableLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.loopingTableLayoutPanel.RowCount = 3;
            this.loopingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loopingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loopingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loopingTableLayoutPanel.Size = new System.Drawing.Size(377, 89);
            this.loopingTableLayoutPanel.TabIndex = 7;
            // 
            // loopEndLabel
            // 
            this.loopEndLabel.AutoSize = true;
            this.loopEndLabel.Location = new System.Drawing.Point(253, 9);
            this.loopEndLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.loopEndLabel.Name = "loopEndLabel";
            this.loopEndLabel.Size = new System.Drawing.Size(56, 13);
            this.loopEndLabel.TabIndex = 6;
            this.loopEndLabel.Text = "Loop End:";
            // 
            // loopEndNumericUpDown
            // 
            this.loopEndNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loopEndNumericUpDown.Location = new System.Drawing.Point(253, 32);
            this.loopEndNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.loopEndNumericUpDown.Name = "loopEndNumericUpDown";
            this.loopEndNumericUpDown.Size = new System.Drawing.Size(119, 20);
            this.loopEndNumericUpDown.TabIndex = 7;
            this.loopEndNumericUpDown.ValueChanged += new System.EventHandler(this.loopEndNumericUpDown_ValueChanged);
            // 
            // loopLengthLabel
            // 
            this.loopLengthLabel.AutoSize = true;
            this.loopLengthLabel.Location = new System.Drawing.Point(129, 9);
            this.loopLengthLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.loopLengthLabel.Name = "loopLengthLabel";
            this.loopLengthLabel.Size = new System.Drawing.Size(70, 13);
            this.loopLengthLabel.TabIndex = 3;
            this.loopLengthLabel.Text = "Loop Length:";
            // 
            // loopStartLabel
            // 
            this.loopStartLabel.AutoSize = true;
            this.loopStartLabel.Location = new System.Drawing.Point(5, 9);
            this.loopStartLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.loopStartLabel.Name = "loopStartLabel";
            this.loopStartLabel.Size = new System.Drawing.Size(59, 13);
            this.loopStartLabel.TabIndex = 0;
            this.loopStartLabel.Text = "Loop Start:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.loopingTableLayoutPanel.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.discardLoopRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.useLoopRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(367, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // discardLoopRadioButton
            // 
            this.discardLoopRadioButton.AutoSize = true;
            this.discardLoopRadioButton.Location = new System.Drawing.Point(224, 3);
            this.discardLoopRadioButton.Name = "discardLoopRadioButton";
            this.discardLoopRadioButton.Padding = new System.Windows.Forms.Padding(3);
            this.discardLoopRadioButton.Size = new System.Drawing.Size(140, 23);
            this.discardLoopRadioButton.TabIndex = 3;
            this.discardLoopRadioButton.Text = "Discard Looping Points";
            this.discardLoopRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.discardLoopRadioButton.UseVisualStyleBackColor = true;
            this.discardLoopRadioButton.CheckedChanged += new System.EventHandler(this.discardLoopRadioButton_CheckedChanged);
            // 
            // useLoopRadioButton
            // 
            this.useLoopRadioButton.AutoSize = true;
            this.useLoopRadioButton.Checked = true;
            this.useLoopRadioButton.Location = new System.Drawing.Point(95, 3);
            this.useLoopRadioButton.Name = "useLoopRadioButton";
            this.useLoopRadioButton.Padding = new System.Windows.Forms.Padding(3);
            this.useLoopRadioButton.Size = new System.Drawing.Size(123, 23);
            this.useLoopRadioButton.TabIndex = 2;
            this.useLoopRadioButton.TabStop = true;
            this.useLoopRadioButton.Text = "Use Looping Points";
            this.useLoopRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.useLoopRadioButton.UseVisualStyleBackColor = true;
            this.useLoopRadioButton.CheckedChanged += new System.EventHandler(this.useLoopRadioButton_CheckedChanged);
            // 
            // loopLengthNumericUpDown
            // 
            this.loopLengthNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loopLengthNumericUpDown.Location = new System.Drawing.Point(129, 32);
            this.loopLengthNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.loopLengthNumericUpDown.Name = "loopLengthNumericUpDown";
            this.loopLengthNumericUpDown.Size = new System.Drawing.Size(118, 20);
            this.loopLengthNumericUpDown.TabIndex = 4;
            this.loopLengthNumericUpDown.ValueChanged += new System.EventHandler(this.loopLengthNumericUpDown_ValueChanged);
            // 
            // loopStartNumericUpDown
            // 
            this.loopStartNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loopStartNumericUpDown.Location = new System.Drawing.Point(5, 32);
            this.loopStartNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.loopStartNumericUpDown.Name = "loopStartNumericUpDown";
            this.loopStartNumericUpDown.Size = new System.Drawing.Size(118, 20);
            this.loopStartNumericUpDown.TabIndex = 5;
            this.loopStartNumericUpDown.ValueChanged += new System.EventHandler(this.loopStartNumericUpDown_ValueChanged);
            // 
            // CreateStreamTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(401, 317);
            this.Controls.Add(this.loopingTableLayoutPanel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateStreamTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Stream";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.loopingTableLayoutPanel.ResumeLayout(false);
            this.loopingTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopEndNumericUpDown)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopStartNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox impFileBox;
        private System.Windows.Forms.Button impFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox outFileBox;
        private System.Windows.Forms.Button outFileButton;
        private System.Windows.Forms.ComboBox outputFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TableLayoutPanel loopingTableLayoutPanel;
        private System.Windows.Forms.Label loopEndLabel;
        private System.Windows.Forms.NumericUpDown loopEndNumericUpDown;
        private System.Windows.Forms.Label loopLengthLabel;
        private System.Windows.Forms.Label loopStartLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton discardLoopRadioButton;
        private System.Windows.Forms.RadioButton useLoopRadioButton;
        private System.Windows.Forms.NumericUpDown loopLengthNumericUpDown;
        private System.Windows.Forms.NumericUpDown loopStartNumericUpDown;
    }
}