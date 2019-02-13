namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Dicom file.
    /// </summary>
    public class Dicom : FileFormat
    {
        public Dicom() : base(new byte[] { 0x44, 0x49, 0x43, 0x4D }, "application/dicom", "dcm", 128)
        {
        }
    }
}
