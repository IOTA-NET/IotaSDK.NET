using IotaSDK.NET.Domain.Addresses;

namespace IotaSDK.NET.Domain.Transactions.Strategy
{

    public abstract class RemainderValueStrategy
    {
        public RemainderValueStrategy(string strategy)
        {
            Strategy = strategy;
        }

        public AccountAddress? Value { get; set; }
        public string Strategy { get; }
    }

}