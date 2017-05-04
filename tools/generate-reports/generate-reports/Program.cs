using System;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    class Program
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        static void Main()
        {
            ILookup<string, Benchmark> benchmarksByType = Benchmark.FindAll(CurrentDirectory)
                .ToLookup(benchmark => benchmark.Type);

            foreach (var benchmarks in benchmarksByType)
            {
                string type = benchmarks.Key;

                Console.WriteLine($"Generate comparison for benchmarks of type {type}...");
                var fileName = Path.Combine(CurrentDirectory, $"{type}.csv");
                var comparison = BenchmarkComparison.Generate(benchmarks, type, fileName);

                Console.WriteLine($"Generating report for benchmarks of type {type}...");
                Report.Generate(comparison);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
