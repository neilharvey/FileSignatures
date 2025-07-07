namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Flash Video file.
/// </summary>
public class Flash : FileFormat
{
    public Flash() : base([0x46, 0x4C, 0x56], "video/x-flv", "flv")
    {
    }
}