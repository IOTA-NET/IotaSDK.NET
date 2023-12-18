namespace IotaSDK.NET.Domain.Nft
{
    public class AddressAndNftId
    {
        public AddressAndNftId(string address, string nftId)
        {
            Address = address;
            NftId = nftId;
        }
        /** The Bech32 address. */
        public string Address { get; }
        /** The ID of the NFT to send. */
        public string NftId { get; }
    }
}
