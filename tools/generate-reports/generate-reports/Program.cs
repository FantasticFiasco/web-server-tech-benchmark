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

            IEnumerable<Report> reports = Benchmark.FindAll(currentDirectory)
                .Select(benchmark => new Report(benchmark));

            foreach (Report report in reports)
            {
                Console.WriteLine($"Generate report for {report.Benchmark.Name}...");

                report.Generate();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
