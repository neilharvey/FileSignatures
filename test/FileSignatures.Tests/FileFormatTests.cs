using System;
using System.IO;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileFormatTests
    {
        [Fact]
        public void SignatureCannotBeNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() => new ConcreteFileFormat(null, "example/bad", "bad"));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MediaTypeCannotBeNullOrEmpty(string badMediaType)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ConcreteFileFormat(new byte[] { 0x01 }, badMediaType, "bad"));
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
            var format = new ConcreteFileFormat(new byte[] { 0x6F, 0x3C }, "example/sim", string.Empty);
            var header = new byte[] { 0x6F, 0x3c, 0xFF, 0xFA };

            using var ms = new MemoryStream(header);
            var result = format.IsMatch(ms);

            Assert.True(result);
        }

        [Fact]
        public void MatchesSignatureAtOffsetPosition()
        {
            var format = new OffsetFileFormat(new byte[] { 0x03, 0x04 }, "example/test", string.Empty, 2);
            var header = new byte[] { 0x01, 0x02, 0x03, 0x04 };

            using var ms = new MemoryStream(header);
            var result = format.IsMatch(ms);

            Assert.True(result);
        }

        private class OffsetFileFormat : FileFormat
        {
            public OffsetFileFormat(byte[] signature, string mediaType, string extension, int offset)
                : base(signature, mediaType, extension, offset)
            {
            }
        }

        [Theory]
        [InlineData(new byte[] { 0x6F })]
        [InlineData(new byte[] { 0x3C, 0x6F })]
        public void DoesNotMatchDifferentHeader(byte[] header)
        {
            var format = new ConcreteFileFormat(new byte[] { 0x6F, 0x3C }, "example/sim", string.Empty);

            using var ms = new MemoryStream(header);
            var result = format.IsMatch(ms);

            Assert.False(result);
        }

        private class ConcreteFileFormat : FileFormat
        {
            public ConcreteFileFormat(byte[] signature, string mediaType, string extension)
                : base(signature, mediaType, extension)
            {
            }
        }
    }
}
