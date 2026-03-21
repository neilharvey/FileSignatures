namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of an AutoCAD Drawing (DWG) file.
/// </summary>
/// <remarks>
/// All known DWG file versions (from AutoCAD R2.5 / AC1002 through the latest releases)
/// begin with the 4-byte prefix "AC10" followed by a 2-digit version number.
/// See https://www.iana.org/assignments/media-types/image/vnd.dwg
/// </remarks>
public class Dwg : FileFormat
{
    public Dwg() : base([0x41, 0x43, 0x31, 0x30], "image/vnd.dwg", "dwg")
    {
    }
}
