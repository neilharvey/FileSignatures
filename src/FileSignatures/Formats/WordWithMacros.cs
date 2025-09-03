using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Word document with macros.
    /// </summary>
    public class WordWithMacros : Word
    {
        public WordWithMacros() : base("word/document.xml", "application/vnd.ms-word.document.macroEnabled.12", "docm", "application/vnd.ms-word.document.macroEnabled.main+xml") { }
    }
}