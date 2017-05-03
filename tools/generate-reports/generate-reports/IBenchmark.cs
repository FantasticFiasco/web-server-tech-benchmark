namespace GenerateReports
{
    interface IBenchmark
    {
        /// <summary>
        /// Gets the file path.
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// Gets the type ['health', 'echo', 'relay', 'contacts'].
        /// </summary>
        string Type { get; }
    }
}
