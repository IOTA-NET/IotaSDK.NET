namespace IotaSDK.NET.Domain.Accounts
{
    /// <summary>
    /// Specifies what outputs should be synced for the ed25519 addresses from the account.
    /// </summary>
    public class AccountSyncOptions
    {
        /// <summary>
        /// Whether to sync Basic outputs.
        /// </summary>
        public bool? BasicOutputs { get; set; }

        /// <summary>
        /// Whether to sync Alias outputs.
        /// </summary>
        public bool? AliasOutputs { get; set; }

        /// <summary>
        /// Whether to sync Nft outputs.
        /// </summary>
        public bool? NftOutputs { get; set; }



    }
}
