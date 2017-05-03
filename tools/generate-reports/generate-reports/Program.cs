using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    class Program
    {
        static void Main()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            IEnumerable<Benchmark> benchmarks = Benchmark.FindAll(currentDirectory);

            foreach (Benchmark benchmark in benchmarks)
            {
                Console.WriteLine($"Formatting data for {benchmark.Name}...");
                benchmark.FormatData();

                Console.WriteLine($"Generating report for {benchmark.Name}...");
                var report = new Report(benchmark);
                report.Generate();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
