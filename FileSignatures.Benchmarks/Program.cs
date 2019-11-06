using BenchmarkDotNet.Running;
using System;

namespace FileSignatures.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FileFormatInspectorBenchmarks>();
        }
    }
}
