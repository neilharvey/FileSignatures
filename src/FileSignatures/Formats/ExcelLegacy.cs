namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Excel 97-2003 workbook.
    /// </summary>
    public class ExcelLegacy : CompoundFileBinary
    {
        public ExcelLegacy() : base("Workbook", "application/vnd.ms-excel", "xls")
        {
        }
    }
}
