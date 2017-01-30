namespace FileSignatures.Formats
{
    /// <summary>
    /// Specified the format of a Still Picture Interchange File Format (SPIFF) file.
    /// </summary>
    public class JpegSpiff : Jpeg
    {
        public JpegSpiff() : base(0xE8)
        {
        }
    }
}
