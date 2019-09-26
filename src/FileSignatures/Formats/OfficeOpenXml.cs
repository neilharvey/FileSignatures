using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Office Open XML file.
    /// </summary>
    public abstract class OfficeOpenXml : Zip
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

        /// <summary>
        /// Returns a value indicating whether the format matches a file header.
        /// </summary>
        /// <param name="header">The header to check.</param>
        public override bool IsMatch(byte[] header)
        {
            if (!base.IsMatch(header))
            {
                return false;
            }

            using var stream = new MemoryStream(header);
            ZipArchive? archive = null;

            try
            {
                archive = new ZipArchive(stream, ZipArchiveMode.Read);
                return archive.Entries.Any(e => e.FullName.Equals(IdentifiableEntry, StringComparison.OrdinalIgnoreCase));
            }
            catch (InvalidDataException)
            {
                return false;
            }
            finally
            {
                if (archive != null)
                {
                    archive.Dispose();
                }
            }
        }
    }
}
