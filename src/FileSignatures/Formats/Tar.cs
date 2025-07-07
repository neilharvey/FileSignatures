namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a TAR archive file.
/// </summary>
/// <remarks>
/// There is no official IANA registration for the TAR format but application/x-tar is commonly used.
/// See: https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/MIME_types/Common_types
/// </remarks>
public class Tar : FileFormat
{
    public Tar() : base([0x75, 0x73, 0x74, 0x61, 0x72], "application/x-tar", "tar", offset: 257)
    {
    }
}