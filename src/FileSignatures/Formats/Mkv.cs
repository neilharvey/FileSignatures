namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Matroska video file.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/video/x-matroska
/// </remarks>
public class Mkv : FileFormat
{
    public Mkv() : base([0x1A, 0x45, 0xD5, 0xA3], "video/x-matroska", "mkv")
    {
    }
}
