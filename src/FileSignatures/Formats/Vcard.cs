namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Contact vCard file
    /// </summary>
    public class Vcard : FileFormat
    {
        public Vcard() : base(new byte[] { 0x42, 0x45, 0x47, 0x49, 0x4E, 0x3A, 0x56, 0x43, 0x41, 0x52, 0x44, 0x0D, 0x0A }, "text/vcard", "vcf")
        {
        }
    }
}
