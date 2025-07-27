using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace FileSignatures.Tests
{
    public class FileFormatLocatorTests
    {
        [Fact]
        public void LocatesConcreteFormatsInAssembly()
        {
            var expected = typeof(FileFormat)
                 .GetTypeInfo()
                 .Assembly
                 .GetTypes()
                 .Where(t => typeof(FileFormat).IsAssignableFrom(t))
                 .Where(t => !t.GetTypeInfo().IsAbstract)
                 .Where(t => t.GetConstructors().Any(c => c.GetParameters().Count() == 0))
                 .Select(t => Activator.CreateInstance(t))
                 .OfType<FileFormat>()
                 .ToArray();

            var result = FileFormatLocator.GetFormats().ToArray();

            Assert.Equal(expected.Length, result.Length);

            var expectedGroup = expected
                .GroupBy(f => f)
                .ToDictionary(f => f.Key, f => f.Count());
            var resultGroup = result
                .GroupBy(f => f)
                .ToDictionary(f => f.Key, f => f.Count());

            Assert.Equal(expectedGroup.Count, resultGroup.Count);
            Assert.True(expectedGroup.All(kv => resultGroup.TryGetValue(kv.Key, out int count) && count == kv.Value));
        }
    }
}
