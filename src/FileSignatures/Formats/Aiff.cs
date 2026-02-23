namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of an Audio Interchange File Format (AIFF) file.
/// </summary>
/// <remarks>
/// AIFF files use the IFF/FORM container. The "AIFF" FourCC is located at offset 8.
/// See https://www.iana.org/assignments/media-types/audio/aiff
/// </remarks>
public class Aiff : FileFormat
{
    public Aiff() : base([0x41, 0x49, 0x46, 0x46], "audio/aiff", "aiff", 8)
    {
    }
}
