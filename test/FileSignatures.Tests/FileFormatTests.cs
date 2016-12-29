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
            Assert.Throws<ArgumentNullException>(() => new FileFormat(badSignature, "example/bad", "bad"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MediaTypeCannotBeNullOrEmpty(string badMediaType)
        {
            Assert.Throws<ArgumentNullException>(() => new FileFormat(new byte[] { 0x01 }, badMediaType, "bad"));
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
            var first = new FileFormat(new byte[] { 0x01 }, "example/one", "1");
            var second = new FileFormat(new byte[] { 0x01 }, "example/two", "2");

            Assert.Equal(first, second);
        }

        [Fact]
        public void GetHashCodeIsBasedOnSignature()
        {
            var first = new FileFormat(new byte[] { 0x01 }, "example/one", "1");
            var second = new FileFormat(new byte[] { 0x01 }, "example/two", "2");

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        [Fact]
        public void MatchesHeaderContainingSignature()
        {
            var format = new FileFormat(new byte[] { 0x6F, 0x3C }, "example/sim", "");
            var header = new byte[] { 0x6F, 0x3c, 0xFF, 0xFA };

            Assert.True(format.IsMatch(header));
        }

        [Theory]
        [InlineData(new byte[] { 0x6F })]
        [InlineData(new byte[] { 0x3C, 0x6F })]
        public void DoesNotMatchDifferentHeader(byte[] header)
        {
            var format = new FileFormat(new byte[] { 0x6F, 0x3C }, "example/sim", "");

            Assert.False(format.IsMatch(header));
        }
    }
}
