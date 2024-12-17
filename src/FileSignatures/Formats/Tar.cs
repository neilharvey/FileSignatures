namespace FileSignatures.Formats;

public class Tar: FileFormat
{
    public Tar() : base([(byte)'u',(byte)'s',(byte)'t',(byte)'a',(byte)'r',(byte)' ', (byte)' ',0x00], "application/x-tar", "tar", 257)
    {
        
    }
}