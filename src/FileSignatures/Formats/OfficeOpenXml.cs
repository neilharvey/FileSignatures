using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace FileSignatures.Formats;

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
    /// <param name="contentTypeOverride">Content type override used to identify a subformat.</param>
    protected OfficeOpenXml(string identifiableEntry, string mediaType, string extension, string? contentTypeOverride = null) : base(int.MaxValue, mediaType, extension)
    {
        if (string.IsNullOrEmpty(identifiableEntry))
        {
            throw new ArgumentNullException(nameof(identifiableEntry));
        }

        IdentifiableEntry = identifiableEntry;
        ContentTypeOverride = contentTypeOverride;
    }

    /// <summary>
    /// Gets the entry in the file which can be used to identify the format.
    /// </summary>
    /// <remarks>
    public string IdentifiableEntry { get; }

    /// <summary>
    /// Content type override used to identify a subformat.
    /// </summary>
    public string? ContentTypeOverride { get; }

    public bool IsMatch(IDisposable? file)
    {
        if (file is not ZipArchive archive)
        {
            return false;
        }

        // Match archives which contain a non-standard version of the identifiable entry, e.g. document2.xml instead of document.xml.
        var index = Math.Max(0, IdentifiableEntry.LastIndexOf('.'));
        var fileName = IdentifiableEntry.Substring(0, IdentifiableEntry.Length - index);
        var extension = IdentifiableEntry.Substring(index);
        var matchesIdentifiableEntry = archive.Entries.Any(e => e.FullName.StartsWith(fileName, StringComparison.OrdinalIgnoreCase)
                && e.FullName.EndsWith(extension, StringComparison.OrdinalIgnoreCase));

        if (!matchesIdentifiableEntry)
        {
            return false;
        }

        if (ContentTypeOverride != null)
        {
            var contentTypesEntry = archive.GetEntry("[Content_Types].xml");

            if (contentTypesEntry == null)
                return false;

            using var stream = contentTypesEntry.Open();
            var doc = XDocument.Load(stream);
            XNamespace ns = "http://schemas.openxmlformats.org/package/2006/content-types";

            return doc
                .Descendants(ns + "Override")
                .Any(e =>
                    (string?)e.Attribute("PartName") == $"/{IdentifiableEntry}" &&
                    (string?)e.Attribute("ContentType") == ContentTypeOverride
                );
        }

        return true;
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
