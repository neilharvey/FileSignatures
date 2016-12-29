using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FileSignatures
{
    public partial class FileFormat
    {
        private static IEnumerable<FileFormat> all;

        static FileFormat()
        {
            all = typeof(FileFormat)
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .OfType<FileFormat>();
        }

        public FileFormat(byte[] signature, string extension, string mimeType)
        {
            if(signature == null || signature.Length == 0)
            {
                throw new ArgumentNullException(nameof(signature));
            }

            Signature = signature;
            Extension = extension;
            MediaType = mimeType;
        }

        public byte[] Signature { get; }

        public string Extension { get; }

        public string MediaType { get; }

        public static IEnumerable<FileFormat> GetAll()
        {
            return all;
        }

        public override bool Equals(object obj)
        {
            var fileFormat = obj as FileFormat;

            if(fileFormat == null)
            {
                return false;
            }
            else
            {
                return fileFormat.Signature.SequenceEqual(Signature);
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (Signature == null)
                {
                    return 0;
                }

                var hash = 17;
                foreach (var element in Signature)
                {
                    hash = hash * 31 + element.GetHashCode();
                }

                return hash;
            }
        }
    }
}
