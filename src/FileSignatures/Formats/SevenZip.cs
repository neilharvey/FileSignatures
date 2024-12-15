namespace FileSignatures.Formats;

public class SevenZip: FileFormat {
    public SevenZip() : base([(byte)'7',(byte)'z',  0xbc, 0xaf,0x27, 0x1c], 6, "application/x-7z-compressed", "7z")
    {
        
    }
}