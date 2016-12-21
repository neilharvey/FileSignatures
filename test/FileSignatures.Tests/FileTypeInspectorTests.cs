using System.IO;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileTypeInspectorTests
    {
        [Fact]
        public void UnrecognisedFileTypeReturnsNull()
        {
            var inspector = new FileTypeInspector();
            using (var stream = OpenSample("unknown"))
            {
                Assert.Null(inspector.DetermineFileType(stream));
            }
        }

        private static FileStream OpenSample(string fileName)
        {
            var sample = new FileInfo($"Samples\\{fileName}");
            var stream = sample.OpenRead();
            return stream;
        }
    }
}
