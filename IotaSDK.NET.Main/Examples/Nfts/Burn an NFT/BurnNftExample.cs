using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Common.Models;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main.Examples.Nfts.Burn_an_NFT
{
    public static class BurnNftExample
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


                //Let's proceed to retrieve our previously created "spending" account.
                IAccount spendingAccount = (await wallet.GetAccountAsync("spending")).Payload;

                //Let's sync our account to the Tangle
                var balance = await spendingAccount.SyncAcountAsync();
                Console.WriteLine($"Before:\n{balance}\n\n");

                //Let's get all the nftIds we have
                List<string> nftIds = balance.Payload.Nfts;

                //Let's use the generic Burn API which can burn more than one NFT
                IotaSDKResponse<Transaction> burnResponse = await spendingAccount.BurnAsync(new BurnIds { Nfts = nftIds });
                Transaction transaction = burnResponse.Payload;

                //Let's wait until the transaction is included
                await spendingAccount.RetryTransactionUntilIncludedAsync(transaction.TransactionId);


                //Let's sync our account to the Tangle and ensure all nfts deleted
                balance = await spendingAccount.SyncAcountAsync();
                Console.WriteLine($"After:\n{balance}\n\n");
            }
        }
    }
}
