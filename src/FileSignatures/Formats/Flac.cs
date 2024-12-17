namespace FileSignatures.Formats;

public class Flac: FileFormat
{
    public Flac() : base([0x66, 0x4C, 0x61, 0x43], 4, "audio/x-flac", "flac")
    {
    }
}