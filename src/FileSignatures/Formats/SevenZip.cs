namespace FileSignatures.Formats;

public class SevenZip: FileFormat {
    public SevenZip() : base([0x37, 0x7A, 0xBC, 0xAF, 0x27, 0x1C], 6, "application/x-7z-compressed", "7z")
    {
        
    }
}