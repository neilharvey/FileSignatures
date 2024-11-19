using System.IO;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Portable Document Format (PDF) file.
    /// </summary>
    public class Pdf : FileFormat
    {
        private const uint MaxFileHeaderSize = 1024;

        public Pdf() : this([0x25, 0x50, 0x44, 0x46])
        {
        }

        protected Pdf(byte[] signature) : base(signature, "application/pdf", "pdf", 0)
        {
        }

        public override bool IsMatch(Stream stream)
        {
            if (stream == null || (stream.Length < HeaderLength && HeaderLength < int.MaxValue) || Offset > stream.Length)
            {
                return false;
            }

            stream.Position = Offset;

            var signatureIndex = 0;
            while (stream.Position < MaxFileHeaderSize && stream.Position < stream.Length)
            {
                var b = (byte)stream.ReadByte();
                if (IsSignatureByte(b, signatureIndex))
                {
                    signatureIndex++;
                }
                else
                {
                    signatureIndex = 0;
                }
                
                if (signatureIndex == Signature.Count)
                    return true; 
            }
            
            return false;
        }

        protected virtual bool IsSignatureByte(byte value, int signatureIndex)
           => value == Signature[signatureIndex];
    }
}