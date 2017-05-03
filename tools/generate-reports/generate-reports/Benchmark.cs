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
        }

        public string FilePath { get; }

        public string Name
        {
            get
            {
                if (FilePath.Contains("dotnet"))
                    return ".NET Core";

                if (FilePath.Contains("go"))
                    return "Go";

                if (FilePath.Contains("nodejs"))
                    return "NodeJS";

                if (FilePath.Contains("clojure"))
                    return "Clojure";

                throw new Exception("Unsupported technology");
            }
        }

        public static Benchmark[] FindAll(string path)
        {
            return Directory.GetFiles(path, "*.csv", SearchOption.AllDirectories)
                .Select(filePath => new Benchmark(filePath))
                .ToArray();
        }
    }
}
