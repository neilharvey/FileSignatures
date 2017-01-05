namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Bitmap image file.
    /// </summary>
    public class Bmp : Image
    {
        public Bmp() : base(new byte[] { 0x42, 0x4D }, "image/bmp", "bmp")
        {
        }
    }
}
