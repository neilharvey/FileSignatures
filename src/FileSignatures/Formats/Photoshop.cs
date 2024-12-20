namespace FileSignatures.Formats;

public class Photoshop:FileFormat
{
    public Photoshop(): base([(byte)'8',(byte)'B',(byte)'P',(byte)'S'], 4, "image/psd", "psd")
    {
    }
}