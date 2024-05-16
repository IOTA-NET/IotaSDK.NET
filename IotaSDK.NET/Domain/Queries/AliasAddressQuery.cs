using IotaSDK.NET.Domain.Queries;

namespace IotaSDK.NET.Domain.Query
{
    /// <summary>
    /// Filter foundry outputs based on bech32-encoded address of the controlling alias.
    /// </summary>
    public class AliasAddressQuery : IQueryParameter, IFoundryQueryParameter
    {
        public AliasAddressQuery(string aliasAddress)
        {
            AliasAddress = aliasAddress;
        }

        public string AliasAddress { get; }
    }

}
