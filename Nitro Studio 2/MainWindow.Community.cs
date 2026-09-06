// Adapted from Raven Penfold's PokeAlia/NitroStudio2X workflows.
// Original commit links and contributor credit are preserved in commit trailers.
using System;
using System.Windows.Forms;

namespace NitroStudio2 {
    public partial class MainWindow {
        private void InitializeCommunityWorkflows() {
            var import = new ToolStripMenuItem("Replace file from another SDAT…", null, ImportFromSdat);
            editToolStripMenuItem.DropDownItems.Add(import);
            editToolStripMenuItem.DropDownOpening += (s, e) => {
                import.Enabled = FileOpen && SA != null && SdatEntryImport.Supports(tree.SelectedNode?.Parent?.Name);
            };
            var waveList = new ToolStripMenuItem("Replace wave archive from list…", null, ImportWaveList);
            editToolStripMenuItem.DropDownItems.Add(waveList);
            editToolStripMenuItem.DropDownOpening += (s, e) => {
                waveList.Enabled = FileOpen && SA != null && tree.SelectedNode?.Parent?.Name == "waveArchives";
            };
            toolsToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem("Preferences…", null, ShowPreferences));

            // Raven Penfold's Shift-click reference navigation, with missing-target guards.
            AddReferenceNavigation(seqBankComboBox, "banks", () => (int)seqBankBox.Value);
            AddReferenceNavigation(seqPlayerComboBox, "players", () => (int)seqPlayerBox.Value);
            AddReferenceNavigation(stmPlayerComboBox, "streamPlayers", () => (int)stmPlayerBox.Value);
            AddReferenceNavigation(bnkWar0ComboBox, "waveArchives", () => (int)bnkWar0Box.Value);
            AddReferenceNavigation(bnkWar1ComboBox, "waveArchives", () => (int)bnkWar1Box.Value);
            AddReferenceNavigation(bnkWar2ComboBox, "waveArchives", () => (int)bnkWar2Box.Value);
            AddReferenceNavigation(bnkWar3ComboBox, "waveArchives", () => (int)bnkWar3Box.Value);
        }

        public override void newToolStripMenuItem_Click(object sender, EventArgs e) {
            var previous = File;
            base.newToolStripMenuItem_Click(sender, e);
            if (SA != null && !ReferenceEquals(previous, File)) {
                SA.SaveSymbols = EditorPreferences.Current.WriteNames;
                DoInfoStuff();
            }
        }

        private void ShowPreferences(object sender, EventArgs e) {
            using (var dialog = new PreferencesDialog(seqImportModeBox.Items, seqExportModeBox.Items)) {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                seqImportModeBox.SelectedIndex = EditorPreferences.Current.ImportMode;
                seqExportModeBox.SelectedIndex = EditorPreferences.Current.ExportMode;
            }
        }

        private void ImportWaveList(object sender, EventArgs e) {
            if (SA == null || tree.SelectedNode?.Parent?.Name != "waveArchives") return;
            int index = GetIdFromNode(tree.SelectedNode);
            using (var open = new OpenFileDialog { Filter = "Ordered wave list|*.swls", RestoreDirectory = true }) {
                if (open.ShowDialog(this) != DialogResult.OK) return;
                try {
                    var imported = WaveListImport.Read(open.FileName);
                    Player?.Stop();
                    SdatEntryImport.Replace(SA, "waveArchives", index, imported);
                    UpdateNodes();
                    DoInfoStuff();
                } catch (Exception ex) {
                    MessageBox.Show(this, ex.Message, "Wave list import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddReferenceNavigation(ComboBox control, string category, Func<int> index) {
            toolTip.SetToolTip(control, toolTip.GetToolTip(control) + "\nShift-click to select the referenced entry.");
            control.MouseDown += (s, e) => {
                if (e.Button != MouseButtons.Left || (ModifierKeys & Keys.Shift) == 0 || SA == null) return;
                var target = tree.Nodes[category]?.Nodes["entry" + index()];
                if (target == null) return;
                control.DroppedDown = false;
                tree.SelectedNode = target;
                target.EnsureVisible();
                tree.Focus();
                DoInfoStuff();
            };
        }

        private void ImportFromSdat(object sender, EventArgs e) {
            string category = tree.SelectedNode?.Parent?.Name;
            if (!FileOpen || SA == null || !SdatEntryImport.Supports(category)) return;
            int index = GetIdFromNode(tree.SelectedNode);
            using (var dialog = new ImportFromSdatDialog(category, tree.SelectedNode.Text)) {
                if (dialog.ShowDialog(this) != DialogResult.OK || dialog.SelectedEntry == null) return;
                try {
                    Player?.Stop();
                    SdatEntryImport.Replace(SA, category, index, dialog.SelectedEntry.File);
                    UpdateNodes();
                    DoInfoStuff();
                    status.Text = "Imported " + dialog.SelectedEntry + ". Verify the destination references before saving.";
                } catch (Exception ex) {
                    MessageBox.Show(this, ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
