namespace FileSignatures.Formats;

public class Gzip: FileFormat
{
    public Gzip() : base([0x1F, 0x8B],3, "application/gzip", "gz")
    {
    }
}