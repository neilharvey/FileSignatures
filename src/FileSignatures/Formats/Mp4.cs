using System.IO;
using System.Linq;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a MP4 file (ISO 8859-1).
    /// Common MIME types: MP4 video
    /// </summary>
    /// <see ref="https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types"/>
    /// <see ref="https://en.wikipedia.org/wiki/List_of_file_signatures"/>
    /// <see ref="https://www.garykessler.net/library/file_sigs.html"/>
    public class Mp4 : FileFormat
    {
        /// <summary>
        /// ISO Base Media file (MPEG-4) v1
        /// </summary>
        private static readonly byte[] MP4v1 = {0x66, 0x74, 0x79, 0x70, 0x69, 0x73, 0x6F, 0x6D};

        /// <summary>
        /// MPEG-4 video|QuickTime file
        /// </summary>
        private static readonly byte[] M4V = {0x66, 0x74, 0x79, 0x70, 0x6D, 0x70, 0x34, 0x32};

        /// <summary>
        /// QuickTime movie file
        /// </summary>
        private static readonly byte[] MOV = {0x66, 0x74, 0x79, 0x70, 0x71, 0x74, 0x20, 0x20};

        /// <summary>
        /// MPEG-4 video file
        /// </summary>
        private static readonly byte[] MP4 = {0x66, 0x74, 0x79, 0x70, 0x4D, 0x53, 0x4E, 0x56};

        /// <summary>
        /// ISO Media, MPEG v4 system, or iTunes AVC-LC file
        /// </summary>
        private static readonly byte[] FLV = {0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x56, 0x20};

        /// <summary>
        /// Apple Lossless Audio Codec file
        /// </summary>
        private static readonly byte[] M4A = {0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x41, 0x20};

        /// <summary>
        /// 3rd Generation Partnership Project 3GPP multimedia files
        /// 3GG, 3GP, 3G2
        /// </summary>
        private static readonly byte[] FTYP3GP = {0x66, 0x74, 0x79, 0x70, 0x33, 0x67, 0x70};

        private static readonly byte[] CommonSignaturePart = {0x66, 0x74, 0x79, 0x70};

        public Mp4() : base(CommonSignaturePart, "video/mp4", "mp4", offset: 4)
        {
        }

        public override bool IsMatch(Stream stream)
        {
            var offset = HeaderLength + Offset;

            return base.IsMatch(stream) && new[]
            {
                CheckContains(stream, MP4.Skip(HeaderLength).ToList().AsReadOnly(), offset),
                CheckContains(stream, MP4v1.Skip(HeaderLength), offset),
                CheckContains(stream, M4V.Skip(HeaderLength), offset),
                CheckContains(stream, MOV.Skip(HeaderLength), offset),
                CheckContains(stream, FLV.Skip(HeaderLength), offset),
                CheckContains(stream, M4A.Skip(HeaderLength), offset),
                CheckContains(stream, FTYP3GP.Skip(HeaderLength), offset),
            }.Any(x => x);
        }
    }
}