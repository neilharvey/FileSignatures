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

        public FileFormatInspector(IEnumerable<FileFormat> recognizedTypes)
        {
            RecognizedTypes = recognizedTypes;
        }

        public IEnumerable<FileFormat> RecognizedTypes { get; }

        public FileFormat DetermineFileFormat(Stream stream)
        {
            var header = ReadHeaderBytes(stream);
            var candidates = RecognizedTypes
                .OrderBy(t => t.HeaderLength)
                .ToList();

            for (int j = 0; j < candidates.Count; j++)
            {
                if (!candidates[j].IsMatch(header))
                {
                    candidates.RemoveAt(j);
                    j--;
                }
            }

            if (candidates.Count == 1)
            {
                return candidates[0];
            }

            return null;
        }

        private static byte[] ReadHeaderBytes(Stream stream)
        {
            var bufferLength = FileFormat.GetAll().Max(t => t.HeaderLength);
            var buffer = new byte[bufferLength];

            var offset = 0;
            var remaining = bufferLength;

            while (remaining > 0)
            {
                var read = stream.Read(buffer, offset, remaining);
                if (read <= 0)
                {
                    break;
                }

                remaining -= read;
                offset += read;
            }

            return buffer;
        }
    }
}
