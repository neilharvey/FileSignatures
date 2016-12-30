namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Joint Photographics Experts Group (JPEG) image.
    /// </summary>
    public class Jpeg : FileFormat
    {
        public Jpeg() : base(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, "image/jpeg", "jpg")
        {
        }
    }
}
