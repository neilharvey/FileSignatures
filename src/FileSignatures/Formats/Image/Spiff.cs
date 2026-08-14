namespace FileSignatures.Formats.Image
{
    /// <summary>
    /// Specified the format of a Still Picture Interchange File Format (SPIFF) file.
    /// </summary>
    public class Spiff : Jpeg
    {
        public Spiff() : base([0xFF, 0xE8])
        {
        }
    }
}
