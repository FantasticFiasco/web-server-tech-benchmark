using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    class TypedBenchmark : IBenchmark
    {
        private readonly IEnumerable<Benchmark> benchmarks;

        public TypedBenchmark(string filePath, string type, IEnumerable<Benchmark> benchmarks)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            this.benchmarks = benchmarks ?? throw new ArgumentNullException(nameof(benchmarks));
        }

        public string FilePath { get; }

        public string Type { get; }

        public void Merge()
        {
            using (var writer = new StreamWriter(FilePath))
            {
                for (int i = 0; i < benchmarks.Count(); i++)
                {
                    var benchmark = benchmarks.ElementAt(i);

                    using (var reader = new StreamReader(benchmark.FilePath))
                    {
                        if (i != 0)
                        {
                            // Skip writing headers multiple times
                            reader.ReadLine();
                        }

                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine()
                                .Replace("Request", benchmark.TechnologyName)
                                .Replace("Create", $"Create [{benchmark.TechnologyName}]")
                                .Replace("Get", $"Get [{benchmark.TechnologyName}]")
                                .Replace("Delete", $"Delete [{benchmark.TechnologyName}]");
                            
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
