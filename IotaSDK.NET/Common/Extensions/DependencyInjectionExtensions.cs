using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Contexts.UtilsContext;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace IotaSDK.NET.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddIotaSDKServices(this IServiceCollection serviceDescriptors)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
            };

            serviceDescriptors
                .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            serviceDescriptors
                .AddSingleton<IWallet, Wallet>();


            serviceDescriptors
                .AddTransient<RustBridgeClient>()
                .AddTransient<RustBridgeCommon>()
                .AddTransient<RustBridgeSecretManager>()
                .AddTransient<RustBridgeWallet>();


            serviceDescriptors
                .AddTransient<IIotaUtilities, IotaUtilities>();

            return serviceDescriptors;
        }
    }
}
