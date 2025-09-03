using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Excel workbook that supports macros.
    /// </summary>
    public class ExcelWithMacros : Excel
    {
        public ExcelWithMacros() : base("xl/workbook.xml", "application/vnd.ms-excel.sheet.macroEnabled.12", "xlsm", "application/vnd.ms-excel.sheet.macroEnabled.main+xml") { }
    }
}