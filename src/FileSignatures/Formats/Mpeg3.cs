namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a MPEG-1 Audio Layer 3 (MP3) audio file
    /// </summary>
    public class Mpeg3 : FileFormat
    {
        public Mpeg3() : base(new byte[] { 0x49, 0x44, 0x33 }, "audio/mpeg", "mp3") { }
    }
}
