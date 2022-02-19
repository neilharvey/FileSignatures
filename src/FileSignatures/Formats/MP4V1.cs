namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a MPEG-4 v1 file
    /// </summary>
    public class MP4V1 : Isobmff
    {
        public MP4V1() : base(new byte[] { 0x69, 0x73, 0x6F, 0x6D }, "video/mp4", "mp4")
        {
        }
    }
}
