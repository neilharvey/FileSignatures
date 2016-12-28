namespace FileSignatures
{
    public partial class FileType
    {
        public static readonly FileType Bmp = new FileType(new byte[] { 0x42, 0x4D }, 0, "bmp", "image/bmp");

        public static readonly FileType Gif = new FileType(new byte[] { 0x47, 0x49, 0x46, 0x38 }, 0, "gif", "image/gif");

        public static readonly FileType Jpeg = new FileType(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, 0, "jpg", "image/jpeg");

        public static readonly FileType Png = new FileType(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, 0, "png", "image/png");
    }
}
