using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurn
{
    internal class PrepareBurnCommandModelData
    {
        public PrepareBurnCommandModelData(BurnIds burn, TransactionOptions? options)
        {
            Burn = burn;
            Options = options;
        }

        public BurnIds Burn { get; }
        public TransactionOptions? Options { get; }
    }
}
