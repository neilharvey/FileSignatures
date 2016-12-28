using System.IO;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileTypeInspectorTests
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
            Assert.Equal(expectedMimeType, result.MimeType);
        }

        private static FileType InspectSample(string fileName)
        {
            var inspector = new FileTypeInspector();
            var sample = new FileInfo(Path.Combine("Samples", fileName));
            FileType result;

            using (var stream = sample.OpenRead())
            {
                result = inspector.DetermineFileType(stream);
            }

            return result;
        }
    }
}
