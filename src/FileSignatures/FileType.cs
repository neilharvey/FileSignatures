namespace FileSignatures
{
    public class FileType
    {
        public byte[] Signature { get; }

        public int Offset { get; }

        public string Extension { get; }
    }
}
