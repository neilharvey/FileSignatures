using FileSignatures.Formats;
using System.IO;
using System.IO.Compression;
using Xunit;

namespace FileSignatures.Tests.Formats
{
    public class OfficeOpenXmlTests
    {
        [Fact]
        public void InvalidZipArchiveDoesNotThrow()
        {
            var inspector = new FileFormatInspector();

            using var stream = new MemoryStream(new byte[] { 0x50, 0x4B, 0x03, 0x04 });
            var format = inspector.DetermineFileFormat(stream);

            Assert.NotNull(format);
            Assert.IsType<Zip>(format);
        }

        [Fact]
        public void IdentifierWithoutExtensionDoesNotThrow()
        {
            var format = new TestOfficeOpenXml("test", macroEnabled: false, "example/test", "test");

            using var stream = new MemoryStream();
            using(var createArchive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                createArchive.CreateEntry("test");
            }

            using var archive = new ZipArchive(stream, ZipArchiveMode.Read);

            var result = format.IsMatch(archive);

            Assert.True(result);
        }

        private class TestOfficeOpenXml : OfficeOpenXml
        {
            public TestOfficeOpenXml(string identifiableEntry, bool macroEnabled, string mediaType, string extension) : base(identifiableEntry, macroEnabled, mediaType, extension)
            {
            }
        }
    }
}
