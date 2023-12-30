namespace IotaSDK.NET.Domain.Options.PrepareOutput
{
    /// <summary>
    /// Features to include in the output
    /// </summary>
    public class PrepareOutputFeaturesOptions
    {
        public PrepareOutputFeaturesOptions(string? tag, string? metadata, string? sender, string? issuer)
        {
            Tag = tag;
            Metadata = metadata;
            Sender = sender;
            Issuer = issuer;
        }

        /// <summary>
        /// A Tag feature to include
        /// </summary>
        public string? Tag { get; }

        /// <summary>
        /// A Metadata feature to include
        /// </summary>
        public string? Metadata { get; }

        /// <summary>
        /// A Sender feature to include
        /// </summary>
        public string? Sender { get; }

        /// <summary>
        /// An Issuer feature to include
        /// </summary>
        public string? Issuer { get; }
    }
}
