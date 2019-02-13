using FileSignatures.Formats;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace FileSignatures.Tests
{
    public class FunctionalTests
    {
        [Theory]
        [InlineData("test.bmp", "image/bmp")]
        [InlineData("test.doc", "application/msword")]
        [InlineData("test.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [InlineData("test.exe", "application/octet-stream")]
        [InlineData("test.gif", "image/gif")]
        [InlineData("test.jfif", "image/jpeg")]
        [InlineData("test.exif", "image/jpeg")]
        [InlineData("saved.msg", "application/vnd.ms-outlook")]
        [InlineData("dragndrop.msg", "application/vnd.ms-outlook")]
        [InlineData("test.pdf", "application/pdf")]
        [InlineData("test.rtf", "application/rtf")]
        [InlineData("test.png", "image/png")]
        [InlineData("test.ppt", "application/vnd.ms-powerpoint")]
        [InlineData("test2.ppt", "application/vnd.ms-powerpoint")]
        [InlineData("test.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")]
        [InlineData("test.spiff", "image/jpeg")]
        [InlineData("test.tif", "image/tiff")]
        [InlineData("test.xls", "application/vnd.ms-excel")]
        [InlineData("test2.xls", "application/vnd.ms-excel")]
        [InlineData("test.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [InlineData("test.xps", "application/vnd.ms-xpsdocument")]
        [InlineData("test.zip", "application/zip")]
        [InlineData("test.dcm", "application/dicom")]
        [InlineData("test.odt", "application/vnd.oasis.opendocument.text")]
        [InlineData("test.ods", "application/vnd.oasis.opendocument.spreadsheet")]
        [InlineData("test.odp", "application/vnd.oasis.opendocument.presentation")]
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
