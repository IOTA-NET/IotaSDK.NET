namespace IotaSDK.NET.Domain.Addresses
{
    public class NftAddress : Address
    {
        public NftAddress(string nftId) : base(type: (int)AddressType.Nft)
        {
            NftId = nftId;
        }

        public string NftId { get; }
    }
}
