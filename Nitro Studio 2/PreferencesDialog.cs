// Settings UI adapted from Raven Penfold, PokeAlia/NitroStudio2X (e1bb95a).
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NitroStudio2 {
    internal sealed class PreferencesDialog : Form {
        public PreferencesDialog(ComboBox.ObjectCollection importModes, ComboBox.ObjectCollection exportModes) {
            Text = "Preferences";
            ClientSize = new Size(430, 215);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = MaximizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), ColumnCount = 2, RowCount = 4 };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            var import = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            var export = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            foreach (var value in importModes) import.Items.Add(value);
            foreach (var value in exportModes) export.Items.Add(value);
            import.SelectedIndex = Math.Min(EditorPreferences.Current.ImportMode, import.Items.Count - 1);
            export.SelectedIndex = Math.Min(EditorPreferences.Current.ExportMode, export.Items.Count - 1);
            var names = new CheckBox { Text = "Write names in new archives", AutoSize = true, Checked = EditorPreferences.Current.WriteNames };
            layout.Controls.Add(new Label { Text = "Default MIDI importer", AutoSize = true }, 0, 0);
            layout.Controls.Add(import, 1, 0);
            layout.Controls.Add(new Label { Text = "Default MIDI exporter", AutoSize = true }, 0, 1);
            layout.Controls.Add(export, 1, 1);
            layout.Controls.Add(names, 0, 2);
            layout.SetColumnSpan(names, 2);
            var buttons = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            var cancel = new Button { Text = "Cancel", AutoSize = true, DialogResult = DialogResult.Cancel };
            var save = new Button { Text = "Save", AutoSize = true };
            buttons.Controls.Add(cancel);
            buttons.Controls.Add(save);
            layout.Controls.Add(buttons, 0, 3);
            layout.SetColumnSpan(buttons, 2);
            Controls.Add(layout);
            AcceptButton = save;
            CancelButton = cancel;
            save.Click += (s, e) => {
                try {
                    new EditorPreferences { ImportMode = Math.Max(0, import.SelectedIndex), ExportMode = Math.Max(0, export.SelectedIndex), WriteNames = names.Checked }.Save();
                    DialogResult = DialogResult.OK;
                    Close();
                } catch (Exception ex) {
                    MessageBox.Show(this, ex.Message, "Cannot save preferences", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
    }
}
