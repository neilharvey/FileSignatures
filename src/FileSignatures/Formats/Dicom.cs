namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Dicom file.
    /// </summary>
    public class Dicom : FileFormat
    {
        public Dicom() : base([0x44, 0x49, 0x43, 0x4D], "application/dicom", "dcm", offset: 128)
        {
        }
    }
}
