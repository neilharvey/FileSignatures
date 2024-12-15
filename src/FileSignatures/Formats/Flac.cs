namespace FileSignatures.Formats;

public class Flac: FileFormat
{
    public Flac() : base([(byte)'f', (byte)'L', (byte)'a', (byte)'C'], 4, "audio/x-flac", "flac")
    {
    }
}