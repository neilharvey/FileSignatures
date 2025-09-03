namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Powerpoint presentation.
    /// </summary>
    public class PowerPoint : OfficeOpenXml
    {
        public PowerPoint() : base("ppt/presentation.xml", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx") { }

        protected PowerPoint(string identifiableEntry, string mediaType, string extension, string contentTypeOverride) : base(identifiableEntry, mediaType, extension, contentTypeOverride) { }
    }
}
