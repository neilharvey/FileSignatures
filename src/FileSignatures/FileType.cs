namespace FileSignatures
{
    public partial class FileType
    {
        public FileType(byte[] signature, int offset, string extension)
        {
            Signature = signature;
            Offset = offset;
            Extension = extension;
        }

        public byte[] Signature { get; }

        public int Offset { get; }

        public string Extension { get; }
    }
}
