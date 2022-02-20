using System.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a ISO/IEC base media file format
    /// </summary>
    /// <see href="https://en.wikipedia.org/wiki/ISO/IEC_base_media_file_format"/>
    public abstract class Isobmff : FileFormat
    {
        private static readonly byte[] signature = { 0x66, 0x74, 0x79, 0x70 };

        protected Isobmff(byte[] signature, string mediaType, string extension)
            : base(Isobmff.signature.Concat(signature).ToArray(), mediaType, extension, 4)
        {
        }
    }
}
