namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a QuickTime movie file
    /// </summary>
    public class Quicktime : Mpeg4
    {
        private static readonly byte[] signature = { 0x71, 0x74, 0x20, 0x20 };

        public Quicktime() : base(signature, "mov")
        {
        }
    }
}
