using System;
using System.IO;

namespace FileSignatures
{
    /// <summary>
    /// A format which requires a stream to be converted into an intermediate object to determine it's exact format.
    /// </summary>
    /// <example>
    /// OpenOfficeXml files are based on zip so the stream must be converted into a zip archive to determine the exact format.
    /// </example>
    public interface IFileFormatReader
    {
        /// <summary>
        /// Reads a stream and converts it to another format.
        /// </summary>
        /// <param name="stream">The stream to convert.</param>
        IDisposable? Read(Stream stream);

        /// <summary>
        /// Returns a value indicating whether the format is a match for the converted stream.
        /// </summary>
        /// <param name="file">The converted stream to check.</param>
        bool IsMatch(IDisposable? file);
    }
}
