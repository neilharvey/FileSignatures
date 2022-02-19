namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a QuickTime movie file
    /// </summary>
    public class Mov : Mp4
    {
        private static readonly byte[] MOV = { 0x71, 0x74, 0x20, 0x20 };

        public Mov() : base(MOV, "mov")
        {
        }
    }
}
