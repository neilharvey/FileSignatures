namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Excel 97-2003 workbook.
    /// </summary>
    public class ExcelLegacy : CompoundBinaryFile
    {
        public ExcelLegacy() : base("00020820-0000-0000-c000-000000000046", "application/vnd.ms-excel", "xls")
        {
        }
    }
}
