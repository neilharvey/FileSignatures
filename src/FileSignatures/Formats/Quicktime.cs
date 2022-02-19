namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a QuickTime movie file
    /// </summary>
    public class Quicktime : Isobmff
    {
        public Quicktime() : base(new byte[] { 0x71, 0x74, 0x20, 0x20 }, "video/quicktime", "mov") { }
    }
}
