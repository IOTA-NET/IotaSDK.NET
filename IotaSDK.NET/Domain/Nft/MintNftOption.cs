namespace IotaSDK.NET.Domain.Nft
{
    public class NftOptions
    {
        /// <summary>
        /// Bech32 encoded address to which the Nft will be minted. Default will use the
        /// first address of the account
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Bech32 encoded sender address
        /// </summary>
        public string? Sender { get; set; }

        /// <summary>
        /// Hex encoded bytes
        /// </summary>
        public string? Metadata { get; set; }

        /// <summary>
        /// Hex encoded bytes
        /// </summary>
        public string? Tag { get; set; }

        /// <summary>
        /// Bech32 encoded issuer address
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// Hex encoded bytes
        /// </summary>
        public string? ImmutableMetadata { get; set; }
    }
}
