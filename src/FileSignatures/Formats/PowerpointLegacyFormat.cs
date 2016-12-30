namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a legacy Powerpoint 97-2003 presentation.
    /// </summary>
    public class PowerPointLegacyFormat : OleCompoundFileFormat
    {
        public PowerPointLegacyFormat() : base(new byte[] { 0xFD, 0xFF, 0xFF, 0xFF }, "application/vnd.ms-powerpoint", "ppt")
        {
        }
    }
}
