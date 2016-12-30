namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Windows executable file
    /// </summary>
    public class Executable : FileFormat
    {
        public Executable() : base(new byte[] { 0x4D, 0x5A }, "application/octet-stream", "exe")
        {
        }
    }
}
