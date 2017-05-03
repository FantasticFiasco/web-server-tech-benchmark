using System;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    class Benchmark
    {
        public Benchmark(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            Name = GetName(FilePath);
        }

        public string FilePath { get; }

        public string Name { get; }

        public void FormatData()
        {
            string tempFilePath = $"{FilePath}.temp";

            using (var reader = new StreamReader(FilePath))
            using (var writer = new StreamWriter(tempFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    writer.WriteLine(line.Replace("Request", Name));
                }
            }

            File.Delete(FilePath);
            File.Move(tempFilePath, FilePath);
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

        public static Benchmark[] FindAll(string path)
        {
            return Directory.GetFiles(path, "*.csv", SearchOption.AllDirectories)
                .Select(filePath => new Benchmark(filePath))
                .ToArray();
        }
    }
}
