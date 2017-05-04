using System.Diagnostics;
using System.IO;

namespace GenerateReports
{
    /// <summary>
    /// Class responsible for generating a report based on a benchmark comparison.
    /// </summary>
    public static class Report
    {
        public static void Generate(BenchmarkComparison comparison)
        {
            string outputPath = Path.Combine(
                Path.GetDirectoryName(comparison.FilePath),
                $"report-{comparison.Type}");

            Clean(outputPath);
            Generate(comparison, outputPath);
        }

        private static void Clean(string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
        }

        private static void Generate(BenchmarkComparison comparison, string outputPath)
        {
            Process
                .Start("jmeter.bat", $"-g \"{comparison.FilePath}\" -o \"{outputPath}\"")
                .WaitForExit();
        }
    }
}
