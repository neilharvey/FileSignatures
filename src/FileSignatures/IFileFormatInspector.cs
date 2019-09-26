using System.IO;

namespace FileSignatures
{
    /// <summary>
    /// Provides a mechanism to determine the format of a file.
    /// </summary>
    public interface IFileFormatInspector
    {
        /// <summary>
        /// Determines the format of a file.
        /// </summary>
        /// <param name="stream">A stream containing the file content.</param>
        /// <returns>An instance of a matching file format, or null if the format could not be determined.</returns>
        FileFormat? DetermineFileFormat(Stream stream);
    }
}
