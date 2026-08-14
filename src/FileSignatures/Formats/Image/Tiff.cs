namespace FileSignatures.Formats.Image
{
    /// <summary>
    /// Specifies the format of a Tagged Image File Format (TIFF) image.
    /// </summary>
    public class Tiff : FileFormat
    {
        public Tiff() : this([0x49, 0x49, 0x2A, 0x00])
        {
        }

        protected Tiff(byte[] signature) : base(signature, "image/tiff", "tif", 0)
        {
        }
    }

    /// <summary>
    /// Specifies the format of a Tagged Image File Format (TIFF) image in big-endian byte order.
    /// </summary>
    public class BigEndianTiff : Tiff
    {
        public BigEndianTiff() : base([0x4D, 0x4D, 0x00, 0x2A]) 
        {
        }
    }
}
