using System.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the common part of all Ftyp-based multimedia files.
    /// </summary>
    public abstract class FtypBase : Video
    {
        private static readonly byte[] FTYP = { 0x66, 0x74, 0x79, 0x70 };

        protected FtypBase(byte[] signature, string mediaType, string extension)
            : base(FTYP.Concat(signature).ToArray(), mediaType, extension, 4)
        {
        }
    }
}
