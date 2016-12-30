namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a legacy Powerpoint 97-2003 presentation.
    /// </summary>
    public class PowerPointLegacy : OleCompoundFile
    {
        public PowerPointLegacy() : base(new byte[] { 0xFD, 0xFF, 0xFF, 0xFF }, "application/vnd.ms-powerpoint", "ppt")
        {
        }
    }
}
