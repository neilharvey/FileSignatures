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
            Assert.Throws<ArgumentNullException>(() => new ConcreteFileFormat(badSignature, "example/bad", "bad"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MediaTypeCannotBeNullOrEmpty(string badMediaType)
        {
            Assert.Throws<ArgumentNullException>(() => new ConcreteFileFormat(new byte[] { 0x01 }, badMediaType, "bad"));
        }

        [Fact]
        public void EqualityIsBasedOnSignature()
        {
            var first = new ConcreteFileFormat(new byte[] { 0x01 }, "example/one", "1");
            var second = new ConcreteFileFormat(new byte[] { 0x01 }, "example/two", "2");

            Assert.Equal(first, second);
        }

        [Fact]
        public void GetHashCodeIsBasedOnSignature()
        {
            var first = new ConcreteFileFormat(new byte[] { 0x01 }, "example/one", "1");
            var second = new ConcreteFileFormat(new byte[] { 0x01 }, "example/two", "2");

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        [Fact]
        public void MatchesHeaderContainingSignature()
        {
            var format = new ConcreteFileFormat(new byte[] { 0x6F, 0x3C }, "example/sim", "");
            var header = new byte[] { 0x6F, 0x3c, 0xFF, 0xFA };

            Assert.True(format.IsMatch(header));
        }

        [Theory]
        [InlineData(new byte[] { 0x6F })]
        [InlineData(new byte[] { 0x3C, 0x6F })]
        public void DoesNotMatchDifferentHeader(byte[] header)
        {
            var format = new ConcreteFileFormat(new byte[] { 0x6F, 0x3C }, "example/sim", "");

            Assert.False(format.IsMatch(header));
        }

        private class ConcreteFileFormat : FileFormat
        {
            public ConcreteFileFormat(byte[] signature, string mediaType, string extension) : base(signature, mediaType, extension)
            {
            }
        }
    }
}
