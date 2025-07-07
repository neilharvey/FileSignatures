namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a zip archive.
    /// </summary>
    public class Zip : FileFormat
    {
        public Zip() : this(headerLength: 4, "application/zip", "zip")
        {
        }

        protected Zip(int headerLength, string mediaType, string extension) : base([0x50, 0x4B, 0x03, 0x04], headerLength, mediaType, extension)
        {
        }
    }
}
