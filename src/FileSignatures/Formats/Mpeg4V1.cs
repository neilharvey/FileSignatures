namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a ISO Base Media file (MPEG-4) v1
    /// </summary>
    public class Mpeg4V1 : Mpeg4
    {
        private static readonly byte[] signature = { 0x69, 0x73, 0x6F, 0x6D };

        public Mpeg4V1() : base(signature, "mp4")
        {
        }
    }
}
