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
                 .OfType<FileFormat>();

            var result = FileFormatLocator.GetFormats();

           Assert.Equal(expected, result);
        }
    }
}
