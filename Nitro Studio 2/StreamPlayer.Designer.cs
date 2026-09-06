namespace NitroStudio2 {
    partial class StreamPlayer {
        protected override void Dispose(bool disposing) {
            if (disposing) {
                DisposePlayback();
                timer.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(480, 150);
            MinimumSize = new System.Drawing.Size(450, 190);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Stream Player";
        }
    }
}
