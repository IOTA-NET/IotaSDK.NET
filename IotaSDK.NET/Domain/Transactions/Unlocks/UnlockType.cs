namespace IotaSDK.NET.Domain.Transactions.Unlocks
{
    /**
     * All of the unlock types.
     */
    public enum UnlockType
    {
        /**
         * A signature unlock.
         */
        Signature = 0,
        /**
         * A reference unlock.
         */
        Reference = 1,
        /**
         * An Alias unlock.
         */
        Alias = 2,
        /**
         * An NFT unlock.
         */
        Nft = 3,
    }
}
