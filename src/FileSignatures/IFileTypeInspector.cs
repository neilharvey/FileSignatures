using System.IO;

namespace FileSignatures
{
    public interface IFileTypeInspector
    {
        FileType Inspect(Stream stream);
    }
}
