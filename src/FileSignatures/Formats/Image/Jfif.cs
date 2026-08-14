namespace FileSignatures.Formats.Image;

/// <summary>
/// Specifies the format of a JPEG File Interchange Fomat (JFIF) file.
/// </summary>
public class JpegJfif : Jpeg
{
    public JpegJfif() : base([0xFF, 0xE0])
    {
    }
}
