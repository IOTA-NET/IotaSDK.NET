using System.Transactions;

namespace IotaSDK.NET.Contexts.AccountContext.Commands.SendBaseCoin
{
    internal class SendBaseCoinCommandModelData
    {
        public SendBaseCoinCommandModelData(ulong amount, string address, TransactionOptions? options = null)
        {
            Amount = amount.ToString();
            Address = address;
            Options = options;
        }

        public string Amount { get; }
        public string Address { get; }
        public TransactionOptions? Options { get; }
    }
}
