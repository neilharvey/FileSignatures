using System.IO;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileFormatInspectorTests
    {
        [Fact]
        public void UnrecognisedReturnsNull()
        {
            var result = InspectSample("unknown");

            Assert.Null(result);
        }

        [Theory]
        [InlineData("bmp", "image/bmp")]
        [InlineData("doc", "application/msword")]
        [InlineData("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [InlineData("gif", "image/gif")]
        [InlineData("jpg", "image/jpeg")]
        [InlineData("pdf", "application/pdf")]
        [InlineData("rtf", "application/rtf")]
        [InlineData("png", "image/png")]
        [InlineData("ppt", "application/vnd.ms-powerpoint")]
        [InlineData("xls", "application/vnd.ms-excel")]
        [InlineData("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [InlineData("xps", "application/vnd.ms-xpsdocument")]
        public void SamplesAreRecognised(string sample, string expectedMimeType)
        {
            var result = InspectSample(sample);

            Assert.NotNull(result);
            Assert.Equal(sample, result.Extension);
            Assert.Equal(expectedMimeType, result.MediaType);
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
        public void StreamIsNotFullyReadUnlessRequired()
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

            Assert.Equal(1 + shortSignature.HeaderLength, position);
        }

        private static FileFormat InspectSample(string fileName)
        {
            var inspector = new FileFormatInspector();
            var sample = new FileInfo(Path.Combine("Samples", fileName));
            FileFormat result;

            using (var stream = sample.OpenRead())
            {
                result = inspector.DetermineFileFormat(stream);
            }

            return result;
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
    }
}
