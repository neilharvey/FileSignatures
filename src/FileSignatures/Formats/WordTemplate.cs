using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FileSignatures.Formats
{
    ///// <summary>
    ///// Specifies the format of a Word template file (dotx).
    ///// </summary>
    public class WordTemplate : OfficeOpenXml, IFileFormatReader
    {
        public WordTemplate() : base(
            "word/document.xml", 
            "application/vnd.openxmlformats-officedocument.wordprocessingml.template", 
            "dotx", 
            "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml") { } 
    }
}