using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using IotaSDK.NET.Domain.UnlockConditions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace IotaSDK.NET.Main
{
    public class LoggerConfigLevelFilter
    {
        // Define the properties for LogLevel filter if needed.
        // Replace the type or properties based on your specific requirements.
        // For example:
        // public LogLevel MinLevel { get; set; }
        // public LogLevel MaxLevel { get; set; }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection().AddIotaSDKServices();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var iotaUtilities = scope.ServiceProvider.GetRequiredService<IIotaUtilities>();
                var log = new RustLoggerConfiguration(LogLevelFilter.debug);


                var x = await iotaUtilities.StartLoggerAsync(log);

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


                var rrr = await wallet.GetAccountAsync("cookie");
                IAccount account = rrr.Payload;
                var balance = await account.SyncAcountAsync();
                Console.WriteLine(balance);

                NftIrc27 nftIrc27 = new NftIrc27("jpeg/image", "hello", "www.google.com")
                    .AddAttribute("cool", "story");

                NftOptions nftOptions = new NftOptions() { ImmutableMetadata = JsonConvert.SerializeObject(nftIrc27).ToHexString() };

                var xxxxxx = await account.PrepareMintNftsAsync(new List<NftOptions>() { nftOptions });
                var qwe = xxxxxx.Payload.Essence.GetTransactionEssenceType();
                int xs = 33;
            }

        }

    }
}