using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSignatures.Tests.Benchmarks
{
    [MemoryDiagnoser]
    public class FileFormatInspectorBenchmarks
    {
        private readonly FileFormatInspector _inspector;
        private static readonly string SamplesPath;

        static FileFormatInspectorBenchmarks()
        {
#nullable disable warnings
            var buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).Assembly.Location);
            SamplesPath = Path.Combine(buildDirectoryPath ?? string.Empty, "Samples");
#nullable enable warnings
        }

        public FileFormatInspectorBenchmarks()
        {
            _inspector = new FileFormatInspector();
        }

        [ParamsSource(nameof(SampleFiles))]
        private string? FileName { get; set; }

        public static IEnumerable<string> SampleFiles()
        {
            var samplesDirectory = new DirectoryInfo(SamplesPath);

            return samplesDirectory
                .GetFiles()
                .Select(x => x.Name)
                .ToList();
        }

        [Benchmark]
        public FileFormat? DetermineFileFormat()
        {
            // We must open the stream as part of the benchmark because otherwise
            // Windows anti-malware will get rather upset with us.
            using var stream = File.OpenRead(Path.Combine(SamplesPath, FileName ?? string.Empty));
            return _inspector.DetermineFileFormat(stream);
        }
    }
}
