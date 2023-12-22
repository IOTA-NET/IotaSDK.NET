using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateNativeToken
{
    internal class PrepareCreateNativeTokenCommandModelData
    {
        public PrepareCreateNativeTokenCommandModelData(NativeTokenCreationOptions @params, TransactionOptions? options)
        {
            Params = @params;
            Options = options;
        }

        public NativeTokenCreationOptions Params { get; }
        public TransactionOptions? Options { get; }
    }
}
