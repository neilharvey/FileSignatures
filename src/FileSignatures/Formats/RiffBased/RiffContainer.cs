using System.IO;
using FileSignatures.Extensions;

namespace FileSignatures.Formats.RiffBased
{
    public static class RiffContainer
    {
        /// <summary>
        /// ASCII: `RIFF`
        /// </summary>
        private static readonly byte[] RIFF = { 0x52, 0x49, 0x46, 0x46 };

        public static bool IsRiffBased(Stream stream) => stream.CheckContains(RIFF);
    }
}
