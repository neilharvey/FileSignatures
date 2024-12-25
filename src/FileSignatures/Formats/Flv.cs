namespace FileSignatures.Formats;

public class Flv:FileFormat
{
    public Flv() : base([(byte)'F',(byte)'L',(byte)'V'], 3, "video/x-flv","flv")
    {
    }
}