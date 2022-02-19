namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a MPEG-4 video file.
    /// </summary>
    public abstract class Mpeg4 : Ftyp
    {
        protected Mpeg4(byte[] signature, string extension) : base(signature, "video/mp4", extension)
        {
        }
    }
}
