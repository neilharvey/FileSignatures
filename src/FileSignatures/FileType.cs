namespace FileSignatures
{
    public class FileType
    {
        public static readonly FileType Bmp = new FileType(new byte[] { 0x42, 0x4D }, "bmp", "image/bmp");

        public static readonly FileType Doc = new FileType(new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, "doc", "application/msword");

        public static readonly FileType Docx = new FileType(new byte[] { 0x50, 0x4B, 0x03, 0x04 }, "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");

        public static readonly FileType Gif = new FileType(new byte[] { 0x47, 0x49, 0x46, 0x38 }, "gif", "image/gif");

        public static readonly FileType Jpeg = new FileType(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, "jpg", "image/jpeg");

        public static readonly FileType Png = new FileType(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");

        public static readonly FileType Pdf = new FileType(new byte[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "application/pdf");

        public static readonly FileType Rtf = new FileType(new byte[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, "rtf", "application/rtf");

        public FileType(byte[] signature, string extension, string mimeType)
        {
            Signature = signature;
            Extension = extension;
            MimeType = mimeType;
        }

        public byte[] Signature { get; }

        public string Extension { get; }

        public string MimeType { get; }
    }
}
