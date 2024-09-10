using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Office Open XML file.
    /// </summary>
    public abstract class OfficeOpenXml : Zip, IFileFormatReader
    {
        /// <summary>
        /// Initializes a new instance of the OfficeOpenXmlFormat class which matches an archive containing a unique entry.
        /// </summary>
        /// <param name="identifiableEntry">The entry in the archive which is used to identify the format.</param>
        /// <param name="macroEnabled">Should this match office files with macros, or ones without macros</param>
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate extension for the format.</param>
        protected OfficeOpenXml(string identifiableEntry, bool macroEnabled, string mediaType, string extension) : base(int.MaxValue, mediaType, extension)
        {
            if (string.IsNullOrEmpty(identifiableEntry))
            {
                throw new ArgumentNullException(nameof(identifiableEntry));
            }

            IdentifiableEntry = identifiableEntry;
            MacroEnabled = macroEnabled;
        }

        /// <summary>
        /// Gets the entry in the file which can be used to identify the format.
        /// </summary>
        /// <remarks>
        public string IdentifiableEntry { get; }

        /// <summary>
        /// If this file exists in the zip file anywhere, it indicates that the office document supports macros
        /// </summary>
        public const string MacroIdentifiableEntry = "vbaProject.bin";

        /// <summary>
        /// Should this match office files with macros, or ones without macros
        /// </summary>
        public bool MacroEnabled { get; }

        public bool IsMatch(IDisposable? file)
        {
            if (file is ZipArchive archive)
            {
                // Match archives which contain a non-standard version of the identifiable entry, e.g. document2.xml instead of document.xml.
                var index = Math.Max(0, IdentifiableEntry.LastIndexOf('.'));     
                var fileName = IdentifiableEntry.Substring(0, IdentifiableEntry.Length - index);
                var extension = IdentifiableEntry.Substring(index); 
                var matchesIdentifiableEntry = archive.Entries.Any(e => e.FullName.StartsWith(fileName, StringComparison.OrdinalIgnoreCase)
                        && e.FullName.EndsWith(extension, StringComparison.OrdinalIgnoreCase));

                var hasMacros = archive.Entries.Any(e => e.FullName.EndsWith(MacroIdentifiableEntry, StringComparison.OrdinalIgnoreCase));

                return matchesIdentifiableEntry && MacroEnabled == hasMacros;
            }
            else
            {
                return false;
            }
        }

        public IDisposable? Read(Stream stream)
        {
            try
            {
                return new ZipArchive(stream, ZipArchiveMode.Read, true);
            }
            catch (InvalidDataException)
            {
                return null;
            }
        }
    }
}
