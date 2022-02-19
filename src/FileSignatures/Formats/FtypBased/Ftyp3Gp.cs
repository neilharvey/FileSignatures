namespace FileSignatures.Formats.FtypBased
{
    /// <summary>
    /// Specifies the format of a 3rd Generation Partnership Project 3GPP multimedia files (3GG, 3GP, 3G2)
    /// </summary>
    public class Ftyp3Gp : FtypBase
    {
        private static readonly byte[] FTYP3GP = { 0x33, 0x67, 0x70 };

        public Ftyp3Gp() : base(FTYP3GP, "video/3gpp", "3gp")
        {
        }
    }
}
