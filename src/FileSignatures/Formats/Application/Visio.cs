namespace FileSignatures.Formats.Application;

public class Visio : OfficeOpenXml
{
    public Visio() : base("visio/document.xml",  "application/vnd.visio", "vsdx")
    {
    }
}

public class VisioLegacy : Cfb
{
    public VisioLegacy() : base("VisioDocument", "application/vnd.visio", "vsd")
    {
    }
}    
