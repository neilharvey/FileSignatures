using System;
using System.Collections.ObjectModel;

namespace FileSignatures
{
    /// <summary>
    /// Specifies the format of an OLE Compound File.
    /// </summary>
    public abstract class OleCompoundFileFormat : FileFormat
    {
        private const int SubHeaderOffset = 512;

        /// <summary>
        /// Initialises a new instance of the OleCompoundFileFormat.
        /// </summary>
        /// <param name="subHeader">The subheader which determines the file content.</param>
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate extension for the format.</param>
        protected OleCompoundFileFormat(byte[] subHeader, string mediaType, string extension) : base(
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

        /// <summary>
        /// Gets the subheader which can be used to identify the file content.
        /// </summary>
        public ReadOnlyCollection<byte> SubHeader { get; }

        /// <summary>
        /// Returns a value indicating whether the format matches a file header.
        /// </summary>
        /// <param name="header">The header to check.</param>
        public override bool IsMatch(byte[] header)
        {
            if (!base.IsMatch(header))
            {
                return false;
            }

            for (int i = 0; i < SubHeader.Count; i++)
            {
                if (header[i + SubHeaderOffset] != SubHeader[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
