using System.IO;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Google WebP image file.
    /// </summary>
    public class Webp : Image
    {
        private static readonly byte[] RIFF = {0x52, 0x49, 0x46, 0x46};
        private static readonly byte[] WEBP = {0x57, 0x45, 0x42, 0x50};

        public Webp() : base(WEBP, "image/webp", "webp", offset: 8)
        {
        }

        public override bool IsMatch(Stream stream) => base.IsMatch(stream) && CheckContains(stream, RIFF);
    }
}