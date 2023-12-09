namespace IotaSDK.NET.Domain.Transactions.Strategy
{
    public class ChangeAddressStrategy : RemainderValueStrategy
    {
        public ChangeAddressStrategy() : base(strategy: "ChangeAddress")
        {
        }
    }

}