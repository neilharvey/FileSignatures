namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Word document with macros.
    /// </summary>
    public class WordWithMacros : OfficeOpenXml
    {
        public WordWithMacros() : base("word/document.xml", macroEnabled: true, "application/vnd.ms-word.document.macroEnabled.12", "docm")
        {
        }
    }
}