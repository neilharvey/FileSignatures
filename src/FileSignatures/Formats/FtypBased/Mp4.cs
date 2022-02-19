namespace FileSignatures.Formats.FtypBased
{
    /// <summary>
    /// Specifies the format of a MPEG-4 video file.
    /// </summary>
    public abstract class Mp4 : FtypBase
    {
        private static readonly byte[] MP4 = { 0x4D, 0x53, 0x4E, 0x56 };

        public Mp4() : this(MP4)
        {
        }

        protected Mp4(byte[] signature, string extension = "mp4") : base(signature, "video/mp4", extension)
        {
        }
    }
}
