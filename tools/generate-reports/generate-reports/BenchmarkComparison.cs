using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;

namespace GenerateReports
{
    /// <summary>
    /// Class capable of prodicing a comparison of multiple benchmarks, i.e. producing a new
    /// benchmark by merging them together.
    /// </summary>
    public class BenchmarkComparison
    {
        private BenchmarkComparison(string type, string filePath)
        {
            Type = type;
            FilePath = filePath;
        }

        public string Type { get; }

        public string FilePath { get; }

        public static BenchmarkComparison Generate(IEnumerable<Benchmark> benchmarks, string type, string filePath)
        {
            Clean(filePath);
            Generate(benchmarks.ToArray(), filePath);

            return new BenchmarkComparison(type, filePath);
        }

        private static void Clean(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private static void Generate(Benchmark[] benchmarks, string filePath)
        {
            var headerColumns = ParseHeader(benchmarks.First());
            
            using (var writer = new StreamWriter(filePath))
            {
                // Write header
                string header = string.Join(",", headerColumns.Select(headerColumn => headerColumn.Name));
                writer.WriteLine(header);
                
                for (int i = 0; i < benchmarks.Length; i++)
                {
                    var benchmark = benchmarks[i];

                    using (var reader = new StreamReader(benchmark.FilePath))
                    {
                        // Skip the header
                        reader.ReadLine();

                        long? offset = null;

                        while (!reader.EndOfStream)
                        {
                            string[] values = reader.ReadLine().Split(',');

                            // Timestamp
                            int index = headerColumns.Single(headerColumn => headerColumn.Name == "timeStamp").Index;
                            if (offset == null)
                            {
                                offset = long.Parse(values[index]) - 946681200000;
                            }
                            // Timestamp should be relative to the first sample
                            values[index] = (long.Parse(values[index]) - offset).ToString();
                            
                            // Label
                            index = headerColumns.Single(headerColumn => headerColumn.Name == "label").Index;
                            values[index] = values[index]
                                .Replace("Request", benchmark.TechnologyName)
                                .Replace("Create", benchmark.TechnologyName)
                                .Replace("Get", benchmark.TechnologyName)
                                .Replace("Delete", benchmark.TechnologyName);

                            writer.WriteLine(string.Join(",", values));
                        }
                    }
                }
            }
        }

        private static HeaderColumn[] ParseHeader(Benchmark benchmark)
        {
            using (var reader = new StreamReader(benchmark.FilePath))
            {
                // First line is the header
                var header = reader.ReadLine();

                return header
                    .Split(',')
                    .Select((columnName, index) => new HeaderColumn
                        {
                            Index = index,
                            Name = columnName
                        })
                    .ToArray();
            }  
        }

        private class HeaderColumn
        {
            public int Index { get; set; }

            public string Name { get; set; }
        }
    }
}
