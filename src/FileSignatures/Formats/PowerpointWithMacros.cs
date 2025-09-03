using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Powerpoint presentation that supports macros.
    /// </summary>
    public class PowerPointWithMacros : PowerPoint
    {
        public PowerPointWithMacros() : base("ppt/presentation.xml", "application/vnd.ms-powerpoint.presentation.macroEnabled.12", "pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.main+xml") { }
    }
}
