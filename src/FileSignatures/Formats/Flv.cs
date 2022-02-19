namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a ISO Media, MPEG v4 system, or iTunes AVC-LC file
    /// </summary>
    public class Flv : Mp4
    {
        private static readonly byte[] signature = { 0x4D, 0x34, 0x56, 0x20 };

        public Flv() : base(signature, "m4v")
        {
        }
    }
}
