namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a JPEG File Interchange Fomat (JFIF) file.
    /// </summary>
    public class JpegJfif : Jpeg
    {
        public JpegJfif() : base(0xE0)
        {
        }
    }
}
