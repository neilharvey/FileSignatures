namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of with offset.
    /// </summary>
    public class OffsetFileFormat : FileFormat
    {
        /// <summary>
        /// Initializes a new instance of the Offset File Format class which matches a file with offset.
        /// </summary>
        /// <param name="signature">The header signature of the format.</param>
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate extension for the format.</param>
        /// <param name="offset">The appropriate offset for the format.</param>
        public OffsetFileFormat(byte[] signature, string mediaType, string extension, int offset) : base(signature, offset + signature.Length, mediaType, extension)
        {
            Offset = offset;
        }

        /// <summary>
        /// Gets the offset in the file which can be used to identify the format.
        /// </summary>
        /// <remarks>
        public int Offset { get; }

        /// <summary>
        /// Returns a value indicating whether the format matches a file header.
        /// </summary>
        /// <param name="header">The header to check.</param>
        public override bool IsMatch(byte[] header)
        {
            if (header == null || (header.Length < HeaderLength && HeaderLength < int.MaxValue) || Offset > header.Length)
            {
                return false;
            }

            for (int i = 0; i < Signature.Count; i++)
            {
                if (header[i+Offset] != Signature[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
