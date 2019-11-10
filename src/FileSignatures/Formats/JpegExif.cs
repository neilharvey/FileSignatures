namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a JPEG image containing EXIF data.
    /// </summary>
    public class JpegExif : Jpeg
    {
        public JpegExif() : base(new byte[] { 0xFF, 0xE1 })
        {
        }
    }
}
