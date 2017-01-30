namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Joint Photographics Experts Group (JPEG) image.
    /// </summary>
    public class Jpeg : Image
    {
        public Jpeg() : base(new byte[] { 0xFF, 0xD8, 0xFF }, "image/jpeg", "jpg")
        {
        }

        protected Jpeg(byte finalByte) : base(new byte[] { 0xFF, 0xD8, 0xFF, finalByte }, "image/jpeg", "jpg")
        {
        }
    }
}
