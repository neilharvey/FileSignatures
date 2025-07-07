using System.IO;
using System.Linq;

namespace FileSignatures.Formats;

/// <summary>
/// Shockwave Flash Movie format.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/application/vnd.adobe.flash.movie
/// </remarks>
public class Swf : FileFormat
{
    private static readonly byte[] ValidLeadingBytes = [0x46, 0x43, 0x5A];
    
    public Swf() : base([0x57, 0x53], headerLength: 3, "application/vnd.adobe.flash.movie", "swf", offset: 1)
    {
    }

    public override bool IsMatch(Stream stream)
    {
        stream.Position = 0;
        var leadingByte = (byte)stream.ReadByte();
        return ValidLeadingBytes.Contains(leadingByte) && base.IsMatch(stream);
    }
}