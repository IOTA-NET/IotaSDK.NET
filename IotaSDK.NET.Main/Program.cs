using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Addresses;
using IotaSDK.NET.Domain.Outputs;
using IotaSDK.NET.Domain.Tokens;
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
    public class LoggerConfig
    {
        // Color flag of an output.
        public bool ColorEnabled { get; set; } = true;

        // Log level filter of an output.
        public string LevelFilter { get; set; } = "debug";

        // Name of an output file, or `stdout` for standard output.
        public string Name { get; set; } = "stdout";
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection().AddIotaSDKServices();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var common = scope.ServiceProvider.GetRequiredService<RustBridgeCommon>();
                var log = new LoggerConfig();

                var x = await common.InitLoggerAsync(JsonConvert.SerializeObject(log));

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

                //var mnemonicResponse = await iotaUtilities.GenerateMnemonicAsync();
                //string mnemonic = mnemonicResponse.Payload;

                //await wallet.StoreMnemonicAsync(mnemonic);

                var r = await wallet.CheckIfStrongholdPasswordExistsAsync();

               var rr = await wallet.AuthenticateToStrongholdAsync("password");
            }

        }

    }
}