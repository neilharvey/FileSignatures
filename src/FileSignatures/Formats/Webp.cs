namespace FileSignatures.Formats
{
    /// <summary>
    /// Google WebP image file format.
    /// </summary>
    /// <remarks>
    /// See https://www.iana.org/assignments/media-types/image/webp
    /// </remarks>
    public class Webp : Image
    {
        public Webp() : base([0x57, 0x45, 0x42, 0x50], "image/webp", "webp", offset: 8)
        {
        }
    }
}
