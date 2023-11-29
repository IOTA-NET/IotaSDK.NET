using IotaSDK.NET.Common.Rust;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IotaSDK.NET.Common.Interfaces
{
    public class IotaSDKInnerResponse<TPayload> where TPayload : class
    {
        public IotaSDKInnerResponse(string type)
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
    }
    public class IotaSDKResponse<TPayload> where TPayload : class
    {
        public IotaSDKInnerResponse<TPayload>? Response { get; set; }
        public string? ErrorMessage { get; set; }


        public override string ToString()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }

        public static async Task<IotaSDKResponse<TPayload>> CreateInstanceAsync(string? rawResponse, RustBridgeCommon rustBridgeCommon)
        {

            IotaSDKResponse<TPayload> response = new IotaSDKResponse<TPayload>
            {
                Response = rawResponse == null ? null : JsonConvert.DeserializeObject<IotaSDKInnerResponse<TPayload>>(rawResponse),
                ErrorMessage = rawResponse == null ? null : await rustBridgeCommon.GetLastErrorAsync()
            };

            return response;
        }
    }
}
