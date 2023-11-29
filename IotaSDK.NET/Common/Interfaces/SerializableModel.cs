using Newtonsoft.Json;

namespace IotaSDK.NET.Common.Interfaces
{
    internal abstract class SerializableModel
    {
        public string AsJson() => JsonConvert.SerializeObject(this);
    }
}
