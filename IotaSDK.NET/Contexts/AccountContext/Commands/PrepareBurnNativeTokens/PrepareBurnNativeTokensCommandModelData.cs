using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareBurnNativeTokens
{
    internal class PrepareBurnNativeTokensCommandModelData
    {
        public PrepareBurnNativeTokensCommandModelData(PrepareBurnNativeTokensCommandInnerModelData burn, TransactionOptions? options=null)
        {
            Burn = burn;
            Options = options;
        }

        public PrepareBurnNativeTokensCommandInnerModelData Burn { get; }
        public TransactionOptions? Options { get; }
    }
}
