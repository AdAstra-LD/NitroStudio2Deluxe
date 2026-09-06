// Adapted from Raven Penfold's SDAT import in PokeAlia/NitroStudio2X.
// Source: https://github.com/PokeAlia/NitroStudio2X/commit/f44e2a7d6ff958c576c17c5de6db3c453c273124
using GotaSoundIO.IO;
using NitroFileLoader;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NitroStudio2 {
    internal sealed class SdatImportEntry {
        public int Index { get; set; }
        public string Name { get; set; }
        public IOFile File { get; set; }
        public override string ToString() => "[" + Index + "] " + Name;
    }

    internal static class SdatEntryImport {
        public static bool Supports(string category) => category == "sequences" ||
            category == "sequenceArchives" || category == "banks" ||
            category == "waveArchives" || category == "streams";

        public static List<SdatImportEntry> Entries(SoundArchive archive, string category) {
            if (archive == null) throw new ArgumentNullException(nameof(archive));
            IEnumerable<SdatImportEntry> entries;
            switch (category) {
                case "sequences": entries = archive.Sequences.Select(e => new SdatImportEntry { Index = e.Index, Name = e.Name, File = e.File }); break;
                case "sequenceArchives": entries = archive.SequenceArchives.Select(e => new SdatImportEntry { Index = e.Index, Name = e.Name, File = e.File }); break;
                case "banks": entries = archive.Banks.Select(e => new SdatImportEntry { Index = e.Index, Name = e.Name, File = e.File }); break;
                case "waveArchives": entries = archive.WaveArchives.Select(e => new SdatImportEntry { Index = e.Index, Name = e.Name, File = e.File }); break;
                case "streams": entries = archive.Streams.Select(e => new SdatImportEntry { Index = e.Index, Name = e.Name, File = e.File }); break;
                default: throw new ArgumentException("Select a sequence, sequence archive, bank, wave archive or stream.", nameof(category));
            }
            return entries.Where(e => e.File != null).OrderBy(e => e.Index).ToList();
        }

        // Deserialize completely before replacing the destination payload. Metadata and
        // references belong to the destination; never share mutable files between archives.
        public static void Replace(SoundArchive destination, string category, int index, IOFile source) {
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            if (source == null) throw new ArgumentNullException(nameof(source));
            IOFile copy;
            Action<IOFile> assign;
            switch (category) {
                case "sequences":
                    var seq = destination.Sequences.Single(e => e.Index == index);
                    copy = new Sequence(); assign = f => seq.File = (Sequence)f; break;
                case "sequenceArchives":
                    var sar = destination.SequenceArchives.Single(e => e.Index == index);
                    copy = new SequenceArchive(); assign = f => sar.File = (SequenceArchive)f; break;
                case "banks":
                    var bank = destination.Banks.Single(e => e.Index == index);
                    copy = new Bank(); assign = f => bank.File = (Bank)f; break;
                case "waveArchives":
                    var war = destination.WaveArchives.Single(e => e.Index == index);
                    copy = new WaveArchive(); assign = f => war.File = (WaveArchive)f; break;
                case "streams":
                    var stream = destination.Streams.Single(e => e.Index == index);
                    copy = new NitroFileLoader.Stream(); assign = f => stream.File = (NitroFileLoader.Stream)f; break;
                default: throw new ArgumentException("Unsupported entry type.", nameof(category));
            }
            if (source.GetType() != copy.GetType()) throw new ArgumentException("The source and destination must have the same file type.", nameof(source));
            copy.Read(source.Write());
            assign(copy);
        }
    }
}
