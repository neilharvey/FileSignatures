using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace FileSignatures
{
    public partial class FileFormat
    {
        public FileFormat(byte[] signature, string extension, string mediaType) : this(signature, signature == null ? 0 : signature.Length, extension, mediaType)
        {
        }

        public FileFormat(byte[] signature, int headerLength, string extension, string mediaType)
        {
            if (signature == null || signature.Length == 0)
            {
                throw new ArgumentNullException(nameof(signature));
            }

            if (string.IsNullOrEmpty(mediaType))
            {
                throw new ArgumentNullException(nameof(mediaType));
            }

            Signature = new ReadOnlyCollection<byte>(signature);
            HeaderLength = headerLength;
            Extension = extension;
            MediaType = mediaType;
        }

        public ReadOnlyCollection<byte> Signature { get; }

        public int HeaderLength { get; }

        public string Extension { get; }

        public string MediaType { get; }

        public virtual bool IsMatch(byte[] header)
        {
            if (header == null || header.Length < HeaderLength)
            {
                return false;
            }

            for (int i = 0; i < Signature.Count; i++)
            {
                if (header[i] != Signature[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static IEnumerable<FileFormat> GetAll()
        {
            return typeof(FileFormat)
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .OfType<FileFormat>();
        }

        public override bool Equals(object obj)
        {
            var fileFormat = obj as FileFormat;

            if (fileFormat == null)
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
