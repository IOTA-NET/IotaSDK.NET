using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.Features
{
    /// <summary>
    /// A Sender feature.
    /// </summary>
    public class SenderFeature : Feature
    {
        public SenderFeature(int type, Address address) : base(type)
        {
            Address = address;
        }

        /// <summary>
        /// The Sender address stored with the feature.
        /// </summary>
        public Address Address { get; }
    }
}
