namespace IotaSDK.NET.Domain.Transactions.Unlocks
{
    /// <summary>
    /// An unlock which must reference a previous unlock which unlocks
    /// also the input at the same index as this Reference Unlock.
    /// </summary>
    public class ReferenceUnlock : Unlock
    {
        public ReferenceUnlock(int reference) : base((int)UnlockType.Reference)
        {
            Reference = reference;
        }

        /// <summary>
        /// An index referencing a previous unlock.
        /// </summary>
        public int Reference { get; }
    }
}
