using System.IO;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileFormatInspectorTests
    {
        [Fact]
        public void UnrecognisedReturnsNull()
        {
            var inspector = new FileFormatInspector(new FileFormat[] { });
            FileFormat result;

            using(var stream = new MemoryStream(new byte[] { 0x0A }))
            {
                result = inspector.DetermineFileFormat(stream);
            }

            Assert.Null(result);
        }

        [Fact]
        public void SingleMatchIsReturned()
        {
            var expected = new TestFileFormat(new byte[] { 0x42, 0x4D });
            var inspector = new FileFormatInspector(new FileFormat[] { expected });
            FileFormat result;

            using (var stream = new MemoryStream(new byte[] { 0x42, 0x4D, 0x3A, 0x00 }))
            {
                result = inspector.DetermineFileFormat(stream);
            }

            Assert.Equal(expected, result);
        }

        [Fact]
        public void StreamIsReadUntilRequiredBufferIsReceived()
        {
            var expected = new TestFileFormat(new byte[] { 0x00, 0x01 });
            var incorrect = new TestFileFormat(new byte[] { 0x00, 0x02 });
            var inspector = new FileFormatInspector(new FileFormat[] { expected, incorrect });
            FileFormat result;

            using (var fragmentedStream = new FragmentedStream(new byte[] { 0x00, 0x01, 0x03 }))
            {
                result = inspector.DetermineFileFormat(fragmentedStream);
            }

            Assert.Equal(expected, result);
        }

        [Fact]
        public void StreamIsResetToOriginalPosition()
        {
            var shortSignature = new TestFileFormat(new byte[] { 0x00, 0x01 });
            var longSignaure = new TestFileFormat(new byte[] { 0x00, 0x01, 0x02 });
            var inspector = new FileFormatInspector(new FileFormat[] { shortSignature, longSignaure });
            var position = 0L;

            using (var stream = new MemoryStream(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04 }))
            {
                inspector.DetermineFileFormat(stream);
                position = stream.Position;
            }

            Assert.Equal(0, position);
        }

        [Fact]
        public void MostSpecificFormatIsReturned()
        {
            var baseFormat = new BaseFormat();
            var inheritedFormat = new InheritedFormat();
            var inspector = new FileFormatInspector(new FileFormat[] { inheritedFormat, baseFormat });
            FileFormat result = null;

            using (var stream = new MemoryStream(new byte[] { 0x00 }))
            {
                result = inspector.DetermineFileFormat(stream);
            }

            Assert.Equal(inheritedFormat, result);
        }

        private class FragmentedStream : MemoryStream
        {
            public FragmentedStream(byte[] buffer) : base(buffer)
            {
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return base.Read(buffer, offset, 1);
            }
        }

        private class TestFileFormat : FileFormat
        {
            public TestFileFormat(byte[] signature) : base(signature, "example/test", "test")
            {
            }
        }

        private class BaseFormat : FileFormat
        {
            public BaseFormat() : this("example/base")
            {
            }

            protected BaseFormat(string mediaType) : base(new byte[] { 0x00 }, mediaType, "")
            {
            }

            public override bool IsMatch(byte[] header)
            {
                return true;
            }
        }

        private class InheritedFormat : BaseFormat
        {
            public InheritedFormat() : base("example/inherited")
            {
            }
        }
    }
}
