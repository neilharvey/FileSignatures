using System.IO;
using System.Reflection;
using Xunit;

namespace FileSignatures.Tests
{
    public class FunctionalTests
    {
        [Theory]
        [InlineData("bmp", "image/bmp")]
        [InlineData("doc", "application/msword")]
        [InlineData("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [InlineData("exe", "application/octet-stream")]
        [InlineData("gif", "image/gif")]
        [InlineData("jfif", "image/jpeg")]
        [InlineData("exif", "image/jpeg")]
        [InlineData("pdf", "application/pdf")]
        [InlineData("rtf", "application/rtf")]
        [InlineData("png", "image/png")]
        [InlineData("ppt", "application/vnd.ms-powerpoint")]
        [InlineData("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")]
        [InlineData("spiff", "image/jpeg")]
        [InlineData("tif", "image/tiff")]
        [InlineData("xls", "application/vnd.ms-excel")]
        [InlineData("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [InlineData("xps", "application/vnd.ms-xpsdocument")]
        [InlineData("zip", "application/zip")]
        public void SamplesAreRecognised(string sample, string expected)
        {
            var result = InspectSample(sample);

            Assert.NotNull(result);
            Assert.Equal(expected, result.MediaType);
        }

        private static FileFormat InspectSample(string fileName)
        {
            var inspector = new FileFormatInspector();
            var buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).GetTypeInfo().Assembly.Location);
            var sample = new FileInfo(Path.Combine(buildDirectoryPath, "Samples", fileName));
            FileFormat result;

            using (var stream = sample.OpenRead())
            {
                result = inspector.DetermineFileFormat(stream);
            }

            return result;
        }
    }
}
