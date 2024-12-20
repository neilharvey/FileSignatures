namespace FileSignatures.Formats;

/// <summary>
/// Photoshop Document file format.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/image/vnd.adobe.photoshop
/// </remarks>
public class Photoshop : FileFormat
{
    public Photoshop() : base([0x38, 0x42, 0x50, 0x53], 4, "image/vnd.adobe.photoshop", "psd")
    {
    }
}