namespace FileSignatures.Formats.Audio;

/// <summary>
/// Specifies the format of an Ogg Vorbis Codec compressed Multimedia file
/// </summary>
public class Ogg : FileFormat
{
    public Ogg() : base([0x4F, 0x67, 0x67, 0x53, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00], "audio/ogg", "ogg") { }
}
