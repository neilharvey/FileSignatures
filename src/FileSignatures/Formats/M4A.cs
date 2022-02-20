namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Apple Lossless Audio Codec file
    /// </summary>
    public class M4A : Isobmff
    {
        public M4A() : base(new byte[] { 0x4D, 0x34, 0x41, 0x20 }, "audio/mp4", "m4a")
        {
        }
    }
}
