namespace FileSignatures.Formats.Application
{
    /// <summary>
    /// Specifies the format of an Excel workbook.
    /// </summary>
    public class Excel : OfficeOpenXml
    {
        public Excel() : base("xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx") { }

        protected Excel(string identifiableEntry, string mediaType, string extension, string contentTypeOverride) : base(identifiableEntry, mediaType, extension, contentTypeOverride) { }
    }

    /// <summary>
    /// Specifies the format of an Excel 97-2003 workbook.
    /// </summary>
    public class ExcelLegacy : Cfb
    {
        public ExcelLegacy() : base("Workbook", "application/vnd.ms-excel", "xls")
        {
        }
    }

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

    /// <summary>
    /// Specifies the format of an Excel workbook that supports macros.
    /// </summary>
    public class ExcelWithMacros : Excel
    {
        public ExcelWithMacros() : base("xl/workbook.xml", "application/vnd.ms-excel.sheet.macroEnabled.12", "xlsm", "application/vnd.ms-excel.sheet.macroEnabled.main+xml") { }
    }
}
