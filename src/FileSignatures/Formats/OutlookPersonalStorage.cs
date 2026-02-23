namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Microsoft Outlook Personal Storage Table (PST/OST) file.
/// </summary>
/// <remarks>
/// See https://learn.microsoft.com/en-us/openspecs/office_file_formats/ms-pst
/// </remarks>
public class OutlookPersonalStorage : FileFormat
{
    public OutlookPersonalStorage() : base([0x21, 0x42, 0x44, 0x4E], "application/vnd.ms-outlook-pst", "pst")
    {
    }
}
