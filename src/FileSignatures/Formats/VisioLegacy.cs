namespace FileSignatures.Formats
{
    public class VisioLegacy : CompoundFileBinary
    {
        public VisioLegacy() : base("VisioDocument", "application/vnd.visio", "vsd")
        {
        }
    }
}
