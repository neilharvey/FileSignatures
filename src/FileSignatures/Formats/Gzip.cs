namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a gzip archive.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/application/gzip
/// </remarks>
public class Gzip : FileFormat
{
    public Gzip() : base([0x1F, 0x8B], 3, "application/gzip", "gz")
    {
    }
}