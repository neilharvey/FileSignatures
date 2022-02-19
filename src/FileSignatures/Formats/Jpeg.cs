namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Joint Photographics Experts Group (JPEG) image.
    /// </summary>
    public class Jpeg : Image
    {
        private static readonly byte[] Soi = { 0xFF, 0xD8 };
        private const string JpegMediaType = "image/jpeg";
        private const string JpegExtension = "jpg";

        /// <summary>
        /// Initialises a new Jpeg format.
        /// </summary>
        public Jpeg() : base(Soi, JpegMediaType, JpegExtension)
        {
        }

        /// <summary>
        /// Initialises a new Jpeg format with the specified application marker.
        /// </summary>
        /// <param name="marker">The 2-byte application marker used by the JPEG format.</param>
        protected Jpeg(byte[] marker)
            : base(new[] { Soi[0], Soi[1], marker[0], marker[1] }, JpegMediaType, JpegExtension)
        {
        }
    }
}
