using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FileSignatures
{
    /// <summary>
    /// Provides a mechanism to determine the format of a file.
    /// </summary>
    public class FileFormatInspector : IFileFormatInspector
    {
        private IEnumerable<FileFormat> knownFormats;

        /// <summary>
        /// Initialises a new FileFormatInspector instance which can determine the default file formats.
        /// </summary>
        public FileFormatInspector() : this(FileFormatLocator.GetFormats())
        {
        }

        /// <summary>
        /// Initialises a new FileFormatInspector instance which can determine the specified file formats.
        /// </summary>
        /// <param name="formats">The formats which are recognised.</param>
        public FileFormatInspector(IEnumerable<FileFormat> formats)
        {
            if (formats == null)
            {
                throw new ArgumentNullException(nameof(formats));
            }

            knownFormats = formats;
        }

        /// <summary>
        /// Determines the format of a file.
        /// </summary>
        /// <param name="stream">A stream containing the file content.</param>
        /// <returns>An instance of a matching file format, or null if the format could not be determined.</returns>
        public FileFormat DetermineFileFormat(Stream stream)
        {
            var bufferLength = stream.Length;
            var bytesRead = 0;
            var header = new byte[bufferLength];
            var candidates = knownFormats
                .OrderBy(t => t.HeaderLength)
                .ToList();

            for (int i = 0; i < candidates.Count; i++)
            {
                bytesRead += ReadHeaderBytes(stream, header, bytesRead, candidates[i].HeaderLength);

                if (!candidates[i].IsMatch(header))
                {
                    candidates.RemoveAt(i);
                    i--;
                }
            }

            if (candidates.Count == 1)
            {
                return candidates[0];
            }

            return null;
        }

        private static int ReadHeaderBytes(Stream stream, byte[] buffer, int initialPosition, int readToPosition)
        {
            var bytesRead = 0;
            var remaining = Math.Min(readToPosition, buffer.Length) - initialPosition;

            while (remaining > 0)
            {
                var read = stream.Read(buffer, initialPosition + bytesRead, remaining);
                if (read <= 0)
                {
                    break;
                }

                remaining -= read;
                bytesRead += read;
            }

            return bytesRead;
        }
    }
}
