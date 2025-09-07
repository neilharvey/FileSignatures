namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Word document.
    /// </summary>
    public class Word : OfficeOpenXml
    {
        public Word() : base("word/document.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx") { }

        protected Word(string identifiableEntry, string mediaType, string extension, string contentTypeOverride) : base(identifiableEntry, mediaType, extension, contentTypeOverride) { }
    }
}
