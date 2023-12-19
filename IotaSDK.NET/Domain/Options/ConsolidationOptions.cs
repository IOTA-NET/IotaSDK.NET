namespace IotaSDK.NET.Domain.Options
{
    internal class ConsolidationOptions
    {
        public ConsolidationOptions(bool force)
        {
            Force = force;
        }

        /// <summary>
        ///  Ignores the output threshold if set to `true`.
        /// </summary>
        public bool Force { get; }

        /// <summary>
        /// Consolidates if the output number is >= the output_threshold.
        /// </summary>
        public int? OutputThreshold { get; set; }

        /// <summary>
        /// Address to which the consolidated output should be sent.
        /// </summary>
        public string? TargetAddress { get; set; }
    }
}
