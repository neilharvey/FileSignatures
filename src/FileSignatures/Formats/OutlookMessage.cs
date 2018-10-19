namespace FileSignatures.Formats
{
    public class OutlookMessage : CompoundBinaryFile
    {
        public OutlookMessage() : base("00020d0b-0000-0000-c000-000000000046", "application/vnd.ms-outlook", "msg")
        {
        }
    }
}
