using IotaSDK.NET.Common.Rust;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public class IotaSDKErrorResponse
    {
        public IotaSDKErrorResponse(string type, string error)
        {
            Type = type;
            Error = error;
        }

        public string Type { get; }
        public string Error { get; }
    }

    public class IotaSDKResponse<TPayload> where TPayload : class
    {
        public IotaSDKResponse(string type)
        {
            Type = type;
        }

        public string Type { get; set; }

        public TPayload? Payload { get; set; }

        public override string ToString()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }
        public static IotaSDKResponse<TPayload> CreateInstance(string? rawResponse)
        {
            if (rawResponse == null)
                throw new ArgumentNullException("Cant create an instance of IotaSDKResponse as response is null.");

            return JsonConvert.DeserializeObject<IotaSDKResponse<TPayload>>(rawResponse!)!;
        }

    }
}
