namespace FileSignatures.Formats;

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