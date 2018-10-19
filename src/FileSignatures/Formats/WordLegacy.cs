namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Word 97-2003 document.
    /// </summary>
    public class WordLegacy : CompoundBinaryFile
    {
        public WordLegacy() : base("00020906-0000-0000-c000-000000000046", "application/msword", "doc")
        {
        }
    }
}
