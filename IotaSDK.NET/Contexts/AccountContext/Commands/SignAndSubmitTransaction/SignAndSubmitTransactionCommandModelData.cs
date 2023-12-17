using IotaSDK.NET.Domain.Transactions.Prepared;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignAndSubmitTransaction
{
    internal class SignAndSubmitTransactionCommandModelData
    {
        public SignAndSubmitTransactionCommandModelData(PreparedTransactionData preparedTransactionData)
        {
            PreparedTransactionData = preparedTransactionData;
        }

        public PreparedTransactionData PreparedTransactionData { get; }
    }
}
