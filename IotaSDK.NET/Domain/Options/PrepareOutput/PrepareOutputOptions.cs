namespace IotaSDK.NET.Domain.Options.PrepareOutput
{
    public class PrepareOutputOptions
    {
        public PrepareOutputOptions(
            string recipientAddress, ulong amount,
            PrepareOutputAssetOptions? assets, PrepareOutputFeaturesOptions? features,
            PrepareOutputUnlockOptions? unlocks, PrepareOutputStorageDepositOptions? storageDeposit
        )
        {
            RecipientAddress = recipientAddress;
            Assets = assets;
            Features = features;
            Unlocks = unlocks;
            Amount = amount.ToString();
            StorageDeposit = storageDeposit;
        }

        /// <summary>
        /// A recipient address
        /// </summary>
        public string RecipientAddress { get; }

        /// <summary>
        /// Assets to include
        /// </summary>
        public PrepareOutputAssetOptions? Assets { get; }

        /// <summary>
        /// Features to include
        /// </summary>
        public PrepareOutputFeaturesOptions? Features { get; }

        /// <summary>
        /// Unlocks to include
        /// </summary>
        public PrepareOutputUnlockOptions? Unlocks { get; }

        /// <summary>
        /// The storage deposit strategy to use. 
        /// </summary>
        public PrepareOutputStorageDepositOptions? StorageDeposit { get; set; }

        /// <summary>
        /// An amount
        /// </summary>
        public string Amount { get; }
    }
}
