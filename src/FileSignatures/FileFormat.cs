using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileSignatures
{
    /// <summary>
    /// Specifies the format of a file.
    /// </summary>
    public abstract class FileFormat
    {
        /// <summary>
        /// Initializes a new instance of the FileFormat class which has the specified signature and media type.
        /// </summary>
        /// <param name="signature">The header signature of the format.</param>
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate extension for the format.</param>
        /// <param name="offset">The appropriate offset for the format.</param>
        protected FileFormat(byte[] signature, string mediaType, string extension, int offset = 0) : this(signature, signature == null ? 0 + offset : signature.Length + offset, mediaType, extension, offset)
        {
        }

        /// <summary>
        /// Initializes a new instance of the FileFormat class which has the specified signature and media type.
        /// </summary>
        /// <param name="signature">The header signature of the format.</param>
        /// <param name="headerLength">The number of bytes required to determine the format.</param>
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate file extension for the format.</param>
        /// <param name="offset">The appropriate offset for the format.</param>
        protected FileFormat(byte[] signature, int headerLength, string mediaType, string extension, int offset = 0)
        {
            if (signature == null || signature.Length == 0)
            {
                throw new ArgumentNullException(nameof(signature));
            }

            if (string.IsNullOrEmpty(mediaType))
            {
                throw new ArgumentNullException(nameof(mediaType));
            }

            Signature = new ReadOnlyCollection<byte>(signature);
            HeaderLength = headerLength;
            Extension = extension;
            MediaType = mediaType;
            Offset = offset;
        }

        /// <summary>
        /// Gets a byte signature which can be used to identify the file format.
        /// </summary>
        public ReadOnlyCollection<byte> Signature { get; }

        /// <summary>
        /// Gets the number of bytes required to determine the format.  
        /// A value of <see cref="int.MaxValue"/> indicates that the entire file is required to determine the format.
        /// </summary>
        public int HeaderLength { get; }

        /// <summary>
        /// Gets the appropriate file extension for the format.
        /// </summary>
        public string Extension { get; }

        /// <summary>
        /// Gets the media type identifier for the format.
        /// </summary>
        public string MediaType { get; }

        /// <summary>
        /// Gets the offset in the file which can be used to identify the format.
        /// </summary>
        /// <remarks>
        public int Offset { get; }

        /// <summary>
        /// Returns a value indicating whether the format matches a file header.
        /// </summary>
        /// <param name="header">The header to check.</param>
        public virtual bool IsMatch(byte[] header)
        {
            if (header == null || (header.Length < HeaderLength && HeaderLength < int.MaxValue) || Offset > header.Length)
            {
                return false;
            }

            for (int i = 0; i < Signature.Count; i++)
            {
                if (header[i + Offset] != Signature[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the object is equal to this FileFormat.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        public override bool Equals(object obj)
        {
            var fileFormat = obj as FileFormat;

            if (fileFormat == null)
            {
                return false;
            }
            else
            {
                return fileFormat.Signature.SequenceEqual(Signature);
            }
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                if (Signature == null)
                {
                    return 0;
                }

                var hash = 17;
                foreach (var element in Signature)
                {
                    hash = hash * 31 + element.GetHashCode();
                }

                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents this format.
        /// </summary>
        public override string ToString()
        {
            return MediaType;
        }
    }
}
