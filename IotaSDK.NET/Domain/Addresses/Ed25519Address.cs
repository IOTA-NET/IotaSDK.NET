namespace IotaSDK.NET.Domain.Addresses
{
    public class Ed25519Address : Address
    {
        public Ed25519Address(string pubKeyHash) : base(type: (int)AddressType.Ed25519)
        {
            PubKeyHash = pubKeyHash;
        }

        public string PubKeyHash { get; }
    }
}
