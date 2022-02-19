namespace FileSignatures.Formats.FtypBased
{
    /// <summary>
    /// Specifies the format of a ISO Base Media file (MPEG-4) v1
    /// </summary>
    public class Mp4V1 : Mp4
    {
        /// <summary>
        /// ASCII: `isom`
        /// </summary>
        private static readonly byte[] MP4v1 = { 0x69, 0x73, 0x6F, 0x6D };

        public Mp4V1() : base(MP4v1)
        {
        }
    }
}
