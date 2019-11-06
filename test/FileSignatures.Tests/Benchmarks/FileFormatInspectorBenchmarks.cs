using BenchmarkDotNet.Attributes;
using System;
using System.IO;

namespace FileSignatures.Tests.Benchmarks
{
    [MemoryDiagnoser]
    public class FileFormatInspectorBenchmarks
    {
        private readonly FileFormatInspector inspector;
        private readonly FileInfo ooxFile; // 8kb
        private readonly FileInfo cfbFile; // 25kb
        private readonly FileInfo pdfFile; // 138kb

        public FileFormatInspectorBenchmarks()
        {
            inspector = new FileFormatInspector();
            ooxFile = GetFileInfo("test.xlsx");
            pdfFile = GetFileInfo("test.pdf");
            cfbFile = GetFileInfo("test.xls");
        }

        private static FileInfo GetFileInfo(string fileName)
        {
            var buildDirectoryPath = Path.GetDirectoryName(typeof(FunctionalTests).Assembly.Location);
            return new FileInfo(Path.Combine(buildDirectoryPath, "Samples", fileName));
        }

        [Benchmark]
        public FileFormat Pdf() => DetermineFileFormat(pdfFile);

        [Benchmark]
        public FileFormat Cfb() => DetermineFileFormat(cfbFile);

        [Benchmark]
        public FileFormat Oox() => DetermineFileFormat(ooxFile);

        public FileFormat DetermineFileFormat(FileInfo file)
        {
            using(var stream = file.OpenRead())
            {
                return inspector.DetermineFileFormat(stream);
            }
        }
    }
}
