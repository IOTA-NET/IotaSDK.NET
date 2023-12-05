namespace IotaSDK.NET.Domain.Addresses
{
    /**
     * Address type variants.
     */
    public enum AddressType
    {
        /** An Ed25519 address. */
        Ed25519 = 0,
        /** An Alias address. */
        Alias = 8,
        /** An NFT address. */
        Nft = 16,
    }
}
