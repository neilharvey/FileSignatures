namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a MPEG-4 video|QuickTime file
    /// </summary>
    public class M4V : Mpeg4
    {
        private static readonly byte[] signature = { 0x6D, 0x70, 0x34, 0x32 };

        public M4V() : base(signature)
        {
        }
    }
}
