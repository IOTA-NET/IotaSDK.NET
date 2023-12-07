using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.UnlockConditions;
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
                var wallet = scope.ServiceProvider.GetRequiredService<IWallet>();

                wallet = await wallet
                            .ConfigureWalletOptions()
                                .SetStoragePath("./storage")
                                .SetCoinType(TypeOfCoin.Shimmer)
                                .Then()
                            .ConfigureClientOptions()
                                .SetFaucetUrl("https://faucet.testnet.shimmer.network")
                                .AddNodeUrl("https://api.testnet.shimmer.network")
                                .IsLocalPow()
                                .Then()
                            .ConfigureSecretManagerOptions()
                                .SetSnapshotPath("./snapshot")
                                .SetPassword("password")
                                .Then()
                            .InitializeAsync();

                var iotaUtilities = scope.ServiceProvider.GetRequiredService<IIotaUtilities>();

                var mnemonicResponse = await iotaUtilities.GenerateMnemonicAsync();
                string mnemonic = mnemonicResponse.Payload;

                await wallet.StoreMnemonicAsync(mnemonic);
            }

        }

    }
}