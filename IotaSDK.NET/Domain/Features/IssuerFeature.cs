using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.Features
{
    /// <summary>
    /// An Issuer feature.
    /// </summary>
    public class IssuerFeature : Feature
    {
        public IssuerFeature(int type, Address address) : base(type)
        {
            Address = address;
        }

        /// <summary>
        /// The Issuer address stored with the feature.
        /// </summary>
        public Address Address { get; }
    }
}
