namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a video.
    /// </summary>
    /// <remarks>
    /// This is just a stub class to assist with selecting video formats.
    /// </remarks>
    public abstract class Video : FileFormat
    {
        protected Video(byte[] signature, string mediaType, string extension) : base(signature, mediaType, extension)
        {
        }

        protected Video(byte[] signature, string mediaType, string extension, int offset)
            : base(signature, mediaType, extension, offset)
        {
        }
    }
}