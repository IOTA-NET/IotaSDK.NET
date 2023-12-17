using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNft
{
    internal class PrepareBurnNftCommandModelData
    {
        public PrepareBurnNftCommandModelData(PrepareBurnNftCommandModelDataBurn burn, TransactionOptions? options)
        {
            Burn = burn;
            Options = options;
        }

        public PrepareBurnNftCommandModelDataBurn Burn { get; }
        public TransactionOptions? Options { get; }
    }
}
