namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Powerpoint presentation that supports macros.
    /// </summary>
    public class PowerPointWithMacros : OfficeOpenXml
    {
        public PowerPointWithMacros() : base("ppt/presentation.xml", macroEnabled: true, "application/vnd.ms-powerpoint.presentation.macroEnabled.12", "pptm")
        {
        }
    }
}
