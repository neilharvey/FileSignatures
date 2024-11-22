using System.IO;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Portable Document Format (PDF) file.
    /// </summary>
    public class Pdf : FileFormat
    {
        public Pdf() : this([0x25, 0x50, 0x44, 0x46])
        {
        }

        protected Pdf(byte[] signature) : base(signature, "application/pdf", "pdf", 0)
        {
        }
        
    }
}