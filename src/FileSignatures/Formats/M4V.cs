namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an MPEG-4 video file
    /// </summary>
    public class M4V : Isobmff
    {
        public M4V() : base(new byte[] { 0x4D, 0x34, 0x56, 0x20 }, "video/mp4", "m4v")
        {
        }
    }
}
