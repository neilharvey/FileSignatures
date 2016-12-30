namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Portable Document Format (PDF) file.
    /// </summary>
    public class Pdf : FileFormat
    {
        public Pdf() : base(new byte[] { 0x25, 0x50, 0x44, 0x46 }, "application/pdf", "pdf")
        {
        }
    }
}
