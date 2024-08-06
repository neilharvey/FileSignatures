namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of an icon file.
/// </summary>
/// <see cref="https://www.iana.org/assignments/media-types/image/vnd.microsoft.icon"/>
public class Icon : Image
{
    public Icon() : base([0x00, 0x00, 0x01, 0x00], "image/vnd.microsoft.icon", "ico")
    {
    }
}