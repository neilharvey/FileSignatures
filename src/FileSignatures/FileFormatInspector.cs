using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSignatures
{
    public class FileFormatInspector : IFileFormatInspector
    {
        public FileFormatInspector() : this(FileFormat.GetAll())
        {
        }

        public FileFormatInspector(IEnumerable<FileFormat> recognisedTypes)
        {
            RecognisedTypes = recognisedTypes;
        }

        public IEnumerable<FileFormat> RecognisedTypes { get; }

        public FileFormat DetermineFileFormat(Stream stream)
        {
            var bufferLength = stream.Length;
            var bytesRead = 0;
            var header = new byte[bufferLength];
            var candidates = RecognisedTypes
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

        private int ReadHeaderBytes(Stream stream, byte[] buffer, int initialPosition, int readToPosition)
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
