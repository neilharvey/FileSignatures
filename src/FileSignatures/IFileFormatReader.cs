using System;
using System.IO;

namespace FileSignatures
{
    public interface IFileFormatReader
    {
        IDisposable Read(Stream stream);

        bool IsMatch(IDisposable file);
    }
}
