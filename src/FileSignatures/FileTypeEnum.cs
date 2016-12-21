namespace FileSignatures
{
    public partial class FileType
    {
        public static FileType Jpeg = new FileType(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0}, 0, "jpg");
    }
}
