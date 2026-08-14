namespace FileSignatures.Formats.Application;

/// <summary>
/// Specifies the format of a Powerpoint presentation.
/// </summary>
public class PowerPoint : OfficeOpenXml
{
    public PowerPoint() : base("ppt/presentation.xml", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx") { }

    protected PowerPoint(string identifiableEntry, string mediaType, string extension, string contentTypeOverride) : base(identifiableEntry, mediaType, extension, contentTypeOverride) { }
}

/// <summary>
/// Specifies the format of a legacy Powerpoint 97-2003 presentation.
/// </summary>
public class PowerPointLegacy : Cfb
{
    public PowerPointLegacy() : base("PowerPoint Document", "application/vnd.ms-powerpoint", "ppt")
    {
    }
}

/// <summary>
/// Specifies the format of a Powerpoint presentation that supports macros.
/// </summary>
public class PowerPointWithMacros : PowerPoint
{
    public PowerPointWithMacros() : base("ppt/presentation.xml", "application/vnd.ms-powerpoint.presentation.macroEnabled.12", "pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.main+xml") { }
}