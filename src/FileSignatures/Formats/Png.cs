namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Portable Network Graphics (PNG) image.
    /// </summary>
    public class Png : Image
    {
        public Png() : base(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "image/png", "png")
        {
        }
    }
}
