namespace FileSignatures.Formats;

public class Rar5: FileFormat
{
    public Rar5() : base([0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x01, 0x00], 8, "application/vnd.rar","rar")
    {
    }
}