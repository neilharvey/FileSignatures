namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Microsoft Compiled HTML Help file (CHM).
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/application/vnd.ms-htmlhelp
/// </remarks>
public class CompiledHtmlHelp : FileFormat
{
    public CompiledHtmlHelp() : base([0x49, 0x54, 0x53, 0x46], "application/vnd.ms-htmlhelp", "chm")
    {
    }
}
