using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeTokens
{
    internal class PrepareCreateNativeTokensCommandModelData
    {
        public PrepareCreateNativeTokensCommandModelData(NativeTokenCreationOptions @params, TransactionOptions? options)
        {
            Params = @params;
            Options = options;
        }

        public NativeTokenCreationOptions Params { get; }
        public TransactionOptions? Options { get; }
    }
}
