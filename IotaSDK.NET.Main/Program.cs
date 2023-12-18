using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Tokens;
using Microsoft.Extensions.DependencyInjection;

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


                var log = new RustLoggerConfiguration(LogLevelFilter.debug);
                var x = await iotaUtilities.StartLoggerAsync(log);

                var rrr = await wallet.GetAccountAsync("cookie");
                IAccount account = rrr.Payload;
                var balance = await account.SyncAcountAsync();
                Console.WriteLine(balance);

                var address = (await account.GetAddressesAsync()).Payload.First().Address;

                var xxs = await account.PrepareBurnNftAsync("0x3cbdece493667765b5c287ccdf349503a3775da7a9d90b89597ecf78806f7ab2");
                var qwe = await account.SignAndSubmitTransactionAsync(xxs.Payload);
                Console.WriteLine(qwe);
                int xxa = 3;
                //NftIrc27 nftIrc27 = new NftIrc27("jpeg/image", "hello", "www.google.com")
                //    .AddAttribute("cool", "story");

                //NftOptions nftOptions = new NftOptions() { ImmutableMetadata = JsonConvert.SerializeObject(nftIrc27).ToHexString() };


                //var xxxxxx = await account.MintNftsAsync(new List<NftOptions>() { nftOptions });
            }

        }

    }
}