using System.Collections.Generic;
using System.IO;

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
            byte[] buffer = new byte[FileFormat.Jpeg.Signature.Length];
            stream.Read(buffer, 0, buffer.Length);

            var candidates = new List<FileFormat>(RecognisedTypes);

            for (int i = 0; i < buffer.Length; i++)
            {
                for(int j=0; j < candidates.Count; j++)
                {
                    if (candidates[j].Signature.Length - 1 < i || buffer[i] != candidates[j].Signature[i])
                    {
                        candidates.RemoveAt(j);
                        j--;
                    }
                }

                if(candidates.Count == 1)
                {
                    return candidates[0];
                }

                if(candidates.Count == 0)
                {
                    break;
                }
            }

            return null;
        }
    }
}
