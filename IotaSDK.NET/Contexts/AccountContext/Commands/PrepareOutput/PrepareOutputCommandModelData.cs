using IotaSDK.NET.Domain.Options.PrepareOutput;
using IotaSDK.NET.Domain.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.PrepareOutput
{
    internal class PrepareOutputCommandModelData
    {
        public PrepareOutputCommandModelData(PrepareOutputOptions @params, TransactionOptions? transactionOptions = null)
        {
            Params = @params;
            TransactionOptions = transactionOptions;
        }

        public PrepareOutputOptions Params { get; }
        public TransactionOptions? TransactionOptions { get; }
    }
}
