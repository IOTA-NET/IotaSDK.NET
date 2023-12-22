using IotaSDK.NET.Domain.Options;
using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareCreateAliasOutput
{
    internal class PrepareCreateAliasOutputCommandModelData
    {
        public PrepareCreateAliasOutputCommandModelData(AliasOutputCreationOptions? @params, TransactionOptions? options)
        {
            Params = @params;
            Options = options;
        }

        public AliasOutputCreationOptions? Params { get; }
        public TransactionOptions? Options { get; }
    }
}
