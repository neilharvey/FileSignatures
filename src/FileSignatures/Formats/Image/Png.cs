using System.IO;

namespace FileSignatures.Formats.Image;

/// <summary>
/// Specifies the format of a Portable Network Graphics (PNG) image.
/// </summary>
public class Png : FileFormat
{
    public Png() : base([0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A], "image/png", "png")
    {
    }
}
