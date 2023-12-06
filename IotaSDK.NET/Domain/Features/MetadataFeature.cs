namespace IotaSDK.NET.Domain.Features
{
    /// <summary>
    /// A Metadata feature.
    /// </summary>
    public class MetadataFeature : Feature
    {
        public MetadataFeature(string data) : base((int)FeatureType.Metadata)
        {
            Data = data;
        }

        /// <summary>
        /// The metadata stored with the feature.
        /// </summary>
        public string Data { get; }
    }
}
