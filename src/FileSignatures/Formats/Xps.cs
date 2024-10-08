﻿namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an XML Paper Specification (XPS) document.
    /// </summary>
    public class Xps : OfficeOpenXml
    {
        public Xps() : base("FixedDocSeq.fdseq", macroEnabled: false, "application/vnd.ms-xpsdocument", "xps")
        {
        }
    }
}
