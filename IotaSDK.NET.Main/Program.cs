using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection().AddIotaSDKServices();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var iotaUtilities = scope.ServiceProvider.GetRequiredService<IIotaUtilities>();

                try
                {

                    var bech32 = await iotaUtilities.ConvertNftIdToBech32Async("0xf52d0033cb801d960f5e02fbddae5102a9d8fa651408a277f763f9fc3e882f49", Domain.Network.HumanReadablePart.Rms);
                    Console.WriteLine(bech32);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
}