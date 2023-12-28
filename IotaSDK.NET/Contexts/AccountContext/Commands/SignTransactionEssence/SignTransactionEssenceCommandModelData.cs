using IotaSDK.NET.Domain.Transactions.Prepared;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SignTransactionEssence
{
    internal class SignTransactionEssenceCommandModelData
    {
        public SignTransactionEssenceCommandModelData(PreparedTransactionData preparedTransactionData)
        {
            PreparedTransactionData = preparedTransactionData;
        }

        public PreparedTransactionData PreparedTransactionData { get; }
    }
}
