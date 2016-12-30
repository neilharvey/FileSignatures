namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Powerpoint presentation.
    /// </summary>
    public class PowerPointFormat : OfficeOpenXmlFormat
    {
        public PowerPointFormat(string identifiableEntry, string mediaType, string extension) : base(identifiableEntry, mediaType, extension)
        {
        }
    }
}
