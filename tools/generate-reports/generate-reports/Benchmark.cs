using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    /// <summary>
    /// Class describing the result of a benchmark.
    /// </summary>
    class Benchmark : IBenchmark
    {
        public Benchmark(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            TechnologyName = GetName(FilePath);
            Type = GetType(FilePath);
        }

        public string FilePath { get; }

        public string TechnologyName { get; }

        public string Type { get; }

        public static IEnumerable<Benchmark> FindAll(string path)
        {
            return Directory.GetFiles(path, "*.csv", SearchOption.AllDirectories)
                .Select(filePath => new Benchmark(filePath));
        }

        private static string GetName(string filePath)
        {
            if (filePath.Contains("dotnet"))
                return ".NET Core";

            if (filePath.Contains("go"))
                return "Go";

            if (filePath.Contains("nodejs"))
                return "NodeJS";

            if (filePath.Contains("clojure"))
                return "Clojure";
            
            throw new ArgumentException("Unsupported technology", nameof(filePath));
        }

        private static string GetType(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            return Path.GetFileName(directoryPath);
        }
    }
}
