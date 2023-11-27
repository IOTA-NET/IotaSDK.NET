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


            return serviceDescriptors;
        }
    }
}
