# Create Foundry Example

## Code Example

The following example will:

1. Create a wallet
2. Retrieve your account
3. Sync account and check balance
4. Create an Alias output if none present
5. Create a Foundry output with Native token options using a fluent api

```cs
 public static class CreateFoundryExample
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

            //We need a Foundry to create Native Tokens.
            //However, we also need an Alias Output to create a Foundry Output
            //Let's check if we have any alias outputs, if not let's create one
            if(balance.Payload.Aliases.Any() == false)
            {
                Transaction createAliasTransaction = (await spendingAccount.CreateAliasOutputAsync()).Payload;
                await spendingAccount.RetryTransactionUntilIncludedAsync(createAliasTransaction.TransactionId);
            }
            balance = await spendingAccount.SyncAcountAsync();
            Console.WriteLine($"The alias address is {balance.Payload.Aliases.First()}");

            //Let's use the fluent api to create a native token foundry
            IotaSDKResponse<Transaction> response = await spendingAccount.CreateNativeTokensUsingBuilder()
                                                        .SetMaximumSupply(maximumSupply: 1000000)
                                                        .SetCirculatingSupply(circulatingSupply: 500000)
                                                        .SetFoundryMetadata()
                                                            .SetTokenName("CuteToken")
                                                            .SetSymbol("CUTE")
                                                            .SetDescription("A cute rainbow kitten.")
                                                            .SetNumberOfDecimals(decimals: 0)
                                                            .SetLogoUrl("https://img.freepik.com/free-photo/adorable-illustration-kittens-playing-forest-generative-ai_260559-483.jpg")
                                                            .Then()
                                                        .CreateNativeTokensAsync();
            //Let's wait till the transaction is confirmed
            await spendingAccount.RetryTransactionUntilIncludedAsync(response.Payload.TransactionId);


            //We have created our Native Token foundry! Let's sync our account to the Tangle
            balance = await spendingAccount.SyncAcountAsync();
            Console.WriteLine(balance);
        }
    }
```