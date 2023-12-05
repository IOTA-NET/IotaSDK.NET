namespace IotaSDK.NET.Domain.Addresses
{
    public class AliasAddress : Address
    {
        public AliasAddress(string aliasId) : base(type: (int)AddressType.Alias)
        {
            AliasId = aliasId;
        }

        public string AliasId { get; }
    }
}
