namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Bitmap image file.
    /// </summary>
    public class BitmapFormat : FileFormat
    {
        public BitmapFormat() : base(new byte[] { 0x42, 0x4D }, "image/bmp", "bmp")
        {
        }
    }
}
