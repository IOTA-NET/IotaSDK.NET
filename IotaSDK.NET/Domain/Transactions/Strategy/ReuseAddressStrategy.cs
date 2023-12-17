namespace IotaSDK.NET.Domain.Transactions.Strategy
{
    public class ReuseAddressStrategy : RemainderValueStrategy
    {
        public ReuseAddressStrategy() : base(strategy: "ReuseAddress")
        {
        }
    }

}