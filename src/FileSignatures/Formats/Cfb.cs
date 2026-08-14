using OpenMcdf;
using System;
using System.IO;

namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Compound Binary File.
/// </summary>
/// <remarks>
/// See [MS-CFB] https://msdn.microsoft.com/en-us/library/dd942138.aspx,
/// in particular 2.2 for a description of the CFB header specification.
/// </remarks>
public abstract class Cfb : FileFormat, IFileFormatReader
{
    /// <summary>
    /// Initializes a new instance of the CompoundFileBinary class.
    /// </summary>
    /// <param name="storage">The entry in the structured storage which is used to identify the format.</param>
    /// <param name="mediaType">The media type of the format.</param>
    /// <param name="extension">The appropriate extension for the format.</param>
    public Cfb(string storage, string mediaType, string extension) : base(
        [0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1],
        int.MaxValue,
        mediaType,
        extension)
    {
        if (string.IsNullOrEmpty(storage))
        {
            throw new ArgumentNullException(nameof(storage));
        }

        Storage = storage;
    }

    /// <summary>
    /// Gets the entry in the structured storage which is used to identify the format.
    /// </summary>
    public string Storage { get; }

    public bool IsMatch(IDisposable? file)
    {
        if (file is RootStorage root)
        {
            return root.TryOpenStream(Storage, out CfbStream? _);
        }
        else
        {
            return false;
        }
    }

    public IDisposable? Read(Stream stream)
    {
        try
        {
            return RootStorage.Open(stream, StorageModeFlags.LeaveOpen);
        }
        //catch(EndOfStreamException)
        catch (ObjectDisposedException)
        {
            return null;
        }
    }
}
