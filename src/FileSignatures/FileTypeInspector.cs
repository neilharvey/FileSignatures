using System;
using System.IO;

namespace FileSignatures
{
    public class FileTypeInspector : IFileTypeInspector
    {
        public FileType DetermineFileType(Stream stream)
        {
            byte[] buffer = new byte[FileType.Jpeg.Signature.Length];
            stream.Read(buffer, 0, buffer.Length);

            for(int i=0; i<buffer.Length; i++)
            {
                if(buffer[i] != FileType.Jpeg.Signature[i])
                {
                    return null;
                }
            }

            return FileType.Jpeg;
        }
    }
}
