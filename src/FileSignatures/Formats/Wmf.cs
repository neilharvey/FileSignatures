namespace FileSignatures.Formats;

/// <summary>
/// Windows Metafile format.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/image/wmf
/// </remarks>
public class Wmf : FileFormat
{
    public Wmf() : base([0xD7, 0xCD, 0xC6, 0x9A], "image/wmf", "wmf")
    {
    }
}