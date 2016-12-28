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
        public void SamplesAreRecognised(string sample, string expectedMimeType)
        {
            var result = InspectSample(sample);

            Assert.NotNull(result);
            Assert.Equal(sample, result.Extension);
            Assert.Equal(expectedMimeType, result.MediaType);
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
    }
}
