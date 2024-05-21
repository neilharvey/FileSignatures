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
            if (stream == null || stream.Length < HeaderLength)
            {
                return false;
            }

            stream.Position = 0;
            var signatureValidationIndex = 0;
            int fileByte;

            while (stream.Position < MaxFileHeaderSize && (fileByte = stream.ReadByte()) != -1)
            {
                if (CompareFileByteToSignatureAt((byte)fileByte, signatureValidationIndex))
                {
                    signatureValidationIndex++;
                }
                else
                {
                    signatureValidationIndex = 0;
                }

                if (signatureValidationIndex == Signature.Count)
                    return true;
            }

            return false;
        }

        protected virtual bool CompareFileByteToSignatureAt(byte fileByte, int signatureIndex)
        {
            return fileByte == Signature[signatureIndex];
        }
    }

    public class AdobePdf : Pdf
    {
        private const byte VersionNumberPlaceholder = 0x00;

        public AdobePdf() : base([
            0x25, 0x21, 0x50, 0x53, 0x2D, 0x41, 0x64, 0x6F, 0x62, 0x65, 0x2D, VersionNumberPlaceholder, 0x2E,
            VersionNumberPlaceholder, 0x20, 0x50, 0x44,
            0x46, 0x2D, VersionNumberPlaceholder, 0x2E, VersionNumberPlaceholder
        ])
        {
        }

        protected override bool CompareFileByteToSignatureAt(byte fileByte, int signatureIndex)
        {
            return base.CompareFileByteToSignatureAt(fileByte, signatureIndex) || IsVersionNumber(fileByte, Signature[signatureIndex]);
        }

        private static bool IsVersionNumber(byte fileByte, byte signatureByte)
        {
            return signatureByte == VersionNumberPlaceholder && IsNumber(fileByte);
        }

        private static bool IsNumber(byte @byte)
        {
            return @byte is >= 0x30 and <= 0x39;
        }
    }
}