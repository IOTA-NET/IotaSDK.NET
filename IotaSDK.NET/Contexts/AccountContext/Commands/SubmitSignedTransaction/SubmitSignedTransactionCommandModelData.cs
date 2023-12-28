using IotaSDK.NET.Domain.Signatures;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SubmitSignedTransaction
{
    internal class SubmitSignedTransactionCommandModelData
    {
        public SubmitSignedTransactionCommandModelData(SignedTransactionEssence signedTransactionData)
        {
            SignedTransactionData = signedTransactionData;
        }

        public SignedTransactionEssence SignedTransactionData { get; }
    }
}
