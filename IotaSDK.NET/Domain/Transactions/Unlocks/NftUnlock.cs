namespace IotaSDK.NET.Domain.Transactions.Unlocks
{
    public class NftUnlock : Unlock
    {
        public NftUnlock(int reference) : base((int)UnlockType.Nft)
        {
            Reference = reference;
        }

        /// <summary>
        /// An index referencing a previous unlock.
        /// </summary>
        public int Reference { get; }
    }
}
