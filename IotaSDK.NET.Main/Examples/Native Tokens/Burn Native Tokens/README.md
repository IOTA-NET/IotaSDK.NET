# Burn Native Tokens to Unlock Storage Deposits
## Code Example

The following example will:

1. Create a wallet
2. Retrieve your spending and savings account
3. Sync accounts and check balance
4. Retrieve your native token id from spendings
5. Send 100 native tokens with Gift Storage to the savings account
6. Burn the native tokens


```cs
public static class BurnNativeTokensExample
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


            //Let's proceed to retrieve our previously created "savings" & "spending" account.
            IAccount savingsAccount = (await wallet.GetAccountAsync("savings")).Payload;
            IAccount spendingAccount = (await wallet.GetAccountAsync("spending")).Payload;


            var savingsBalance = await savingsAccount.SyncAcountAsync();
            var spendingBalance = await spendingAccount.SyncAcountAsync();

            Console.WriteLine($"[* Before Native Tokens] :\n{savingsBalance}");

            string savingsAddress = (await savingsAccount.GetAddressesAsync()).Payload.First().Address;


            //Lets send 100 native tokens from the spendings account to the savings account
            string tokenId = spendingBalance.Payload.NativeTokens.First().TokenId;
            var txResponse = await spendingAccount.SendNativeTokensUsingBuilder()
                                    .AddNativeTokensOptions()
                                        .AddNativeTokens(tokenId, numberOfTokens: 100)
                                        .SetReceiverAddress(savingsAddress)
                                        .UseGiftStorage()
                                        .Then()
                                    .SendAsync();

            await spendingAccount.RetryTransactionUntilIncludedAsync(txResponse.Payload.TransactionId);

            savingsBalance = await savingsAccount.SyncAcountAsync();

            Console.WriteLine($"[* After Getting Native Tokens] :\n{savingsBalance}");

            txResponse = await savingsAccount.BurnNativeTokensAsync(tokenId, numberOfTokensToBurn: 100);
            await savingsAccount.RetryTransactionUntilIncludedAsync(txResponse.Payload.TransactionId);

            savingsBalance = await savingsAccount.SyncAcountAsync();
            Console.WriteLine($"[* After Burning Native Tokens] :\n{savingsBalance}");


        }
    }
}
```