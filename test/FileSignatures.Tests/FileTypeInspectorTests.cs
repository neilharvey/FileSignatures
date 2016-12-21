using System.IO;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileTypeInspectorTests
    {
        FileTypeInspector inspector;

        public FileTypeInspectorTests()
        {
             inspector = new FileTypeInspector();
        }

        [Fact]
        public void UnrecognisedFileTypeReturnsNull()
        {
            using (var stream = OpenSample("unknown"))
            {
                Assert.Null(inspector.DetermineFileType(stream));
            }
        }

        [Fact]
        public void JpgIsRecognised()
        {
            using (var stream = OpenSample("jpg.jpg"))
            {
                Assert.Equal(FileType.Jpeg, inspector.DetermineFileType(stream));
            }
        }

        private static FileStream OpenSample(string fileName)
        {
            var sample = new FileInfo(Path.Combine("Samples", fileName));
            var stream = sample.OpenRead();
            return stream;
        }
    }
}
