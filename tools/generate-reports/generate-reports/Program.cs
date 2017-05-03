using System;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    class Program
    {
        static void Main()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            ILookup<string, Benchmark> benchmarksByType = Benchmark.FindAll(currentDirectory)
                .ToLookup(benchmark => benchmark.Type);

            foreach (var benchmarks in benchmarksByType)
            {
                string type = benchmarks.Key;

                Console.WriteLine($"Merging benchmarks for {type}...");
                var typedBenchmark = new TypedBenchmark(Path.Combine(currentDirectory, type), type, benchmarks);
                typedBenchmark.Merge();

                Console.WriteLine($"Generating report for {type}...");
                var report = new Report(typedBenchmark);
                report.Generate();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
