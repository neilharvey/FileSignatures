using System;
using System.Collections.ObjectModel;

namespace FileSignatures
{
    public class OleCompoundFileFormat : FileFormat
    {
        private const int subHeaderOffset = 512;

        public OleCompoundFileFormat(byte[] subHeader, string mediaType, string extension) : base(
            new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
            subHeader == null ? 0 : 512 + subHeader.Length,
            mediaType,
            extension)
        {
            if (subHeader == null || subHeader.Length == 0)
            {
                throw new ArgumentNullException(nameof(subHeader));
            }

            SubHeader = new ReadOnlyCollection<byte>(subHeader);
        }

        public ReadOnlyCollection<byte> SubHeader { get; }

        public override bool IsMatch(byte[] header)
        {
            if (!base.IsMatch(header))
            {
                return false;
            }

            for (int i = 0; i < SubHeader.Count; i++)
            {
                if (header[i + subHeaderOffset] != SubHeader[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
