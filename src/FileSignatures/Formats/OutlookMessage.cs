namespace FileSignatures.Formats
{
    public class OutlookMessage : CompoundFileBinary
    {
        public OutlookMessage() : base("?????", "application/vnd.ms-outlook", "msg")
        {
        }
    }
}
