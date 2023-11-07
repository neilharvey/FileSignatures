using System.IO;
using System.Reflection;
using Xunit;

namespace FileSignatures.Tests
{
    public class JpegTests
    {
        [Fact]
        public void Issue63SampleIsRecognised()
        {
            // Arrange
            var fileName = "281032075-00c46366-a49b-44d6-a615-5a2ea3f5819f.jpg";
            var inspector = new FileFormatInspector();
            var buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).GetTypeInfo().Assembly.Location);
            var sample = new FileInfo(Path.Combine(buildDirectoryPath, "Samples", fileName));

            // Act 
            FileFormat result;

            using (var stream = sample.OpenRead())
            {
                result = inspector.DetermineFileFormat(stream);
            }

            // Assert
            Assert.NotNull(result);
            Assert.Equal("image/jpeg", result?.MediaType);
        }
    }
}
