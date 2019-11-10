namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Joint Photographics Experts Group (JPEG) image.
    /// </summary>
    public class Jpeg : Image
    {
        private static readonly byte[] soi = new byte[] { 0xFF, 0xD8 };
        private const string mediaType = "image/jpeg";
        private const string extension = "jpg";

        /// <summary>
        /// Initialises a new Jpeg format.
        /// <summary>
        public Jpeg() : base(soi, mediaType, extension)
        {
        }

        /// <summary>
        /// Initialises a new Jpeg format with the specified application marker.
        /// </summary>
        /// <param name="marker">The 2-byte application marker used by the JPEG format.</param>
        protected Jpeg(byte[] marker) : base(new byte[] { soi[0], soi[1], marker[0], marker[1] }, mediaType, extension)
        {
        }
    }
}
