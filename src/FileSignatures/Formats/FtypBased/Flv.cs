namespace FileSignatures.Formats.FtypBased
{
    /// <summary>
    /// Specifies the format of a ISO Media, MPEG v4 system, or iTunes AVC-LC file
    /// </summary>
    public class Flv : Mp4
    {
        /// <summary>
        /// ASCII: `M4V `
        /// </summary>
        private static readonly byte[] FLV = { 0x4D, 0x34, 0x56, 0x20 };

        public Flv() : base(FLV, "m4v")
        {
        }
    }
}
