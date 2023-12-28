# Mint NFTs Example

## Code Example

The following example will:

1. Create a wallet
2. Retrieve your account
3. Get account's main address
4. Mint NFTs
5. Wait for confirmation
6. View the Transaction Id

```cs
public static class MintNftExample
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
            //Let's get its main address
            string spendingAccountAddress = (await spendingAccount.GetAddressesAsync()).Payload.First().Address;
            //Let's get some nft uri
            string nft1Url = "https://ipfs.io/ipfs/bafkreia5gwoubt7d5jirspnmktt3wcoose64g6kvodsqogwyvreq2pyx2e";
            string nft2Url = "ipfs://bafybeifgqqapzluqkv3a6ri2swwx5nvh4sl33a7rrito57w25dwmw2bbhm";

            //Mint them using our fluent-api
            var mintNftResponse = await spendingAccount
                                        .MintNftsUsingBuilder()
                                            .CreateNewNft()
                                                .AddImmutableMetadata(KnownMimeTypes.Jpg, "Cute Pic", nft1Url)
                                                    .SetCollectionName("Cute Pics v1")
                                                    .SetIssuerName("Cookiemonster")
                                                    .SetDescription("A collection of cute pics")
                                                    .AddAttribute("Date", "20231228")
                                                    .AddAttribute("Cuteness", "9")
                                                    .Then()
                                                .AddIssuer(address: spendingAccountAddress)
                                                .AddTag("IotaSDK.NET")
                                                .Then()
                                            .CreateNewNft()
                                                .AddImmutableMetadata(KnownMimeTypes.Jpg, "Cuter Pic", nft2Url)
                                                    .SetCollectionName("Cute Pics v2")
                                                    .SetIssuerName("Cookiemonster")
                                                    .SetDescription("A newer collection of cute pics")
                                                    .AddAttribute("Date", "20231228")
                                                    .AddAttribute("Cuteness", "10")
                                                    .Then()
                                                .AddIssuer(address: spendingAccountAddress)
                                                .AddTag("IotaSDK.NET")
                                                .Then()
                                            .MinftNftsAsync();

            //Let's wait for confirmation and view the tx id
            Transaction transaction = mintNftResponse.Payload;
            await spendingAccount.RetryTransactionUntilIncludedAsync(transaction.TransactionId);
            Console.WriteLine($"TransactionId: {transaction.TransactionId}");
        }
    }
}
```