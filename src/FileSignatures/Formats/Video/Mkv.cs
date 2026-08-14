namespace FileSignatures.Formats.Video;

/// <summary>
/// Specifies the format of a Matroska video file.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/video/matroska
/// </remarks>
public class Mkv : Ebml
{
    public Mkv() : base("matroska", "video/matroska", "mkv")
    {
    }
}
