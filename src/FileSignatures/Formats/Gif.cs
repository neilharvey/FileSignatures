namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of Graphics Interchange Format (GIF) image.
    /// </summary>
    public class Gif : Image
    {
        public Gif() : base(new byte[] { 0x47, 0x49, 0x46, 0x38 }, "image/gif", "gif")
        {
        }
    }
}
