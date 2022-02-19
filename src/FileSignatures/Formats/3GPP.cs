namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a 3rd Generation Partnership Project 3GPP multimedia files (3GG, 3GP, 3G2)
    /// </summary>
    public class ThreeGPP : Ftyp
    {
        private static readonly byte[] signature = { 0x33, 0x67, 0x70 };

        public ThreeGPP() : base(signature, "video/3gpp", "3gp")
        {
        }
    }
}
