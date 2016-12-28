using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSignatures
{
    public class FileFormatInspector : IFileFormatInspector
    {
        public FileFormatInspector() : this(new HashSet<FileFormat>(FileFormat.GetAll()))
        {
        }

        public FileFormatInspector(ISet<FileFormat> recognisedTypes)
        {
            RecognisedTypes = recognisedTypes;
        }

        public ISet<FileFormat> RecognisedTypes { get; }

        public FileFormat DetermineFileFormat(Stream stream)
        {
            var header = ReadHeaderBytes(stream);
            var candidates = new List<FileFormat>(RecognisedTypes);

            for (int i = 0; i < header.Length; i++)
            {
                for (int j = 0; j < candidates.Count; j++)
                {
                    if (candidates[j].Signature.Length - 1 < i || header[i] != candidates[j].Signature[i])
                    {
                        candidates.RemoveAt(j);
                        j--;
                    }
                }

                if (candidates.Count == 1)
                {
                    return candidates[0];
                }

                if (candidates.Count == 0)
                {
                    break;
                }
            }

            return null;
        }

        private static byte[] ReadHeaderBytes(Stream stream)
        {
            var bufferLength = FileFormat.GetAll().Max(t => t.Signature.Length);
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
