namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Windows executable file
    /// </summary>
    public class ExecutableFormat : FileFormat
    {
        public ExecutableFormat() : base(new byte[] { 0x4D, 0x5A }, "application/octet-stream", "exe")
        {
        }
    }
}
