using BenchmarkDotNet.Running;

namespace FileSignatures.Tests.Benchmarks
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<FileFormatInspectorBenchmarks>();
        }
    }
}
