using System;
using System.IO;

namespace FileSignatures.Formats
{
    /// <summary>
    /// Specifies the format of a Compound Binary File.
    /// </summary>
    /// <remarks>
    /// See [MS-CFB] https://msdn.microsoft.com/en-us/library/dd942138.aspx,
    /// in particular 2.2 for a description of the CFB header specification.
    /// </remarks>
    public abstract class CompoundFileBinary : FileFormat
    { 
        /// <summary>
        /// Initializes a new instance of the CompoundFileBinary class.
        /// </summary>
        /// <param name="clsid">The object CLSID which identifies the creating application.</param>
        /// <param name="mediaType">The media type of the format.</param>
        /// <param name="extension">The appropriate extension for the format.</param>
        public CompoundFileBinary(string clsid, string mediaType, string extension) : base(
            new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
            int.MaxValue,
            mediaType,
            extension)
        {
            if (string.IsNullOrEmpty(clsid))
            {
                throw new ArgumentNullException(nameof(clsid));
            }

            CLSID = Guid.Parse(clsid);
        }

        /// <summary>
        /// Gets the object class CLSID which identifies the application that created the file.
        /// </summary>
        public Guid CLSID { get; }

        /// <summary>
        /// Returns a value indicating whether the format matches a file header.
        /// </summary>
        /// <param name="header">The header to check.</param>
        public override bool IsMatch(byte[] header)
        {
            if (!base.IsMatch(header))
            {
                return false;
            }

            try
            {
                using (var ms = new MemoryStream(header))
                using (var br = new BinaryReader(ms))
                {
                    var cbfh = ReadHeader(br);

                    // Sector shift gives up the size as a power of two.  Only valid values are 9 or 12.
                    var sectorSize = 1 << cbfh.SectorShift;

                    // File header is one sector wide. 
                    var rootDirectoryAddress = sectorSize + (cbfh.FirstDirectorySectorLocation * sectorSize);

                    // Object type field is offset 80 bytes into the directory sector.
                    // It is a 128 bit GUID, encoded as DWORD, WORD, WORD, BYTE[8]
                    ms.Position = rootDirectoryAddress + 80;
                    var a = br.ReadInt32();
                    var b = br.ReadInt16();
                    var c = br.ReadInt16();
                    var d = br.ReadBytes(8);

                    var objectClass = new Guid(a, b, c, d);

                    return objectClass.Equals(CLSID);
                }
            }
            catch (EndOfStreamException)
            {
                return false;
            }
        }

        private static CompoundBinaryFileHeader ReadHeader(BinaryReader binaryReader)
        {
            var cbfh = new CompoundBinaryFileHeader();

            cbfh.HeaderSignature = binaryReader.ReadBytes(8);
            cbfh.HeaderCLSID = binaryReader.ReadBytes(16);
            cbfh.MinorVersion = binaryReader.ReadUInt16();
            cbfh.MajorVersion = binaryReader.ReadUInt16();
            cbfh.ByteOrder = binaryReader.ReadUInt16();
            cbfh.SectorShift = binaryReader.ReadUInt16();
            cbfh.MiniSectorShift = binaryReader.ReadUInt16();
            cbfh.Reserved = binaryReader.ReadBytes(6);
            cbfh.DirectorySectorsCount = binaryReader.ReadInt32();
            cbfh.FatSectorsCount = binaryReader.ReadInt32();
            cbfh.FirstDirectorySectorLocation = binaryReader.ReadInt32();
            cbfh.TransactionSignatureNumber = binaryReader.ReadUInt32();
            cbfh.MiniStreamCutoffSize = binaryReader.ReadUInt32();
            cbfh.FirstMiniFatSectorLocation = binaryReader.ReadInt32();
            cbfh.MiniFatSectorCount = binaryReader.ReadUInt32();
            cbfh.FirstDifatSectorLocation = binaryReader.ReadInt32();
            cbfh.DifatSectorCount = binaryReader.ReadUInt32();

            return cbfh;
        }

        private struct CompoundBinaryFileHeader
        {
            public byte[] HeaderSignature { get; internal set; }

            public byte[] HeaderCLSID { get; internal set; }

            public ushort MinorVersion { get; internal set; }

            public ushort MajorVersion { get; internal set; }

            public ushort ByteOrder { get; internal set; }

            public ushort SectorShift { get; internal set; }

            public ushort MiniSectorShift { get; internal set; }

            public byte[] Reserved { get; internal set; }

            public int DirectorySectorsCount { get; internal set; }

            public int FatSectorsCount { get; internal set; }

            public int FirstDirectorySectorLocation { get; internal set; }

            public uint TransactionSignatureNumber { get; internal set; }

            public uint MiniStreamCutoffSize { get; internal set; }

            public int FirstMiniFatSectorLocation { get; internal set; }

            public uint MiniFatSectorCount { get; internal set; }

            public int FirstDifatSectorLocation { get; internal set; }

            public uint DifatSectorCount { get; internal set; }
        }
    }
}
