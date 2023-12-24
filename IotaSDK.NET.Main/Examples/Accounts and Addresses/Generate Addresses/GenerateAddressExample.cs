using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Create_Wallet_and_Account
{
    public static class GenerateAddressExample
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

                //Let's proceed to retrieve our "savings" account and try to generate a new address
                //Note: By default the account already has one main address when the account is created
                IAccount savingsAccount = (await wallet.GetAccountAsync("savings")).Payload;

                //Let's get the main address!
                string mainAddress = (await savingsAccount.GetAddressesAsync())
                                                          .Payload
                                                          .First()
                                                          .Address;

                string newAddress = (await savingsAccount.GenerateEd25519AddressesAsync(numberOfAddresses: 1))
                                                         .Payload
                                                         .First()
                                                         .Address;

                Console.WriteLine($"[* Savings Account] Main Address: {mainAddress}");
                Console.WriteLine($"[* Savings Account] New  Address: {newAddress}");
            }
        }

    }
}