namespace FileSignatures
{
    public partial class FileFormat
    {
        public static readonly FileFormat Bmp = new FileFormat(new byte[] { 0x42, 0x4D }, "bmp", "image/bmp");

        public static readonly FileFormat Doc = new OleCompoundFileFormat(new byte[] { 0xEC, 0xA5, 0xC1, 0x00 }, "doc", "application/msword");

        public static readonly FileFormat Docx = new FileFormat(new byte[] { 0x50, 0x4B, 0x03, 0x04 }, "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");

        public static readonly FileFormat Gif = new FileFormat(new byte[] { 0x47, 0x49, 0x46, 0x38 }, "gif", "image/gif");

        public static readonly FileFormat Jpeg = new FileFormat(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, "jpg", "image/jpeg");

        public static readonly FileFormat Png = new FileFormat(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "png", "image/png");

        public static readonly FileFormat Pdf = new FileFormat(new byte[] { 0x25, 0x50, 0x44, 0x46 }, "pdf", "application/pdf");

        public static readonly FileFormat Ppt = new OleCompoundFileFormat(new byte[] { 0xFD, 0xFF, 0xFF, 0xFF }, "ppt", "application/vnd.ms-powerpoint");

        public static readonly FileFormat Rtf = new FileFormat(new byte[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, "rtf", "application/rtf");

        public static readonly FileFormat Xls = new OleCompoundFileFormat(new byte[] { 0x09, 0x08, 0x10, 0x00 }, "xls", "application/vnd.ms-excel");
    }
}
