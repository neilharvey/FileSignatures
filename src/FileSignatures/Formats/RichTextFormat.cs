namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Rich Text Format (RTF) file.
    /// </summary>
    public class RichTextFormat : FileFormat
    {
        public RichTextFormat() : base(new byte[] { 0x7B, 0x5C, 0x72, 0x74, 0x66, 0x31 }, "application/rtf", "rtf")
        {
        }
    }
}
