namespace IotaSDK.NET.Common.Models
{
    internal class AccountModelData
    {
        public AccountModelData(int accountId, IotaSDKModel method)
        {
            AccountId = accountId;
            Method = method;
        }

        public int AccountId { get; }
        public IotaSDKModel Method { get; }
    }

    internal class AccountModelData<TInnerModel> where TInnerModel : class
    {
        public AccountModelData(int accountId, IotaSDKModel<TInnerModel> data)
        {
            AccountId = accountId;
            Method = data;
        }

        public int AccountId { get; }
        public IotaSDKModel<TInnerModel> Method { get; }
    }
}
