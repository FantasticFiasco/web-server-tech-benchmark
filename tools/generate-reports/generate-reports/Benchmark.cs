using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    /// <summary>
    /// Class describing the results of a specific benchmark type
    /// ['health', 'echo', 'relay', 'contacts'] tested with a specific technology.
    /// </summary>
    public class Benchmark
    {
        private Benchmark(string filePath)
        {
            FilePath = filePath;
            TechnologyName = ParseTechnologyName(filePath);
            Type = ParseType(filePath);
        }

        public string FilePath { get; }

        public string TechnologyName { get; }

        public string Type { get; }

        public static IEnumerable<Benchmark> FindAll(string path)
        {
            return Directory.GetFiles(path, "*.csv", SearchOption.AllDirectories)
                .Select(filePath => new Benchmark(filePath));
        }

        private static string ParseTechnologyName(string filePath)
        {
            if (filePath.Contains("dotnet"))
                return ".NET Core";

            if (filePath.Contains("go"))
                return "Go";

            if (filePath.Contains("nodejs"))
                return "NodeJS";

            if (filePath.Contains("clojure"))
                return "Clojure";
            
            throw new ArgumentException($"The file path '{filePath}' is describing an unsupported technology");
        }

        private static string ParseType(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            return Path.GetFileName(directoryPath);
        }
    }
}
