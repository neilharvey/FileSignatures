namespace FileSignatures.Formats.Video
{
    /// <summary>
    /// Specifies the format of a MPEG-4 video
    /// </summary>
    public class MP4 : Isobmff
    {
        public MP4() : base([0x6D, 0x70, 0x34, 0x32], "video/mp4", "mp4")
        {
        }
    }

    /// <summary>
    /// Specifies the format of a MPEG-4 v1 file
    /// </summary>
    public class MP4V1 : Isobmff
    {
        public MP4V1() : base([0x69, 0x73, 0x6F, 0x6D], "video/mp4", "mp4")
        {
        }
    }    
}
