using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Rust;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
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
                                .SetStoragePath("./storage2")
                                .SetCoinType(TypeOfCoin.Shimmer)
                                .Then()
                            .ConfigureClientOptions()
                                .SetFaucetUrl("https://faucet.testnet.shimmer.network/api/enqueue")
                                .AddNodeUrl("https://api.testnet.shimmer.network")
                                .IsLocalPow()
                                .Then()
                            .ConfigureSecretManagerOptions()
                                .SetSnapshotPath("./snapshot2")
                                .SetPassword("password")
                                .Then()
                            .InitializeAsync();

                var logerConfig = new RustLoggerConfiguration(LogLevelFilter.debug);
                await iotaUtilities.StartLoggerAsync(logerConfig);

                string mnemonic = iotaUtilities.GenerateMnemonicAsync().Result.Payload;

                
                var createAccountResponse =  await wallet.CreateAccountAsync(username:"myAccount_4");
                IAccount account = createAccountResponse.Payload;
                string mainAddress = (await account.GetAddressesAsync()).Payload.First().Address;

                IClient client = wallet.GetClient();
                var faucetResponse = await client.RequestFundsFromFaucetAsync(mainAddress);

                await Task.Delay(20000);

                var balanceResponse = await account.SyncAcountAsync();

                Console.WriteLine(balanceResponse);
            }

        }

    }
}