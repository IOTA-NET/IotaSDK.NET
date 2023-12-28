using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyAlias
{
    internal class PrepareDestroyAliasCommandModelData
    {
        public PrepareDestroyAliasCommandModelData(PrepareDestroyAliasCommandInnerModelData burn, TransactionOptions? options)
        {
            Burn = burn;
            Options = options;
        }

        public PrepareDestroyAliasCommandInnerModelData Burn { get; }
        public TransactionOptions? Options { get; }
    }
}
