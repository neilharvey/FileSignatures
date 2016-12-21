using System.IO;

namespace FileSignatures
{
    public interface IFileTypeInspector
    {
        FileType DetermineFileType(Stream stream);
    }
}
