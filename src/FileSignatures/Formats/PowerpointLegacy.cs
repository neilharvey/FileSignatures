namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a legacy Powerpoint 97-2003 presentation.
    /// </summary>
    public class PowerPointLegacy : CompoundFileBinary
    {
        public PowerPointLegacy() : base("64818d10-4f9b-11cf-86ea-00aa00b929e8", "application/vnd.ms-powerpoint", "ppt")
        {
        }
    }
}
