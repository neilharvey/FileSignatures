namespace FileSignatures.Formats.Image;

/// <summary>
/// Specifies the format of a Joint Photographics Experts Group (JPEG) image.
/// </summary>
public class Jpeg : FileFormat
{
    private static readonly byte[] soi = [0xFF, 0xD8];
    private const string mediaType = "image/jpeg";
    private const string extension = "jpg";

    /// <summary>
    /// Initialises a new Jpeg format.
    /// </summary>
    public Jpeg() : base(soi, mediaType, extension)
    {
    }

    /// <summary>
    /// Initialises a new Jpeg format with the specified application marker.
    /// </summary>
    /// <param name="marker">The 2-byte application marker used by the JPEG format.</param>
    protected Jpeg(byte[] marker) : base([soi[0], soi[1], marker[0], marker[1]], mediaType, extension)
    {
    }
}

/// <summary>
/// Specifies the format of a JPEG image containing EXIF data.
/// </summary>
public class JpegExif : Jpeg
{
    public JpegExif() : base([0xFF, 0xE1])
    {
    }
}
