namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Excel 97-2003 workbook.
    /// </summary>
    public class ExcelLegacy : OleCompoundFile
    {
        public ExcelLegacy() : base(new byte[] { 0x09, 0x08, 0x10, 0x00 }, "application/vnd.ms-excel", "xls")
        {
        }
    }
}
