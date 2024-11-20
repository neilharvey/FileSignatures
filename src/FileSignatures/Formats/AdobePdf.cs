using System.IO;

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

    public override bool IsMatch(Stream stream)
    {
        if (stream == null || (stream.Length < HeaderLength && HeaderLength < int.MaxValue) || Offset > stream.Length)
        {
            return false;
        }

        stream.Position = Offset;

        for (var i = 0; i < Signature.Count; i++)
        {
            var b = stream.ReadByte();
            if (!IsSignatureByte(b, i))
            {
                return false;
            }
        }

        return true;
    }

    protected bool IsSignatureByte(int value, int signatureIndex)
    {
        return IsVersionNumber(value, Signature[signatureIndex])
               || value == Signature[signatureIndex];
    }

    private static bool IsVersionNumber(int value, byte signatureByte)
    {
        var isNumber = value is >= 0x30 and <= 0x39;
        return signatureByte == VersionNumberPlaceholder && isNumber;
    }
}