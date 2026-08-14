namespace FileSignatures.Formats.Application;

/// <summary>
/// Specifies the format of a Webassembly module
/// </summary>
public class Wasm : FileFormat
{
    public Wasm() : base([0x00, 0x61, 0x73, 0x6D], "application/wasm", "wasm")
    {
    }
}