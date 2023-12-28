using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Check_Balance
{
    public static class CheckBalanceExample
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

                //Let's proceed to retrieve our previously created accounts.
                //We named them as "savings" and "spending"
                var accountResponse = await wallet.GetAccountAsync("savings");
                IAccount savingsAccount = accountResponse.Payload;

                accountResponse = await wallet.GetAccountAsync("spending");
                IAccount spendingAccount = accountResponse.Payload;

                //Lets synchronize them with the Tangle and see thier latest balances!

                var savingsBalance = await savingsAccount.SyncAcountAsync();
                var spendingBalance = await spendingAccount.SyncAcountAsync();

                Console.WriteLine("[* Savings Account Balance ]");
                Console.WriteLine(savingsBalance);
                Console.WriteLine("\n\n");
                Console.WriteLine("[* Spending Account Balance ]");
                Console.WriteLine(spendingBalance);
            }
        }
    }
}
