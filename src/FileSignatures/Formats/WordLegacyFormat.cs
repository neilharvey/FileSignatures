namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Word 97-2003 document.
    /// </summary>
    public class WordLegacyFormat : OleCompoundFileFormat
    {
        public WordLegacyFormat() : base(new byte[] { 0xEC, 0xA5, 0xC1, 0x00 }, "application/msword", "doc")
        {
        }
    }
}
