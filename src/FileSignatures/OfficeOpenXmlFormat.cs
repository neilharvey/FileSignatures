using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace FileSignatures
{
    public class OfficeOpenXmlFormat : FileFormat
    {
        public OfficeOpenXmlFormat(string identifiableEntry, string mediaType, string extension) : base(new byte[] { 0x50, 0x4B, 0x03, 0x04 }, int.MaxValue, mediaType, extension)
        {
            if(string.IsNullOrEmpty(identifiableEntry))
            {
                throw new ArgumentNullException(nameof(identifiableEntry));
            }

            IdentifiableEntry = identifiableEntry;
        }

        public string IdentifiableEntry { get; }

        public override bool IsMatch(byte[] header)
        {
            if (!base.IsMatch(header))
            {
                return false;
            }

            using (var stream = new MemoryStream(header))
            {
                //InvalidDataException
                using (var archive = new ZipArchive(stream, ZipArchiveMode.Read))
                {
                    return archive.Entries.Any(e => e.FullName.Equals(IdentifiableEntry, StringComparison.OrdinalIgnoreCase));
                }
            }
        }
    }
}
