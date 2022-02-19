namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a ISO Base Media file (MPEG-4) v1
    /// </summary>
    public class Mp4V1 : Mp4
    {
        private static readonly byte[] signature = { 0x69, 0x73, 0x6F, 0x6D };

        public Mp4V1() : base(signature)
        {
        }
    }
}
