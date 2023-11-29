using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Contexts.UtilsContext;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IotaSDK.NET.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddIotaSDKServices(this IServiceCollection serviceDescriptors)
        {
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
