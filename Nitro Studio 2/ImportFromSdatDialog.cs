// SDAT selection workflow adapted from Raven Penfold, PokeAlia/NitroStudio2X
// commit f44e2a7d6ff958c576c17c5de6db3c453c273124; see commit trailers.
using NitroFileLoader;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NitroStudio2 {
    internal sealed class ImportFromSdatDialog : Form {
        private readonly ComboBox entries = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly Label sourceName = new Label { Text = "Choose a source SDAT.", AutoSize = true };
        private readonly Button import = new Button { Text = "Replace file", AutoSize = true, Enabled = false, DialogResult = DialogResult.OK };
        private readonly string category;
        public SdatImportEntry SelectedEntry => entries.SelectedItem as SdatImportEntry;

        public ImportFromSdatDialog(string category, string target) {
            this.category = category;
            Text = "Import from another SDAT";
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = MaximizeBox = false;
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 225);
            MinimumSize = new Size(450, 260);
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), ColumnCount = 1, RowCount = 5 };
            var browse = new Button { Text = "Open source SDAT…", AutoSize = true };
            browse.Click += Browse;
            layout.Controls.Add(browse);
            layout.Controls.Add(sourceName);
            layout.Controls.Add(entries);
            layout.Controls.Add(new Label { AutoSize = true, MaximumSize = new Size(510, 0), Text = "Replace " + target + ". Only the selected file is imported. Destination names, indices, bank/wave references and player settings are retained; verify them after import." });
            var buttons = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            var cancel = new Button { Text = "Cancel", AutoSize = true, DialogResult = DialogResult.Cancel };
            buttons.Controls.Add(cancel);
            buttons.Controls.Add(import);
            layout.Controls.Add(buttons);
            Controls.Add(layout);
            AcceptButton = import;
            CancelButton = cancel;
        }

        private void Browse(object sender, EventArgs e) {
            using (var open = new OpenFileDialog { Filter = "Sound archive|*.sdat", RestoreDirectory = true }) {
                if (open.ShowDialog(this) != DialogResult.OK) return;
                entries.DataSource = null;
                import.Enabled = false;
                try {
                    var items = SdatEntryImport.Entries(new SoundArchive(open.FileName), category);
                    entries.DataSource = items;
                    sourceName.Text = System.IO.Path.GetFileName(open.FileName);
                    import.Enabled = items.Count > 0;
                    if (items.Count == 0) sourceName.Text += " — no matching files.";
                } catch (Exception ex) {
                    sourceName.Text = "Could not open the source archive.";
                    MessageBox.Show(this, ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
