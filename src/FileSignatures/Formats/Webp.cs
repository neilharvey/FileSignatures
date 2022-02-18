using System.IO;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Google WebP image file, where ?? ?? ?? ?? is the file size (ISO 8859-1).
    /// </summary>
    /// <see ref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types"/>
    /// <see ref="https://en.wikipedia.org/wiki/List_of_file_signatures"/>
    /// <see ref="https://developers.google.com/speed/webp/docs/riff_container#webp_file_header"/>
    public class Webp : FileFormat
    {
        private static readonly byte[] RIFF = {0x52, 0x49, 0x46, 0x46};
        private static readonly byte[] WEBP = {0x57, 0x45, 0x42, 0x50};

        public Webp() : base(WEBP, "image/webp", "webp", offset: 8)
        {
        }

        public override bool IsMatch(Stream stream) => base.IsMatch(stream) && CheckContains(stream, RIFF);
    }
}