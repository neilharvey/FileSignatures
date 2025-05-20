namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a 7-zip archive.
/// </summary>
/// <remarks>
/// There is no official IANA registration but application/x-7z-compressed is commonly used.
/// See https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/MIME_types/Common_types
/// </remarks>
public class SevenZip : FileFormat
{
    public SevenZip() : base([0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C], 6, "application/x-7z-compressed", "7z")
    {
    }
}