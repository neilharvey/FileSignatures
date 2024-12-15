namespace FileSignatures.Formats;

public class RAR: FileFormat
{
    public RAR() : base("Rar!\x1A\x07\x00", 7, "application/x-rar-compressed","rar")
    {
        
    }
}