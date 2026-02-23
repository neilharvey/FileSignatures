namespace FileSignatures.Formats;

/// <summary>
/// Specifies the format of a Microsoft Access database file (MDB).
/// </summary>
public class AccessLegacy : FileFormat
{
    public AccessLegacy() : base(
        [
            0x00, 0x01, 0x00, 0x00, 0x53, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x72, 0x64,
            0x20, 0x4A, 0x65, 0x74, 0x20, 0x44, 0x42
        ],
        "application/x-msaccess",
        "mdb")
    {
    }
}

/// <summary>
/// Specifies the format of a Microsoft Access 2007+ database file (ACCDB).
/// </summary>
public class Access : FileFormat
{
    public Access() : base(
        [
            0x00, 0x01, 0x00, 0x00, 0x53, 0x74, 0x61, 0x6E, 0x64, 0x61, 0x72, 0x64,
            0x20, 0x41, 0x43, 0x45, 0x20, 0x44, 0x42
        ],
        "application/x-msaccess",
        "accdb")
    {
    }
}
