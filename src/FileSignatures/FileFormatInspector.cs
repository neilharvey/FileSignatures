using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSignatures
{
    /// <summary>
    /// Provides a mechanism to determine the format of a file.
    /// </summary>
    public class FileFormatInspector : IFileFormatInspector
    {
        private readonly IEnumerable<FileFormat> _formats;

        /// <summary>
        /// Initialises a new FileFormatInspector instance which can determine the default file formats.
        /// </summary>
        public FileFormatInspector() : this(FileFormatLocator.GetFormats())
        {
        }

        /// <summary>
        /// Initialises a new FileFormatInspector instance which can determine the specified file formats.
        /// </summary>
        /// <param name="formats">The formats which are recognised.</param>
        public FileFormatInspector(IEnumerable<FileFormat> formats)
        {
            _formats = formats ?? throw new ArgumentNullException(nameof(formats));
        }

        /// <summary>
        /// Determines the format of a file.
        /// </summary>
        /// <param name="stream">A stream containing the file content.</param>
        /// <returns>An instance of a matching file format, or null if the format could not be determined.</returns>
        public FileFormat? DetermineFileFormat(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (!stream.CanSeek)
            {
                throw new NotSupportedException("The passed stream object is not seekable.");
            }

            if (stream.Length == 0)
            {
                return null;
            }

            var matches = FindMatchingFormats(stream);

            if (matches.Count > 1)
            {
                RemoveBaseFormats(matches);
            }

            if (matches.Count > 0)
            {
                return matches.OrderByDescending(m => m.HeaderLength).First();
            }

            return null;
        }

        private List<FileFormat> FindMatchingFormats(Stream stream)
        {
            var candidates = _formats
                .OrderBy(t => t.HeaderLength)
                .ToList();

            for (int i = 0; i < candidates.Count; i++)
            {
                if (!candidates[i].IsMatch(stream))
                {
                    candidates.RemoveAt(i);
                    i--;
                }
            }

            if(candidates.Count > 1)
            {
                var readers = candidates.OfType<IFileFormatReader>().ToList();

                if(readers.Any())
                {
                    var file = readers[0].Read(stream);
                    foreach(var reader in readers)
                    {
                        if (!reader.IsMatch(file))
                        {
                            candidates.Remove((FileFormat)reader);
                        }
                    }
                }
            }

            stream.Position = 0;
            return candidates;
        }

        private static void RemoveBaseFormats(List<FileFormat> candidates)
        {
            for (var i = 0; i < candidates.Count; i++)
            {
                for (var j = 0; j < candidates.Count; j++)
                {
                    if (i != j && candidates[j].GetType().IsAssignableFrom(candidates[i].GetType()))
                    {
                        candidates.RemoveAt(j);
                        i--; j--;
                    }
                }
            }
        }
    }
}
