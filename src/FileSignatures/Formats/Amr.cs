namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of an Adaptive Multi-Rate ACELP (Algebraic Code Excited Linear Prediction) Codec file
    /// Commonly audio format with GSM cell phones. (See RFC 4867.)
    /// </summary>
    public class Amr : FileFormat
    {
        public Amr() : base(new byte[] { 0x23, 0x21, 0x41, 0x4D, 0x52 }, "audio/amr", "amr") { }
    }
}
