using System;
using System.Diagnostics;
using System.IO;

namespace GenerateReports
{
    class Report
    {
        private readonly BenchmarkComparison benchmark;

        public Report(BenchmarkComparison benchmark)
        {
            this.benchmark = benchmark ?? throw new ArgumentNullException(nameof(benchmark));
        }

        public void Generate()
        {
            string outputPath = Path.Combine(
                Path.GetDirectoryName(benchmark.FilePath),
                $"{benchmark.Type}-report");

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
                .Start("jmeter.bat", $"-g \"{benchmark.FilePath}\" -o \"{outputPath}\"")
                .WaitForExit();
        }
    }
}
