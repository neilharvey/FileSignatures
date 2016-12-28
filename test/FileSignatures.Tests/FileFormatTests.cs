using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileFormatTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData(new byte[] { })]
        public void SignatureCannotBeNullOrEmpty(byte[] badSignature)
        {
            Assert.Throws<ArgumentNullException>(() => new FileFormat(badSignature, "bad", "example/bad"));
        }

        [Fact]
        public void StaticFileTypesCanBeEnumerated()
        {
            var expected = typeof(FileFormat)
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .OfType<FileFormat>();

            var result = FileFormat.GetAll();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void EqualityIsBasedOnSignature()
        {
            var first = new FileFormat(new byte[] { 0x01 }, "1", "example/one");
            var second = new FileFormat(new byte[] { 0x01 }, "2", "example/two");

            Assert.Equal(first, second);
        }

        [Fact]
        public void GetHashCodeIsBasedOnSignature()
        {
            var first = new FileFormat(new byte[] { 0x01 }, "1", "example/one");
            var second = new FileFormat(new byte[] { 0x01 }, "2", "example/two");

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }
    }
}
