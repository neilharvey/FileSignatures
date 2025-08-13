namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Powerpoint presentation.
    /// </summary>
    public class PowerPoint : OfficeOpenXml
    {
        public PowerPoint() : base("ppt/presentation.xml", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx")
        {
        }
    }
}
