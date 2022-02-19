namespace FileSignatures.Formats.FtypBased
{
    /// <summary>
    /// Specifies the format of a MPEG-4 video|QuickTime file
    /// </summary>
    public class M4V : Mp4
    {
        /// <summary>
        /// ASCII: `mp42`
        /// </summary>
        private static readonly byte[] M4VSig = { 0x6D, 0x70, 0x34, 0x32 };

        public M4V() : base(M4VSig)
        {
        }
    }
}
