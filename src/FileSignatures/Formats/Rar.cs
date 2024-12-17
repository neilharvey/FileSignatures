namespace FileSignatures.Formats;

public class Rar: FileFormat
{
    public Rar() : base([0x52, 0x61 ,0x72 ,0x21, 0x1A, 0x07, 0x00], 7, "application/x-rar-compressed","rar")
    {
    }
}