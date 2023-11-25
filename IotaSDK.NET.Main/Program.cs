using IotaSDK.NET.Common.Options;
using IotaSDK.NET.Common.Rust;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IotaSDK.NET.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configure Newtonsoft.Json to use camelCase
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            WalletOptions options = new WalletOptions();

            var walletOptionsJson = JsonConvert.SerializeObject(options);
            var result = RustBridge.CreateWallet(walletOptionsJson);

            var secretmanager = RustBridge.GetSecretManagerFromWallet(result);

            bool destroyed = RustBridge.DestroyWallet(result);   
        }
    }
}