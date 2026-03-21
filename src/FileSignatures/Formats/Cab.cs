namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Microsoft Cabinet archive file.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/application/vnd.ms-cab-compressed
/// </remarks>
public class Cab : FileFormat
{
    public Cab() : base([0x4D, 0x53, 0x43, 0x46], "application/vnd.ms-cab-compressed", "cab")
    {
    }
}
