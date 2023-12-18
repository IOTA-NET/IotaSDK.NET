using IotaSDK.NET.Common.Interfaces;

namespace IotaSDK.NET.Common.Models
{

    internal class IotaSDKModel : SerializableModel
    {
        public IotaSDKModel(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
    internal class IotaSDKModel<TData> : SerializableModel
    {
        public IotaSDKModel(string name, TData data)
        {
            Data = data;
            Name = name;

        }
        public string Name { get; }
        public TData Data { get; }
    }
}
