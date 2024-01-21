using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendBaseCoinWithStorageDeposit
{
    internal class PrepareSendBaseCoinToAddressesCommandModelData
    {
        public PrepareSendBaseCoinToAddressesCommandModelData(List<SendBaseCoinToAddressOptions> @params, TransactionOptions? options = null)
        {
            Params = @params;
            Options = options;
        }

        public List<SendBaseCoinToAddressOptions> Params { get; }
        public TransactionOptions? Options { get; }
    }
}
