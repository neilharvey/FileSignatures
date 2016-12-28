using System.Linq;
using System.Reflection;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileTypeTests
    {
        [Fact]
        public void StaticFileTypesCanBeEnumerated()
        {
            var expected = typeof(FileType)
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .OfType<FileType>();

            var result = FileType.GetAll();

            Assert.Equal(expected, result);
        }
    }
}
