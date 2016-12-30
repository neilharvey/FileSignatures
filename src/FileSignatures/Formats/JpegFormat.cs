namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Joint Photographics Experts Group (JPEG) image.
    /// </summary>
    public class JpegFormat : FileFormat
    {
        public JpegFormat() : base(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, "image/jpeg", "jpg")
        {
        }
    }
}
