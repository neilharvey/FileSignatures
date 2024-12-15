namespace FileSignatures.Formats;

public class StevenZip: FileFormat {
    public StevenZip() : base(new byte[]{(byte)'7',(byte)'z',  0xbc, 0xaf,0x27, 0x1c}, 6, "application/x-7z-compressed", "7z")
    {
        
    }
}