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
                var mnemonic = await iotaUtilities.GenerateMnemonicAsync();
                Console.WriteLine(mnemonic);
                try
                {

                var hexseed = await iotaUtilities.ConvertMnemonicToHexSeedAsync(mnemonic.Payload!+" asd");
                Console.WriteLine(hexseed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
}