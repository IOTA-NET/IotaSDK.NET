using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoinToAddresses
{
    internal class SendBaseCoinToAddressesCommandModelData
    {
        public SendBaseCoinToAddressesCommandModelData(SendBaseCoinToAddressOptions @params, TransactionOptions? transactionOptions=null)
        {
            Params = @params;
            TransactionOptions = transactionOptions;
        }

        public SendBaseCoinToAddressOptions Params { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
