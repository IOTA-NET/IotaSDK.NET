using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.Features
{
    /// <summary>
    /// An Issuer feature.
    /// </summary>
    public class IssuerFeature : Feature
    {
        public IssuerFeature(Address address) : base((int)FeatureType.Issuer)
        {
            Address = address;
        }

        /// <summary>
        /// The Issuer address stored with the feature.
        /// </summary>
        public Address Address { get; }
    }
}
