namespace FileSignatures.Formats
{
    public class OutlookMessage : CompoundFileBinary
    {
        public OutlookMessage() : base("__properties_version1.0", "application/vnd.ms-outlook", "msg")
        {
        }
    }
}
