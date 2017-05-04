using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenerateReports
{
    /// <summary>
    /// Class capable of prodicing a comparison of multiple benchmarks, i.e. producing a new
    /// benchmark by merging them together.
    /// </summary>
    public class BenchmarkComparison
    {
        private readonly IEnumerable<Benchmark> benchmarks;

        public BenchmarkComparison(IEnumerable<Benchmark> benchmarks, string type, string filePath)
        {
            this.benchmarks = benchmarks ?? throw new ArgumentNullException(nameof(benchmarks));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public string Type { get; }

        public string FilePath { get; }
        
        public void CreateComparison()
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
