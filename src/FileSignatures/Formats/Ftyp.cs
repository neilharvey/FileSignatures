using System.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the common part of all Ftyp-based multimedia files.
    /// </summary>
    public abstract class Ftyp : Video
    {
        private static readonly byte[] signature = { 0x66, 0x74, 0x79, 0x70 };

        protected Ftyp(byte[] signature, string mediaType, string extension)
            : base(Ftyp.signature.Concat(signature).ToArray(), mediaType, extension, 4)
        {
        }
    }
}
