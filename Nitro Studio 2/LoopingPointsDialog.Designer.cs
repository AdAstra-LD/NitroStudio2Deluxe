namespace NitroStudio2 {
    partial class LoopPointsDialog {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.loopEndLabel = new System.Windows.Forms.Label();
            this.loopEndNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.confirmButton = new System.Windows.Forms.Button();
            this.loopLengthLabel = new System.Windows.Forms.Label();
            this.loopStartLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.discardLoopRadioButton = new System.Windows.Forms.RadioButton();
            this.useLoopRadioButton = new System.Windows.Forms.RadioButton();
            this.loopLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.loopStartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopEndNumericUpDown)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopStartNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.loopEndLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.loopEndNumericUpDown, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.confirmButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.loopLengthLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.loopStartLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.loopLengthNumericUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.loopStartNumericUpDown, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 99);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // loopEndLabel
            // 
            this.loopEndLabel.AutoSize = true;
            this.loopEndLabel.Location = new System.Drawing.Point(287, 9);
            this.loopEndLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.loopEndLabel.Name = "loopEndLabel";
            this.loopEndLabel.Size = new System.Drawing.Size(56, 13);
            this.loopEndLabel.TabIndex = 6;
            this.loopEndLabel.Text = "Loop End:";
            // 
            // loopEndNumericUpDown
            // 
            this.loopEndNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loopEndNumericUpDown.Location = new System.Drawing.Point(287, 32);
            this.loopEndNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.loopEndNumericUpDown.Name = "loopEndNumericUpDown";
            this.loopEndNumericUpDown.Size = new System.Drawing.Size(137, 20);
            this.loopEndNumericUpDown.TabIndex = 7;
            this.loopEndNumericUpDown.ValueChanged += new System.EventHandler(this.loopEndNumericUpDown_ValueChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.AutoSize = true;
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.confirmButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmButton.Location = new System.Drawing.Point(287, 58);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(137, 36);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // loopLengthLabel
            // 
            this.loopLengthLabel.AutoSize = true;
            this.loopLengthLabel.Location = new System.Drawing.Point(146, 9);
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
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.discardLoopRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.useLoopRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // discardLoopRadioButton
            // 
            this.discardLoopRadioButton.AutoSize = true;
            this.discardLoopRadioButton.Location = new System.Drawing.Point(133, 3);
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
            this.useLoopRadioButton.Location = new System.Drawing.Point(4, 3);
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
            this.loopLengthNumericUpDown.Location = new System.Drawing.Point(146, 32);
            this.loopLengthNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.loopLengthNumericUpDown.Name = "loopLengthNumericUpDown";
            this.loopLengthNumericUpDown.Size = new System.Drawing.Size(135, 20);
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
            this.loopStartNumericUpDown.Size = new System.Drawing.Size(135, 20);
            this.loopStartNumericUpDown.TabIndex = 5;
            this.loopStartNumericUpDown.ValueChanged += new System.EventHandler(this.loopStartNumericUpDown_ValueChanged);
            // 
            // LoopPointsDialogue
            // 
            this.AcceptButton = this.confirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 99);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoopPointsDialogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loop Points Editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopEndNumericUpDown)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopStartNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label loopStartLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.RadioButton discardLoopRadioButton;
        private System.Windows.Forms.Label loopEndLabel;
        private System.Windows.Forms.NumericUpDown loopEndNumericUpDown;
        private System.Windows.Forms.Label loopLengthLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton useLoopRadioButton;
        private System.Windows.Forms.NumericUpDown loopLengthNumericUpDown;
        private System.Windows.Forms.NumericUpDown loopStartNumericUpDown;
    }
}