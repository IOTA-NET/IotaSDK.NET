using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Nft;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
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



                var qwe = await account.BurnAsync(new BurnIds() { Nfts = new List<string> { "0xfa6ec2da9b498ce0413fee9e897e6be8e886a5b4a4ee1108b2f79220b286bb0f", "0x16a0fb96755e36d33b29e08f6dcf9c7f54f127ff31153d14f07d385f653def8d" } });
                Console.WriteLine(qwe);
                //NftIrc27 nftIrc27 = new NftIrc27("jpeg/image", "hello", "www.google.com")
                //    .AddAttribute("cool", "story");
                //NftOptions nftOptions = new NftOptions() { ImmutableMetadata = JsonConvert.SerializeObject(nftIrc27).ToHexString() };


                //var xxxxxx = await account.MintNftsAsync(new List<NftOptions>() { nftOptions });
            }

        }

    }
}