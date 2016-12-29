using System;
using System.Collections.Generic;
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
        [InlineData("rtf","application/rtf")]
        [InlineData("png", "image/png")]
        [InlineData("ppt", "application/vnd.ms-powerpoint")]
        [InlineData("xls", "application/vnd.ms-excel")]
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
            var expected = new FileFormat(new byte[] { 0x00, 0x01 }, "example/x", "x");
            var incorrect = new FileFormat(new byte[] { 0x00, 0x02 }, "example/y", "y");
            var stream = new FragmentedStream(new byte[] { 0x00, 0x01, 0x03});
            var inspector = new FileFormatInspector(new HashSet<FileFormat>() { expected, incorrect });

            var result = inspector.DetermineFileFormat(stream);

            Assert.Equal(expected, result);
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
    }
}
