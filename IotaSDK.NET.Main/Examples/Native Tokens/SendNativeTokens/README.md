# Sending Native Tokens Example

## Code Example

The following example will:

1. Create a wallet
2. Retrieve your account
3. Sync account and check balance
4. Retrieve your native token id
5. Send Native Tokens using a fluent api

```cs
public static class SendNativeTokensExample
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
            var spendingBalance = await spendingAccount.SyncAcountAsync();

            //Let's get the tokenId of the Native Token "$CUTE" that we previously created.
            string tokenId = spendingBalance.Payload.NativeTokens.First().TokenId;

            string receiverAddress = "rms1qrwp0umeexltwgmqh57jmag4c93qjgww4wnhk3ln5ylc6d2axnzfsy5kdya";

            //Let's send 100 $CUTE tokens without gifted storage deposit,
            //followed by another 200 $CUTE tokens WITH gifted storage deposit
            IotaSDKResponse<Transaction> transactionResponse = await spendingAccount.SendNativeTokensUsingBuilder()
                                                                                        .AddNativeTokensOptions()
                                                                                            .AddNativeTokens(tokenId, numberOfTokens: 100)
                                                                                            .SetReceiverAddress(receiverAddress)
                                                                                            .Then()
                                                                                        .AddNativeTokensOptions()
                                                                                            .AddNativeTokens(tokenId, numberOfTokens:200)
                                                                                            .SetReceiverAddress(receiverAddress)
                                                                                            .UseGiftStorage() //Allow gift storage!
                                                                                            .Then()
                                                                                        .SendAsync();
            //Wait till tx completes
            await spendingAccount.RetryTransactionUntilIncludedAsync(transactionResponse.Payload.TransactionId);

        }
    }
}
```