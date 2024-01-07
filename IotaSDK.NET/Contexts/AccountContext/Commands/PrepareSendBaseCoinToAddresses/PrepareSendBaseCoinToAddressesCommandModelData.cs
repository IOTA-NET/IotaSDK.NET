using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendBaseCoinWithStorageDeposit
{
    internal class PrepareSendBaseCoinToAddressesCommandModelData
    {
        public PrepareSendBaseCoinToAddressesCommandModelData(SendBaseCoinToAddressOptions @params, TransactionOptions? transactionOptions = null)
        {
            Params = @params;
            TransactionOptions = transactionOptions;
        }

        public SendBaseCoinToAddressOptions Params { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
