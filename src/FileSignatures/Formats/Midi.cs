namespace FileSignatures.Formats;

public class Midi: FileFormat
{
    public Midi() : base([(byte)'M',(byte)'T',(byte)'h',(byte)'d'], "audio/mime", "mid")
    {
    }
}