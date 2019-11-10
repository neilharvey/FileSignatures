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
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate extension for the format.</param>
        protected OfficeOpenXml(string identifiableEntry, string mediaType, string extension) : base(int.MaxValue, mediaType, extension)
        {
            if (string.IsNullOrEmpty(identifiableEntry))
            {
                throw new ArgumentNullException(nameof(identifiableEntry));
            }

            IdentifiableEntry = identifiableEntry;
        }

        /// <summary>
        /// Gets the entry in the file which can be used to identify the format.
        /// </summary>
        /// <remarks>
        public string IdentifiableEntry { get; }

        public bool IsMatch(IDisposable? file)
        {
            if(file is ZipArchive archive)
            {
                return archive.Entries.Any(e => e.FullName.Equals(IdentifiableEntry, StringComparison.OrdinalIgnoreCase));
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
