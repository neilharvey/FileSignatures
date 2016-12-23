namespace FileSignatures
{
    public partial class FileType
    {
        public static FileType Bmp = new FileType(new byte[] { 0x42, 0x4D }, 0, "bmp");

        public static FileType Gif = new FileType(new byte[] { 0x47, 0x49, 0x46, 0x38 }, 0, "gif");

        public static FileType Jpeg = new FileType(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, 0, "jpg");

        public static FileType Png = new FileType(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, 0, "png");
    }
}
