namespace FileSignatures.Formats;

public class GZip: FileFormat
{
    public GZip() : base([ 0x1f, 0x8b, 0x08],3, "application/x-gzip", "gz")
    {
        
    }
}