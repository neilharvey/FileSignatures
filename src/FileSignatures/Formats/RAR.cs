namespace FileSignatures.Formats;

public class RAR: FileFormat
{
    public RAR() : base([(byte)'R', (byte)'a', (byte)'r',(byte)'!', 0x1A, 0x07, 0x00], 7, "application/x-rar-compressed","rar")
    {
        
    }
}