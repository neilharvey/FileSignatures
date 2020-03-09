namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an image.
    /// </summary>
    /// <remarks>
    /// This is just a stub class to assist with selecting image formats.
    /// </remarks>
    public abstract class Image : FileFormat
    {
        protected Image(byte[] signature, string mediaType, string extension) : base(signature, mediaType, extension)
        {
        }

        protected Image(byte[] signature, string mediaType, string extension, int offset) : base(signature, mediaType, extension, offset)
        {
        }
    }
}
