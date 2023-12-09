namespace IotaSDK.NET.Domain.Transactions.Unlocks
{
    public class AliasUnlock : Unlock
    {
        public AliasUnlock(int reference) : base((int)UnlockType.Alias)
        {
            Reference = reference;
        }

        /// <summary>
        /// An index referencing a previous unlock.
        /// </summary>
        public int Reference { get; }
    }
}
