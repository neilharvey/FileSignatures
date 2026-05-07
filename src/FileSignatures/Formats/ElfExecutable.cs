namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Linux executable file
/// </summary>
public class ElfExecutable : FileFormat
{
    public ElfExecutable() : base(new byte[] { 0x7F, 0x45, 0x4C, 0x46 }, "application/x-elf", "")
    {
    }
}