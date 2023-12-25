using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Tokens;
using Microsoft.Extensions.DependencyInjection;
using IotaSDK.NET.Common.Extensions;

namespace IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Check_Balance
{
    public static class RequestTokensFromFaucetExample
    {
        public static async Task Run()
        {
            //Register all of the dependencies into a collection of services
            IServiceCollection services = new ServiceCollection().AddIotaSDKServices();

            //Install services to service provider which is used for dependency injection
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //Use serviceprovider to create a scope, which disposes of all services at end of scope
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                //Request IWallet service from service provider
                IWallet wallet = scope.ServiceProvider.GetRequiredService<IWallet>();

                //Build wallet using a fluent-style configuration api
                wallet = await wallet
                                .ConfigureWalletOptions()
                                    .SetCoinType(TypeOfCoin.Shimmer)
                                    .SetStoragePath("./walletdb")
                                    .Then()
                                .ConfigureClientOptions()
                                    .AddNodeUrl("https://api.testnet.shimmer.network")
                                    .SetFaucetUrl("https://faucet.testnet.shimmer.network/api/enqueue")
                                    .IsLocalPow()
                                    .Then()
                                .ConfigureSecretManagerOptions()
                                    .SetPassword("password")
                                    .SetSnapshotPath("./mystronghold")
                                    .Then()
                                .InitializeAsync();


                //Let's proceed to retrieve our previously created account, called "savings".
                IAccount savingsAccount = (await wallet.GetAccountAsync("savings")).Payload;

                //Since we are in a testnet, let's ask for some free Shimmer testnet tokens (RMS)!
                await savingsAccount.RequestFundsFromFaucetAsync();

                // Let's learn to turn on periodic syncing!
                // This allows your account to be automatically synced in the background
                // without you manually calling the sync function, great for UI!
                await wallet.StartBackgroundSyncAsync(intervalInMilliseconds: 5000); // sync every 5 seconds

                //Let's check our balance every second untill we are given some RMS
                int shimmerBalance= 0;
                while(shimmerBalance == 0)
                {
                    string balance = (await savingsAccount.GetBalanceAsync()).Payload.BaseCoin.Total;
                    shimmerBalance = int.Parse(balance);
                    Console.WriteLine($"[*] Balance : {shimmerBalance} RMS");
                    await Task.Delay(1000);
                }
            }
        }
    }
}
