using System.IO;

namespace FileSignatures.Formats.RiffBased
{
    /// <summary>
    /// Specifies the format of a Google WebP image file.
    /// </summary>
    public class Webp : Image
    {
        /// <summary>
        /// ASCII: `WEBP`
        /// </summary>
        private static readonly byte[] WEBP = { 0x57, 0x45, 0x42, 0x50 };

        public Webp() : base(WEBP, "image/webp", "webp", 8)
        {
        }

        public override bool IsMatch(Stream stream) => base.IsMatch(stream) && RiffContainer.IsRiffBased(stream);
    }
}
