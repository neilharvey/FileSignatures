namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Excel workbook that supports macros.
    /// </summary>
    public class ExcelWithMacros : OfficeOpenXml, IFileFormatReader
    {
        public ExcelWithMacros() : base("xl/workbook.xml",  "application/vnd.ms-excel.sheet.macroEnabled.12", "xlsm")
        {
        }
    }
}
