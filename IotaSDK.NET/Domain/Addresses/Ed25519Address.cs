namespace IotaSDK.NET.Domain.Addresses
{
    public class Ed25519Address : Address
    {
        public Ed25519Address(string publicKeyHash) : base(type:((int)AddressType.Ed25519))
        {
            PublicKeyHash = publicKeyHash;
        }

        public string PublicKeyHash { get; }
    }
}
