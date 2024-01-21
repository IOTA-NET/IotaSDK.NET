namespace IotaSDK.NET.Domain.Events
{
    public enum TransactionProgressType
    {
        SelectingInputs = 0,
        GeneratingRemainderDepositAddress = 1,
        PreparedTransaction = 2,
        PreparedTransactionEssenceHash = 3,
        SigningTransaction = 4,
        PerformingPow = 5,
        Broadcasting = 6,
    }

}
