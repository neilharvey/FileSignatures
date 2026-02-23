namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Windows Media Video (WMV) file.
/// </summary>
/// <remarks>
/// WMV files use the Advanced Systems Format (ASF) container.
/// Note: WMA (Windows Media Audio) files share the same magic bytes and cannot be
/// distinguished from WMV by file signature alone.
/// </remarks>
public class Wmv : FileFormat
{
    public Wmv() : base(
        [0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C],
        "video/x-ms-wmv",
        "wmv")
    {
    }
}
