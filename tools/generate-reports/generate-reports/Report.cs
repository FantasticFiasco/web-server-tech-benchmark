using System;
using System.Diagnostics;
using System.IO;

namespace GenerateReports
{
    class Report
    {
        public Report(Benchmark benchmark)
        {
            Benchmark = benchmark ?? throw new ArgumentNullException(nameof(benchmark));
        }

        public Benchmark Benchmark { get; }

        public void Generate()
        {
            string outputPath = Path.Combine(
                Path.GetDirectoryName(Benchmark.FilePath),
                "report");

            Clean(outputPath);
            Generate(outputPath);
        }

        private static void Clean(string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
        }

        private void Generate(string outputPath)
        {
            Process
                .Start("jmeter.bat", $"-g \"{Benchmark.FilePath}\" -o \"{outputPath}\"")
                .WaitForExit();
        }
    }
}
