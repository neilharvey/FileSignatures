namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Word document.
    /// </summary>
    public class Word : OfficeOpenXml
    {
        public Word() : base("word/document.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx")
        {
        }
    }
}
