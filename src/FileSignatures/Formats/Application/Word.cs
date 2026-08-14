namespace FileSignatures.Formats.Application;

/// <summary>
/// Specifies the format of a Word document.
/// </summary>
public class Word : OfficeOpenXml
{
    public Word() : base("word/document.xml", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx") { }

    protected Word(string identifiableEntry, string mediaType, string extension, string contentTypeOverride) : base(identifiableEntry, mediaType, extension, contentTypeOverride) { }
}

/// <summary>
/// Specifies the format of a Word 97-2003 document.
/// </summary>
public class WordLegacy : Cfb
{
    public WordLegacy() : base("WordDocument", "application/msword", "doc")
    {
    }
}

///// <summary>
///// Specifies the format of a Word template file (dotx).
///// </summary>
public class WordTemplate : OfficeOpenXml
{
    public WordTemplate() : base(
        "word/document.xml",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.template",
        "dotx",
        "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml")
    { }
}

/// <summary>
/// Specifies the format of a Word document with macros.
/// </summary>
public class WordWithMacros : Word
{
    public WordWithMacros() : base("word/document.xml", "application/vnd.ms-word.document.macroEnabled.12", "docm", "application/vnd.ms-word.document.macroEnabled.main+xml") { }
}