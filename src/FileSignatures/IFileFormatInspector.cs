using System.IO;

namespace FileSignatures
{
    public interface IFileFormatInspector
    {
        FileFormat DetermineFileFormat(Stream stream);
    }
}
