namespace IotaSDK.NET.Common.Models
{
    internal class IotaSDKAccountModel : IotaSDKModel<AccountModelData>
    {
        public IotaSDKAccountModel(AccountModelData data) : base("callAccountMethod", data)
        {
        }
    }



    internal class IotaSDKAccountModel<TInnerModel> : IotaSDKModel<AccountModelData<TInnerModel>> where TInnerModel : class
    {
        public IotaSDKAccountModel(AccountModelData<TInnerModel> data) : base("callAccountMethod", data)
        {
        }
    }
}
