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
        [InlineData("jpg")]
        [InlineData("bmp")]
        [InlineData("gif")]
        [InlineData("png")]
        public void SamplesAreRecognised(string sample)
        {
            var result = InspectSample(sample);

            Assert.NotNull(result);
            Assert.Equal(sample, result.Extension);
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
