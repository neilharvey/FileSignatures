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
            var expected = typeof(FileFormat)
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .OfType<FileFormat>();

            var result = FileFormat.GetAll();

            Assert.Equal(expected, result);
        }
    }
}
