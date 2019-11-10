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

        public FileFormatInspectorBenchmarks()
        {
            inspector = new FileFormatInspector();
        }

        [ParamsSource(nameof(SampleFiles))]
        public string? File { get; set; }
      
        public static IEnumerable<string> SampleFiles()
        {
            var buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).Assembly.Location);
            var samplesPath = Path.Combine(buildDirectoryPath, "Samples");
            var samplesDirectory = new DirectoryInfo(samplesPath);

            return samplesDirectory
                .GetFiles()
                //.Where(x => x.Length > 10240)
                .Select(x => x.FullName)
                .ToList();
        }

        [Benchmark]
        public FileFormat? DetermineFileFormat()
        {
            // We must open the stream as part of the benchmark because otherwise
            // Windows anti-malware will get rather upset with us.
            using var stream = System.IO.File.OpenRead(File);
            return inspector.DetermineFileFormat(stream);
        }
    }
}
