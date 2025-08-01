namespace FileSignatures.Formats;

public class Rar4: FileFormat
{
    public Rar4() : base([0x52, 0x61 ,0x72 ,0x21, 0x1A, 0x07, 0x00], 7, "application/vnd.rar","rar")
    {
    }
}