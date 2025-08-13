using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Powerpoint presentation that supports macros.
    /// </summary>
    public class PowerPointWithMacros : OfficeOpenXml, IFileFormatReader
    {
        public PowerPointWithMacros() : base("ppt/presentation.xml", "application/vnd.ms-powerpoint.presentation.macroEnabled.12", "pptm")
        {
        }

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

                var contentTypesEntry = archive.GetEntry("[Content_Types].xml");

                if (contentTypesEntry == null)
                    return false;

                bool hasMacroContentType = false;
                using (var stream = contentTypesEntry.Open())
                {
                    var doc = System.Xml.Linq.XDocument.Load(stream);
                    XNamespace ns = "http://schemas.openxmlformats.org/package/2006/content-types";
                    hasMacroContentType = doc
                        .Descendants(ns + "Override")
                        .Any(e =>
                            (string?)e.Attribute("PartName") == "/ppt/presentation.xml" &&
                            (string?)e.Attribute("ContentType") == "application/vnd.ms-powerpoint.presentation.macroEnabled.main+xml"
                        );
                }

                return matchesIdentifiableEntry && hasMacroContentType;
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
