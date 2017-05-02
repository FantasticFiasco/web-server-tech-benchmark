using System;
using System.Diagnostics;
using System.IO;

namespace GenerateReports
{
    class Program
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        static void Main()
        {
            string[] benchmarks = FindBenchmarks();

            CleanReports(benchmarks);
            GenerateReports(benchmarks);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static string[] FindBenchmarks()
        {
            Console.WriteLine();
            Console.WriteLine("-- SCAN DIRECTORY STRUCTURE --");

            string[] benchmarks = Directory.GetFiles(CurrentDirectory, "*.csv", SearchOption.AllDirectories);

            foreach (var benchmark in benchmarks)
            {
                Console.WriteLine($"  {ToRelativePath(benchmark)}");
            }

            return benchmarks;
        }

        private static void CleanReports(string[] benchmarks)
        {
            Console.WriteLine();
            Console.WriteLine("-- CLEAN REPORTS --");

            for (var i = 0; i < benchmarks.Length; i++)
            {
                Console.WriteLine($"  {i + 1}/{benchmarks.Length} {ToRelativePath(benchmarks[i])}");

                string reportDirectory = ToReportDirectoryPath(benchmarks[i]);

                if (Directory.Exists(reportDirectory))
                {
                    Directory.Delete(reportDirectory, true);
                }
                
            }
        }

        private static void GenerateReports(string[] benchmarks)
        {
            Console.WriteLine();
            Console.WriteLine("-- GENERATE REPORTS --");

            for (var i = 0; i < benchmarks.Length; i++)
            {
                Console.WriteLine($"  {i + 1}/{benchmarks.Length} {ToRelativePath(benchmarks[i])}");

                Process
                    .Start("jmeter.bat", $"-g \"{benchmarks[i]}\" -o \"{ToReportDirectoryPath(benchmarks[i])}\"")
                    .WaitForExit();
            }
        }

        private static string ToReportDirectoryPath(string benchmarkFilePath)
        {
            string directory = Path.GetDirectoryName(benchmarkFilePath);
            return Path.Combine(directory, "report");
        }

        private static string ToRelativePath(string absolutePath)
        {
            return absolutePath
                .Replace(CurrentDirectory, string.Empty)
                .Insert(0, ".");
        }
    }
}
