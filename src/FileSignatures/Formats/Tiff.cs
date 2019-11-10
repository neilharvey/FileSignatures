namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Tagged Image File Format (TIFF) image.
    /// </summary>
    public class Tiff : Image
    {
        public Tiff() : base(new byte[] { 0x49, 0x49, 0x2A, 00 }, "image/tiff", "tif")
        {
        }
    }
}
