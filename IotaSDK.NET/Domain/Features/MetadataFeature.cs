namespace IotaSDK.NET.Domain.Features
{
    /// <summary>
    /// A Metadata feature.
    /// </summary>
    public class MetadataFeature : Feature
    {
        public MetadataFeature(int type, string data) : base(type)
        {
            Data = data;
        }

        /// <summary>
        /// The metadata stored with the feature.
        /// </summary>
        public string Data { get; }
    }
}
