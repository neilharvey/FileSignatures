namespace FileSignatures.Formats.Application;

public class OutlookMessage : Cfb
{
    public OutlookMessage() : base("__properties_version1.0", "application/vnd.ms-outlook", "msg")
    {
    }
}
