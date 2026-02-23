namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of an Audio Video Interleave (AVI) file.
/// </summary>
/// <remarks>
/// AVI files use the RIFF container. The "AVI " FourCC is located at offset 8.
/// See https://www.iana.org/assignments/media-types/video/x-msvideo
/// </remarks>
public class Avi : FileFormat
{
    public Avi() : base([0x41, 0x56, 0x49, 0x20], "video/x-msvideo", "avi", 8)
    {
    }
}
