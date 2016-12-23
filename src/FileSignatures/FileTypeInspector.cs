using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileSignatures
{
    public class FileTypeInspector : IFileTypeInspector
    {
        public FileTypeInspector() : this(DefaultFileTypes())
        {
        }

        public FileTypeInspector(ISet<FileType> recognisedTypes)
        {
            RecognisedTypes = recognisedTypes;
        }

        public ISet<FileType> RecognisedTypes { get; }

        public FileType DetermineFileType(Stream stream)
        {
            byte[] buffer = new byte[FileType.Jpeg.Signature.Length];
            stream.Read(buffer, 0, buffer.Length);

            var candidates = new List<FileType>(RecognisedTypes);

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

        private static ISet<FileType> DefaultFileTypes()
        {
            var types = new HashSet<FileType>();
            types.Add(FileType.Jpeg);
            types.Add(FileType.Bmp);
            types.Add(FileType.Gif);
            types.Add(FileType.Png);
            return types;
        }
    }
}
