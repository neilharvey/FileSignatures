using FileSignatures.Formats;
using System;
using System.IO;
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
    }
}
