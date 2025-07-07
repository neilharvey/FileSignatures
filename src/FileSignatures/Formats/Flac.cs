namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a FLAC (Free Lossless Audio Codec) file.
/// </summary>
public class Flac : FileFormat
{
    public Flac() : base([0x66, 0x4C, 0x61, 0x43], "audio/flac", "flac")
    {
    }
}