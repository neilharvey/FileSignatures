namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a MPEG-4 video
    /// </summary>
    public class MP4 : Isobmff
    {
        public MP4() : base(new byte[] { 0x6D, 0x70, 0x34, 0x32 }, "video/mp4", "mp4")
        {
        }
    }
}
