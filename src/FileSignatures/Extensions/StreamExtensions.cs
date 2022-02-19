using System.Collections.Generic;
using System.IO;

namespace FileSignatures.Extensions
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Check stream contains sequence at specific offset.
        /// </summary>
        /// <param name="stream">The stream to check.</param>
        /// <param name="sequence">The subsequence which should be found.</param>
        /// <param name="offset">Offset in the stream at which the subsequence should be located.</param>
        /// <returns></returns>
        public static bool CheckContains(this Stream stream, IEnumerable<byte> sequence, int offset = 0)
        {
            stream.Position = offset;

            foreach (var el in sequence)
            {
                var b = stream.ReadByte();
                if (b != el)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
