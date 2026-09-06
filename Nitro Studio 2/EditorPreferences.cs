// Preferences adapted from Raven Penfold's NitroStudio2X configuration feature.
// Source: https://github.com/PokeAlia/NitroStudio2X/commit/84f64ef60d30d03241a9015b3e2a2f351057918a
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace NitroStudio2 {
    internal sealed class EditorPreferences {
        private static readonly string ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "NitroStudio2Deluxe", "preferences.xml");
        public static EditorPreferences Current { get; private set; } = Load();
        public int ImportMode { get; set; }
        public int ExportMode { get; set; }
        public bool WriteNames { get; set; } = true;

        private static EditorPreferences Load() {
            var preferences = new EditorPreferences();
            try {
                if (!File.Exists(ConfigPath)) return preferences;
                using (var reader = XmlReader.Create(ConfigPath, new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit, XmlResolver = null })) {
                    var root = XElement.Load(reader);
                    int mode;
                    bool names;
                    if (int.TryParse((string)root.Attribute("importMode"), out mode) && mode >= 0 && mode <= 2) preferences.ImportMode = mode;
                    if (int.TryParse((string)root.Attribute("exportMode"), out mode) && mode >= 0 && mode <= 1) preferences.ExportMode = mode;
                    if (bool.TryParse((string)root.Attribute("writeNames"), out names)) preferences.WriteNames = names;
                }
            } catch (IOException) { }
              catch (UnauthorizedAccessException) { }
              catch (XmlException) { }
            return preferences;
        }

        public void Save() {
            Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
            string temporary = ConfigPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try {
                new XElement("preferences", new XAttribute("version", 1), new XAttribute("importMode", ImportMode),
                    new XAttribute("exportMode", ExportMode), new XAttribute("writeNames", WriteNames)).Save(temporary);
                if (File.Exists(ConfigPath)) File.Replace(temporary, ConfigPath, null);
                else File.Move(temporary, ConfigPath);
                Current = this;
            } finally {
                if (File.Exists(temporary)) File.Delete(temporary);
            }
        }
    }
}
