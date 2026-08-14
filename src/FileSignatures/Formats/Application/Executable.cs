namespace FileSignatures.Formats.Application;

/// <summary>
/// Specifies the format of a Windows executable file
/// </summary>
public class Executable : FileFormat
{
    public Executable() : base([0x4D, 0x5A], "application/vnd.microsoft.portable-executable", "exe")
    {
    }
}
