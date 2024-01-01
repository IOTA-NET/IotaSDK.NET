using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;
using System.Collections.Generic;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareSendNativeTokens
{
    internal class PrepareSendNativeTokensCommandModelData
    {
        public PrepareSendNativeTokensCommandModelData(List<SendNativeTokensOptions> @params, TransactionOptions? options = null)
        {
            Params = @params;
            Options = options;
        }

        public List<SendNativeTokensOptions> Params { get; }
        public TransactionOptions? Options { get; }
    }
}
