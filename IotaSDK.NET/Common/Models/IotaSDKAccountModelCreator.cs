namespace IotaSDK.NET.Common.Models
{
    internal class IotaSDKAccountModelCreator
    {
        public IotaSDKAccountModel Create(string accountMethodName, int accountId)
        {
            IotaSDKModel innerModel = new IotaSDKModel(name: accountMethodName);
            AccountModelData accountModelData = new AccountModelData(accountId, innerModel);
            IotaSDKAccountModel iotaSDKAccountModel = new IotaSDKAccountModel(accountModelData);

            return iotaSDKAccountModel;
        }
    }

    internal class IotaSDKAccountModelCreator<TInnerModelData> where TInnerModelData : class
    {
        public IotaSDKAccountModel<TInnerModelData> Create(string accountMethodName, int accountId, TInnerModelData innerModelData)
        {
            IotaSDKModel<TInnerModelData> innerModel = new IotaSDKModel<TInnerModelData>(name: accountMethodName, innerModelData);
            AccountModelData<TInnerModelData> accountModelData = new AccountModelData<TInnerModelData>(accountId, innerModel);
            IotaSDKAccountModel<TInnerModelData> iotaSDKAccountModel = new IotaSDKAccountModel<TInnerModelData>(accountModelData);

            return iotaSDKAccountModel;
        }
    }
}
