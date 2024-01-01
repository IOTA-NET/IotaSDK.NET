using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareDestroyFoundry
{
    internal class PrepareDestroyFoundryCommandModelData
    {
        public PrepareDestroyFoundryCommandModelData(PrepareDestroyFoundryCommandInnerModelData burn, TransactionOptions? options=null)
        {
            Burn = burn;
            Options = options;
        }

        public PrepareDestroyFoundryCommandInnerModelData Burn { get; }
        public TransactionOptions? Options { get; }
    }
}
