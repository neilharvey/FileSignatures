namespace FileSignatures.Formats;

/// <summary>
/// An Excel workbook stored in binary format.
/// </summary>
/// <remarks>
/// See https://www.iana.org/assignments/media-types/application/vnd.ms-excel.sheet.binary.macroEnabled.12
/// </remarks>
public class ExcelBinary : OfficeOpenXml
{
    public ExcelBinary() : base("xl/workbook.bin", "vnd.ms-excel.sheet.binary.macroEnabled.12", "xlsb")
    {
    }
}
