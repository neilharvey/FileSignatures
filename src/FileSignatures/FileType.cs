namespace FileSignatures
{
    public partial class FileType
    {
        public FileType(byte[] signature, int offset, string extension, string mimeType)
        {
            Signature = signature;
            Offset = offset;
            Extension = extension;
            MimeType = mimeType;
        }

        public byte[] Signature { get; }

        public int Offset { get; }

        public string Extension { get; }

        public string MimeType { get; }
    }
}
