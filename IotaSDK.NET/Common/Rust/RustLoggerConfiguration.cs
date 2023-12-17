using System.Collections.Generic;

namespace IotaSDK.NET.Common.Rust
{
    public class RustLoggerConfiguration
    {
        public RustLoggerConfiguration(string nameOfOutputFile, LogLevelFilter logLevelFilter)
        {
            Name = nameOfOutputFile;
            LevelFilter = logLevelFilter.ToString();
        }

        public RustLoggerConfiguration(LogLevelFilter logLevelFilter)
            : this("stdout", logLevelFilter)
        {

        }
        /// <summary>
        /// Name of an output file, or `stdout` for standard output
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Log level filter of an output.
        /// </summary>
        public string? LevelFilter { get; set; }

        /// <summary>
        ///  Log target filters of an output
        /// </summary>
        public List<string>? TargetFilter { get; set; }

        /// <summary>
        /// Log target exclusions of an output.
        /// </summary>
        public List<string>? TargetExclusions { get; set; }

        /// <summary>
        ///  Color flag of an output.
        /// </summary>
        public bool ColorEnabled { get; set; } = true;
    }

    public enum LogLevelFilter
    {
        off, error, warn, info, debug, trace
    }
}
