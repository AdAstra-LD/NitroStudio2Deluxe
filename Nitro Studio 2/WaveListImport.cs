// Adapted from Raven Penfold's ordered SWLS builder:
// https://github.com/PokeAlia/NitroStudio2X/commit/3bf6d6e3e36571264931032739acc0485caac397
using GotaSoundIO.Sound;
using NitroFileLoader;
using System;
using System.IO;

namespace NitroStudio2 {
    internal static class WaveListImport {
        public static WaveArchive Read(string listPath) {
            var archive = new WaveArchive();
            string directory = Path.GetDirectoryName(Path.GetFullPath(listPath));
            int lineNumber = 0;
            foreach (string line in File.ReadLines(listPath)) {
                lineNumber++;
                string name = line.Trim();
                if (name.Length == 0 || name.StartsWith("#")) continue;
                if (name.StartsWith("\"") && name.EndsWith("\"") && name.Length >= 2) name = name.Substring(1, name.Length - 2);
                try {
                    string path = Path.GetFullPath(Path.Combine(directory, name));
                    var wave = new Wave();
                    switch (Path.GetExtension(path).ToLowerInvariant()) {
                        case ".swav": wave.Read(path); break;
                        case ".wav": wave.FromOtherStreamFile(new RiffWave(path)); break;
                        default: throw new InvalidDataException("Expected a WAV or SWAV filename.");
                    }
                    if (wave.SampleRate == 0) throw new InvalidDataException("The wave has a zero sample rate.");
                    if (wave.Loops && (wave.LoopStart >= wave.LoopEnd || wave.LoopEnd > wave.Audio.NumSamples))
                        throw new InvalidDataException("The wave's loop does not fit its sample data.");
                    archive.Waves.Add(wave);
                } catch (Exception ex) {
                    throw new InvalidDataException("Wave list line " + lineNumber + " (" + name + "): " + ex.Message, ex);
                }
            }
            if (archive.Waves.Count == 0) throw new InvalidDataException("The wave list contains no samples.");
            return archive;
        }
    }
}
