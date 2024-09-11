namespace FileSignatures.Formats
{
    public class Visio : OfficeOpenXml
    {
        public Visio() : base("visio/document.xml", macroEnabled: false, "application/vnd.visio", "vsdx")
        {
        }
    }
}
