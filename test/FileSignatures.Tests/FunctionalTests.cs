using System.IO;
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
        [InlineData("test.docm", "application/vnd.ms-word.document.macroEnabled.12")]
        [InlineData("test.exe", "application/vnd.microsoft.portable-executable")]
        [InlineData("test.gif", "image/gif")]
        [InlineData("test.jfif", "image/jpeg")]
        [InlineData("test.exif", "image/jpeg")]
        [InlineData("saved.msg", "application/vnd.ms-outlook")]
        [InlineData("dragndrop.msg", "application/vnd.ms-outlook")]
        [InlineData("nonstandard.docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [InlineData("test.pdf", "application/pdf")]
        [InlineData("adobe.pdf", "application/pdf")]
        [InlineData("test.rtf", "application/rtf")]
        [InlineData("test.png", "image/png")]
        [InlineData("test.ppt", "application/vnd.ms-powerpoint")]
        [InlineData("test2.ppt", "application/vnd.ms-powerpoint")]
        [InlineData("test.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")]
        [InlineData("test.pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12")]
        [InlineData("test.spiff", "image/jpeg")]
        [InlineData("test.tif", "image/tiff")]
        [InlineData("bigendian.tif", "image/tiff")]
        [InlineData("test.xls", "application/vnd.ms-excel")]
        [InlineData("test.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [InlineData("test.xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12")]
        [InlineData("test.xps", "application/vnd.ms-xpsdocument")]
        [InlineData("test.zip", "application/zip")]
        [InlineData("test-rar4.rar", "application/vnd.rar")]
        [InlineData("test-rar5.rar", "application/vnd.rar")]
        [InlineData("test.tar", "application/x-tar")]
        [InlineData("test.dcm", "application/dicom")]
        [InlineData("test.odt", "application/vnd.oasis.opendocument.text")]
        [InlineData("test.ods", "application/vnd.oasis.opendocument.spreadsheet")]
        [InlineData("test.odp", "application/vnd.oasis.opendocument.presentation")]
        [InlineData("test.vsd", "application/vnd.visio")]
        [InlineData("test.vsdx", "application/vnd.visio")]
        [InlineData("test.webp", "image/webp")]
        [InlineData("test.mp4", "video/mp4")]
        [InlineData("test-v1.mp4", "video/mp4")]
        [InlineData("test.m4v", "video/mp4")]
        [InlineData("test.m4a", "audio/mp4")]
        [InlineData("test.flv", "video/x-flv")]
        [InlineData("test.mid", "audio/midi")]
        [InlineData("test.mov", "video/quicktime")]
        [InlineData("test.3gp", "video/3gpp")]
        [InlineData("test.vcf", "text/vcard")]
        [InlineData("test.mp3", "audio/mpeg")]
        [InlineData("test.flac", "audio/flac")]
        [InlineData("test.ogg", "audio/ogg")]
        [InlineData("test.amr", "audio/amr")]
        [InlineData("test.ico", "image/vnd.microsoft.icon")]
        [InlineData("malicious.pdf", "application/vnd.microsoft.portable-executable")]
        [InlineData("test.gz", "application/gzip")]
        [InlineData("test.7z", "application/x-7z-compressed")]
        [InlineData("test.swf", "application/vnd.adobe.flash.movie")]
        [InlineData("test.wmf", "image/wmf")]
        [InlineData("test.psd", "image/vnd.adobe.photoshop")]
        [InlineData("test.xlsb", "vnd.ms-excel.sheet.binary.macroEnabled.12")]
        [InlineData("test.mkv", "video/x-matroska")]
        [InlineData("test.avi", "video/x-msvideo")]
        [InlineData("test.wmv", "video/x-ms-wmv")]
        [InlineData("test.dwg", "image/vnd.dwg")]
        [InlineData("test.aiff", "audio/aiff")]
        [InlineData("test.cab", "application/vnd.ms-cab-compressed")]
        [InlineData("test.mdb", "application/x-msaccess")]
        [InlineData("test.accdb", "application/x-msaccess")]
        [InlineData("test.pst", "application/vnd.ms-outlook-pst")]
        [InlineData("test.chm", "application/vnd.ms-htmlhelp")]
        public void SamplesAreRecognised(string sample, string expected)
        {
            var result = InspectSample(sample);

            Assert.NotNull(result);
            Assert.Equal(expected, result?.MediaType);
        }

        private static FileFormat InspectSample(string fileName)
        {
            var inspector = new FileFormatInspector();
            var buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).GetTypeInfo().Assembly.Location)!;
            var sample = new FileInfo(Path.Combine(buildDirectoryPath, "Samples", fileName));

            using var stream = sample.OpenRead();
            var result = inspector.DetermineFileFormat(stream);

            return result;
        }
    }
}
