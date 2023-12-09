namespace IotaSDK.NET.Domain.Transactions.Strategy
{
    public class CustomAddressStrategy : RemainderValueStrategy
    {
        public CustomAddressStrategy() : base(strategy: "CustomAddress")
        {
        }
    }

}