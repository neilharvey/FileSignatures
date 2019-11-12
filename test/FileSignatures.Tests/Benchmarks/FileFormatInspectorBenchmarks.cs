using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSignatures.Tests.Benchmarks
{
    [MemoryDiagnoser]
    public class FileFormatInspectorBenchmarks
    {
        private readonly FileFormatInspector inspector;
        private static readonly string buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).Assembly.Location);
        private static readonly string samplesPath = Path.Combine(buildDirectoryPath, "Samples");

        public FileFormatInspectorBenchmarks()
        {
            inspector = new FileFormatInspector();
        }

        [ParamsSource(nameof(SampleFiles))]
        public string? FileName { get; set; }
      
        public static IEnumerable<string> SampleFiles()
        {
            var samplesDirectory = new DirectoryInfo(samplesPath);

            return samplesDirectory
                .GetFiles()
                //.Where(x => x.Length > 102400)
                .Select(x => x.Name)
                .ToList();
        }

        [Benchmark]
        public FileFormat? DetermineFileFormat()
        {
            // We must open the stream as part of the benchmark because otherwise
            // Windows anti-malware will get rather upset with us.
            using var stream = System.IO.File.OpenRead(Path.Combine(samplesPath, FileName));
            return inspector.DetermineFileFormat(stream);
        }
    }
}
