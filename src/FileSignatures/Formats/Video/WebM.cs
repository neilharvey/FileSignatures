namespace FileSignatures.Formats.Video;

/// <summary>
/// WebM audiovisual media format. 
/// </summary>
/// <remarks>
/// No IANA registration exists for this format.
/// </remarks>
public sealed class WebM : Ebml
{
    public WebM() : base("webm", "video/webm", "webm")
    {
    }
}