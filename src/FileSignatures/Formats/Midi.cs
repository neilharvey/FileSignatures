namespace FileSignatures.Formats;

/// <summary>
/// Musical Instrument Digital Interface (MIDI) format.
/// </summary>
/// <remarks>
/// There does not appear to be an IANA registration for this format but audio/midi appears to be commonly used.
/// </remarks>
public class Midi: FileFormat
{
    public Midi() : base([0x4D, 0x54, 0x68, 0x64], "audio/midi", "mid")
    {
    }
}