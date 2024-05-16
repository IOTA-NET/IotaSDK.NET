namespace IotaSDK.NET.Domain.Queries
{
    /** Returns outputs that are unlockable by the bech32 address. */
    public class UnlockableByAddressQuery : IGenericQueryParameter, IQueryParameter, IAliasQueryParameter, INftQueryParameter
    {
        public string UnlockableByAddress { get; }

        public UnlockableByAddressQuery(string unlockableByAddress)
        {
            UnlockableByAddress = unlockableByAddress;
        }
    }
}
