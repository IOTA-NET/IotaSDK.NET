using IotaSDK.NET.Common.Extensions;
using IotaSDK.NET.Common.Interfaces;
using IotaSDK.NET.Domain.Tokens;
using IotaSDK.NET.Domain.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace IotaSDK.NET.Main.Examples.Accounts_and_Addresses.Check_Balance
{
    public static class SendBasecoinTransactionExample
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


                //Let's proceed to retrieve our previouslys created accounts, called "savings" and spending.
                IAccount savingsAccount = (await wallet.GetAccountAsync("savings")).Payload;
                IAccount spendingAccount = (await wallet.GetAccountAsync("spending")).Payload;

                //Let's create a function to print their balances
                Func<Task> printBalanceAsync = async () =>
                {
                    ulong savingsBalance = ulong.Parse((await savingsAccount.SyncAcountAsync()).Payload.BaseCoin.Total);
                    ulong spendingBalance = ulong.Parse((await spendingAccount.SyncAcountAsync()).Payload.BaseCoin.Total);
                    Console.WriteLine($"[* Savings Balance] {savingsBalance.ToString("N0")}");
                    Console.WriteLine($"[* Spending Balance] {spendingBalance.ToString("N0")}");
                };

                Console.WriteLine("Before Transaction:");
                await printBalanceAsync();

                //Get our spending Accounts address. It is the receiver.
                string spendingAccountAddress = (await spendingAccount.GetAddressesAsync()).Payload.First().Address;

                //Let's send 100 RMS from our savings account to our spending account
                Console.WriteLine("[*] Transfering 100 RMS");
                Transaction transaction = (await savingsAccount.SendBaseCoinAsync(amount: 100 * 1000000, spendingAccountAddress)).Payload;

                //Wait until tx is confirmed
                await savingsAccount.RetryTransactionUntilIncludedAsync(transaction.TransactionId);

                Console.WriteLine("After Transaction:");
                await printBalanceAsync();
            }
        }
    }
}
