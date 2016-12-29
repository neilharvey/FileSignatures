using System;

namespace FileSignatures
{
    public class OleCompoundFileFormat : FileFormat
    {
        private const int subHeaderOffset = 512;

        public OleCompoundFileFormat(byte[] subHeader, string extension, string mediaType) : base(
            new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
            subHeader == null ? 0 : 512 + subHeader.Length,
            extension,
            mediaType)
        {
            if (subHeader == null || subHeader.Length == 0)
            {
                throw new ArgumentNullException(nameof(subHeader));
            }

            SubHeader = subHeader;
        }

        public byte[] SubHeader { get; }

        public override bool IsMatch(byte[] header)
        {
            if (!base.IsMatch(header))
            {
                return false;
            }

            for (int i = 0; i < SubHeader.Length; i++)
            {
                if (header[i+subHeaderOffset] != SubHeader[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
