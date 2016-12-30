namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Excel workbook.
    /// </summary>
    public class ExcelFormat : OfficeOpenXmlFormat
    {
        public ExcelFormat() : base("xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx")
        {
        }
    }
}
