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

                    var bech32 = await iotaUtilities.ConvertAliasIdToBech32Async("0x86c9a6c9abbc0206498bd08517352b92a022f1b5f6596237a31761101d1fa447", Domain.Network.HumanReadablePart.Rms);
                    Console.WriteLine(bech32);

                    var hex = await iotaUtilities.VerifyBech32Address("asd");
                    Console.WriteLine(hex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
}